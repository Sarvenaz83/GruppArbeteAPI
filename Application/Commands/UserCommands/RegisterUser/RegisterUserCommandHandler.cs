using Application.Validators;
using BCrypt.Net;
using Domain.Models;
using FluentValidation;
using Infrastructure.Repository.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
                var user = new User { UserName = request.Password, Password = passwordHash };

                await _userRepository.AddAsync(user);
                return user;
            }
            catch (Exception ex)
            {
                // Hantera fallet där användarnamnet redan finns
                throw new Exception("User creation failed.", ex);
            }
        }
    }
}
