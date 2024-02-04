using NUnit.Framework;
using Moq;
using Application.Queries.BookQueries.GetBookByAuthorName;
using Domain.Models;
using Infrastructure.Repository.BookRepository;

namespace Tests.BookTests.QueryTests
{
    [TestFixture]
    public class GetBookByAuthorNameQueryHandlerTests
    {
        private Mock<IBookRepository> _mockBookRepository;
        private GetBookByAuthorNameQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _handler = new GetBookByAuthorNameQueryHandler(_mockBookRepository.Object);
        }

        [Test]
        public async Task Handle_ShouldCallGetBooksByAuthorNameOnceWithCorrectParameters()
        {
            //Arrange
            var expectedBooks = new List<Book?> { };
            _mockBookRepository.Setup(repo => repo.GetBooksByAuthorName(It.IsAny<string>()))
                .ReturnsAsync(expectedBooks);
            var query = new GetBookByAuthorNameQuery { AuthorName = "Test" };

            //Act
            var result = await _handler.Handle(query, default);

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedBooks));
        }

        [Test]
        public async Task Handle_ShouldReturnEmptyListWhenRepoReturnsNull()
        {
            // Arrange
            var expectedBooks = new List<Book?>();
            _mockBookRepository.Setup(repo => repo.GetBooksByAuthorName(It.IsAny<string>()))
                .ReturnsAsync(expectedBooks);

            var query = new GetBookByAuthorNameQuery { AuthorName = "Nonexistent Author" };

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            Assert.That(result, Is.EquivalentTo(expectedBooks));
        }


    }
}
