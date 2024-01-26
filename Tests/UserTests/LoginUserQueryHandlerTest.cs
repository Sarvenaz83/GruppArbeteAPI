using Application.Queries.UserQueries;
using Application.Queries.UserQueries.LoginUser;
using Domain.Models;
using Infrastructure.Repository.UserRepository;
using Moq;
using NUnit.Framework;

namespace Tests.UserTests
{
    [TestFixture]
    public class LoginUserQueryHandlerTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private LoginUserQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _handler = new LoginUserQueryHandler(_mockUserRepository.Object);
        }

        [Test]
        public async Task Handle_CorrectPasswordForUser_ReturnsUser()
        {
            // Arrange
            var testUser = new User
            {
                UserName = "testuser",
                Password = BCrypt.Net.BCrypt.HashPassword("Password123!")
            };

            var query = new LoginUserQuery
            {
                Username = "testuser",
                Password = "Password123!"
            };

            _mockUserRepository
                .Setup(repo => repo.FindByUsernameAsync(query.Username))
                .ReturnsAsync(testUser);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.UserName, Is.EqualTo(testUser.UserName));
        }

        [Test]
        public async Task Handle_WrongPasswordForUser_ReturnsNull()
        {
            // Arrange
            var testUser = new User
            {
                UserName = "testuser",
                Password = BCrypt.Net.BCrypt.HashPassword("Password123!")
            };

            var query = new LoginUserQuery
            {
                Username = "testuser",
                Password = "WrongPassword"
            };

            _mockUserRepository
                .Setup(repo => repo.FindByUsernameAsync(query.Username))
                .ReturnsAsync(testUser);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }

}
