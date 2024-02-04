using Domain.Models;
using Infrastructure.Repository.UserRepository;
using MediatR;

namespace Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserByIdCommandHandler : IRequestHandler<UpdateUserByIdCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserByIdCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                // Hantera fallet där användaren inte finns...
                throw new Exception("User not found.");
            }

            // Uppdatera användarens information från DTO
            user.FirstName = request.UpdateUserDto.FirstName!;
            user.SurName = request.UpdateUserDto.SurName!;
            user.Email = request.UpdateUserDto.Email!;
            user.TelephoneNumber = request.UpdateUserDto.TelephoneNumber!;

            if (!string.IsNullOrEmpty(request.UpdateUserDto.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.UpdateUserDto.Password);
            }

            // Spara ändringarna
            await _userRepository.UpdateAsync(user);
            return user;
        }
    }
}
