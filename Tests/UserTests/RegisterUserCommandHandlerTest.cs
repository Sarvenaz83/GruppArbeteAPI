using Application.Commands.UserCommands.RegisterUser;
using Domain.Models;
using Infrastructure.Repository.UserRepository;
using Infrastructure.Repository.WalletRepository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UserTests
{
    [TestFixture]
    public class RegisterUserCommandHandlerTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IWalletRepository> _mockWalletRepository;
        private RegisterUserCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockWalletRepository = new Mock<IWalletRepository>();
            _handler = new RegisterUserCommandHandler(_mockUserRepository.Object, _mockWalletRepository.Object);
        }

        [Test]
        public async Task Handle_ValidUser_AddsUserToRepository()
        {
            // Arrange
            var command = new RegisterUserCommand
            {
                Username = "testuser",
                Password = "Password123!"
            };

            var mockWallet = new Wallet { WalletId = Guid.NewGuid() }; // Skapa en mock Wallet
            _mockWalletRepository
                .Setup(repo => repo.AddAsync(It.IsAny<Wallet>()))
                .ReturnsAsync(mockWallet); // Returnera mock Wallet när AddAsync anropas

            _mockUserRepository
                .Setup(repo => repo.AddAsync(It.IsAny<User>()))
                .ReturnsAsync((User user) => user); // Returnera användaren som tillhandahålls

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.UserName, Is.EqualTo(command.Username));
            _mockUserRepository.Verify(repo => repo.AddAsync(It.IsAny<User>()), Times.Once); // Verifiera att AddAsync anropades en gång
            _mockWalletRepository.Verify(repo => repo.AddAsync(It.IsAny<Wallet>()), Times.Once); // Verifiera att AddAsync för Wallet anropades en gång
        }

        [Test]
        public void Handle_UsernameAlreadyTaken_ThrowsException()
        {
            // Arrange
            var command = new RegisterUserCommand
            {
                Username = "existinguser",
                Password = "Password123!"
            };

            _mockUserRepository
                .Setup(repo => repo.FindByUsernameAsync(command.Username))
                .ReturnsAsync(new User { UserId = Guid.NewGuid(), UserName = command.Username });

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(async () => await _handler.Handle(command, CancellationToken.None));
            Assert.That(ex.Message, Is.EqualTo("Username is already taken."));
        }

    }

}
