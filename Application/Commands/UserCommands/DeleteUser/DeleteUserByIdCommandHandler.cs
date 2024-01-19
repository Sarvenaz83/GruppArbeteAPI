// DeleteUserByIdCommandHandler
using System;
using Domain.Models;
using Infrastructure.Repository.UserRepository;
using MediatR;

namespace Application.Commands.UserCommands.DeleteUser
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserByIdCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            User userToDelete = await _userRepository.GetById(request.Id);

            if (userToDelete == null)
            {
                return null!;
            }

            await _userRepository.DeleteUser(userToDelete.UserId);

            return userToDelete;
        }
    }
}

