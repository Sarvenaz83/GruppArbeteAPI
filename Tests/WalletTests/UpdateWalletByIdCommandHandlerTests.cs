using Application.Commands.WalletCommands;
using Application.Dtos;
using Application.Dtos.WalletDtos;
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

namespace Tests.WalletTests
{
    [TestFixture]
    public class UpdateWalletByIdCommandHandlerTests
    {

        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IWalletRepository> _mockWalletRepository;
        private UpdateWalletByIdCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            // Mock the repositories
            _mockUserRepository = new Mock<IUserRepository>();
            _mockWalletRepository = new Mock<IWalletRepository>();

            // Set up our handler with the mocked repositories
            _handler = new UpdateWalletByIdCommandHandler(_mockUserRepository.Object, _mockWalletRepository.Object);
        }

        [Test]
        public async Task Handle_UserExists_UpdatesWalletBalance()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var balance = 100;
            var user = new User { UserId = userId };
            var walletDto = new WalletDto { Balance = balance };
            _mockUserRepository.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(user);
            _mockWalletRepository.Setup(repo => repo.UpdateBalance(userId, balance)).ReturnsAsync(new Wallet { UserId = userId, Balance = balance });

            var command = new UpdateWalletByIdCommand(userId, walletDto);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Balance, Is.EqualTo(balance));
            _mockWalletRepository.Verify(repo => repo.UpdateBalance(userId, balance), Times.Once);
        }

        [Test]
        public void Handle_UserDoesNotExist_ThrowsException()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var balance = 100;
            var walletDto = new WalletDto { Balance = balance };
            _mockUserRepository.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync((User)null);

            var command = new UpdateWalletByIdCommand(userId, walletDto);

            // Act & Assert
            var exception = Assert.ThrowsAsync<Exception>(async () => await _handler.Handle(command, CancellationToken.None));
            Assert.That(exception.Message, Is.EqualTo("User not found."));
        }
    }
}
