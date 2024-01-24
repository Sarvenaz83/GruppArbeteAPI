using Application.Queries.UserQueries.GetAllUsers;
using Domain.Models;
using Infrastructure.Repository.UserRepository;
using Moq;
using NUnit.Framework;

namespace Tests.UserTests.QueriesTest.UserQueries
{
    [TestFixture]
    public class GetAllUsersQueryHandlerTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private GettAllUsersQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _handler = new GettAllUsersQueryHandler(_mockUserRepository.Object);
        }

        [Test]
        public async Task Handle_ReturnAllUsers()
        {
            //Arrange
            List<User> expectedUser = new List<User>()
            {
                new User()
                {
                    UserId = Guid.NewGuid(),
                    UserName = "Erik"
                },
                new User()
                {
                    UserId = Guid.NewGuid(),
                    UserName = "Sven"
                }
            };
            _mockUserRepository.Setup(userRepository => userRepository.GetAllUsersAsync())
                .ReturnsAsync(expectedUser);

            //Act
            List<User> actualUser = await _handler.Handle(new GetAllUsersQuery(), CancellationToken.None);

            //Assert
            Assert.That(actualUser, Is.EqualTo(expectedUser));
        }

    }
}
