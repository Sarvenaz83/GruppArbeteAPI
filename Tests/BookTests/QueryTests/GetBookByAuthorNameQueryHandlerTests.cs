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
            // Arrange
            var authorName = "John Doe";
            var expectedBooks = new List<Book>()
        {
            new Book()
                {
                    BookId = Guid.NewGuid(),
                    Title = "Test",
                    AuthorId = Guid.NewGuid(),
                    Genre = "Action",
                    PubYear = DateTime.UtcNow,
                    Pages = 300,
                    StockBalance = 10,
                    Rating = 4.4m,
                    Summary = "Summary"
                },
                new Book()
                {
                    BookId = Guid.NewGuid(),
                    Title = "Test2",
                    AuthorId = Guid.NewGuid(),
                    Genre = "Comedy",
                    PubYear = DateTime.UtcNow,
                    Pages = 200,
                    StockBalance = 15,
                    Rating = 3.8m,
                    Summary = "Summary"
                }
        };
            _mockBookRepository.Setup(repo => repo.GetBooksByAuthorName(authorName)).ReturnsAsync(expectedBooks);

            // Act
            var result = await _handler.Handle(new GetBookByAuthorNameQuery(authorName), CancellationToken.None);

            // Assert
            _mockBookRepository.Verify(repo => repo.GetBooksByAuthorName(authorName), Times.Once);
            Assert.That(result, Is.EqualTo(expectedBooks));
        }

        [Test]
        public async Task Handle_ShouldReturnEmptyListWhenRepoReturnsNull()
        {
            // Arrange
            var authorName = "John Doe";
            _mockBookRepository.Setup(repo => repo.GetBooksByAuthorName(authorName)).ReturnsAsync((List<Book>)null!);

            // Act
            var result = await _handler.Handle(new GetBookByAuthorNameQuery(authorName), CancellationToken.None);

            // Assert
            _mockBookRepository.Verify(repo => repo.GetBooksByAuthorName(authorName), Times.Once);
            Assert.IsFalse(result != null && !result.Any());
        }

    }
}
