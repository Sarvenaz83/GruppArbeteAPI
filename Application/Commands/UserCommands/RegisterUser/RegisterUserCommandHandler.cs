using Application.Validators;
using BCrypt.Net;
using Domain.Models;
using FluentValidation;
using Infrastructure.Repository.UserRepository;
using Infrastructure.Repository.WalletRepository;
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
        private readonly IWalletRepository _walletRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository, IWalletRepository walletRepository)
        {
            _userRepository = userRepository;
            _walletRepository = walletRepository;
        }


        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // try
            {
                var existingUser = await _userRepository.FindByUsernameAsync(request.Username);
                if (existingUser != null)
                {
                    throw new Exception("Username is already taken.");
                    //return null;
                }

                var wallet = new Wallet
                {
                    WalletId = Guid.NewGuid()
                };
                await _walletRepository.AddAsync(wallet);

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

                var user = new User
                {
                    UserId = Guid.NewGuid(),
                    UserName = request.Username,
                    Password = passwordHash,
                    WalletId = wallet.WalletId
                };

                await _userRepository.AddAsync(user);
                return user;
            }
            //catch (Exception ex)
            //{
            //    // Hantera fallet där användarnamnet redan finns
            //    throw new Exception("User creation failed.", ex);
            //}
        }
    }
}
