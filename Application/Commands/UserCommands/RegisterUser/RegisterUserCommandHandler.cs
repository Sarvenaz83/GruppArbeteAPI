using Domain.Models;
using Infrastructure.Repository.UserRepository;
using Infrastructure.Repository.WalletRepository;
using MediatR;

namespace Application.Commands.UserCommands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository, IWalletRepository walletRepository)
        {
            _userRepository = userRepository;
            _walletRepository = walletRepository;
        }


        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.FindByUsernameAsync(request.NewUser.UserName);
            if (existingUser != null)
            {
                throw new Exception("Username is already taken.");
                //return null;
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password);
            var user = new User
            {
                UserId = Guid.NewGuid(),
                UserName = request.NewUser.UserName,
                Password = passwordHash,
                FirstName = request.NewUser.FirstName,
                SurName = request.NewUser.SurName,
                Email = request.NewUser.Email,
                TelephoneNumber = request.NewUser.TelephoneNumber,
            };

            var wallet = new Wallet
            {
                WalletId = Guid.NewGuid(),
                UserId = user.UserId
            };

            await _userRepository.AddAsync(user);


            await _walletRepository.AddAsync(wallet);

            return user;


        }
    }
}
