using Domain.Models;
using Application.Queries.UserQueries.GetAllUsers;
using Infrastructure.Repository.UserRepository;
using Moq;
using NUnit.Framework;
using Application.Dtos;

namespace Tests.UserTests.QueriesTest.UserQueries
{

    [TestFixture]
    public class GetAllUsersQueryHandlerTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private GetAllUsersQueryHandler _handler;
        private GetAllUsersQuery _query;

        [SetUp]
        public void SetUp()
        {
            // Mock the user repository
            _mockUserRepository = new Mock<IUserRepository>();

            // Set up our handler with the mocked user repository
            _handler = new GetAllUsersQueryHandler(_mockUserRepository.Object);

            // Instantiate the query (normally, we'd pass parameters if there were any)
            _query = new GetAllUsersQuery();
        }

        [Test]
        public async Task Handle_ReturnsCorrectUserData()
        {
            // Arrange
            var users = new List<User>
            {
            new User
            {
                UserId = Guid.NewGuid(),
                Wallet = new Wallet (),
                UserName = "Anvandare1",
                Role = "Användarroll1",
                Password = "Lösenord1!",
                Email = "anvandare1@example.com",
                TelephoneNumber = "1234567890",
                FirstName = "Förnamn1",
                SurName = "Efternamn1",
                PurchaseHistories = new List<PurchaseHistory> ()
            },
            new User
            {
                UserId = Guid.NewGuid(),
                Wallet = new Wallet (),
                UserName = "Anvandare2",
                Role = "Användarroll2",
                Password = "Lösenord2!",
                Email = "anvandare2@example.com",
                TelephoneNumber = "0987654321",
                FirstName = "Förnamn2",
                SurName = "Efternamn2",
                PurchaseHistories = new List<PurchaseHistory> ()
            }
           };

            _mockUserRepository.Setup(repo => repo.GetAllUsersAsync())
                .ReturnsAsync(users);

            // Act
            var result = await _handler.Handle(_query, new CancellationToken());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<GetAllUsersDto>>(result);
            Assert.That(result.Count(), Is.EqualTo(users.Count));
            Assert.That(result.All(user => user.UserId != Guid.Empty), Is.True);
            Assert.That(result.All(user => !string.IsNullOrEmpty(user.UserName)), Is.True);

        }

        [Test]
        public async Task Handle_RepositoryReturnsEmptyList_ReturnsEmptyList()
        {
            // Arrange
            _mockUserRepository.Setup(repo => repo.GetAllUsersAsync())
                .ReturnsAsync(new List<User>());

            // Act
            var result = await _handler.Handle(_query, new CancellationToken());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

    }

}
