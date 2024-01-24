using Application.Commands.UserCommands.UpdateUser;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Repository.UserRepository;
using Moq;
using NUnit.Framework;

namespace Tests.UserTests.UserQueries
{
    [TestFixture]
    public class UpdateUserByIdCommandHandlerTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private UpdateUserByIdCommandHandler _handler;
        private UpdateUserByIdCommand _command;
        private User _existingUser;

        [SetUp]
        public void SetUp()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _handler = new UpdateUserByIdCommandHandler(_mockUserRepository.Object);

            _existingUser = new User
            {
                UserId = Guid.NewGuid(),
                FirstName = "OriginalFirstName",
                SurName = "OriginalSurName",
                Email = "original@example.com",
                TelephoneNumber = "123456789",
                Password = "OriginalPassword!"
            };

            _command = new UpdateUserByIdCommand
            {
                UserId = _existingUser.UserId,
                UpdateUserDto = new UpdateUserDto
                {
                    FirstName = "UpdatedFirstName",
                    SurName = "UpdatedSurName",
                    Email = "updated@example.com",
                    TelephoneNumber = "987654321",
                    Password = "UpdatedPassword!"
                }
            };

            _mockUserRepository.Setup(repo => repo.GetByIdAsync(_existingUser.UserId))
                .ReturnsAsync(_existingUser);
        }

        [Test]
        public async Task Handle_UserFound_UpdatesUserSuccessfully()
        {
            // Arrange
            _mockUserRepository.Setup(repo => repo.UpdateAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask).Verifiable();

            // Act
            var updatedUser = await _handler.Handle(_command, new CancellationToken());

            // Assert
            _mockUserRepository.Verify(repo => repo.UpdateAsync(It.IsAny<User>()), Times.Once);
            Assert.That(updatedUser.FirstName, Is.EqualTo(_command.UpdateUserDto.FirstName));
            Assert.That(updatedUser.SurName, Is.EqualTo(_command.UpdateUserDto.SurName));
            Assert.That(updatedUser.Email, Is.EqualTo(_command.UpdateUserDto.Email));
            Assert.That(updatedUser.TelephoneNumber, Is.EqualTo(_command.UpdateUserDto.TelephoneNumber));
        }

        [Test]
        public void Handle_UserNotFound_ThrowsException()
        {
            // Arrange
            _mockUserRepository.Setup(repo => repo.GetByIdAsync(Guid.NewGuid()))
                .ReturnsAsync((User)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => _handler.Handle(new UpdateUserByIdCommand { UserId = Guid.NewGuid() }, new CancellationToken()));
            Assert.That(ex.Message, Is.EqualTo("User not found."));
        }
    }
}