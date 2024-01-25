using Application.Queries.AuthorQueries.GetAuthorByBook;
using Domain.Models;
using Infrastructure.Repository.AuthorRepository;
using Moq;
using NUnit.Framework;

namespace Tests.AuthorTests.QueryTests
{
    [TestFixture]
    public class GetAuthorByBookQueryHandlerTests
    {
        private Mock<IAuthorRepository> _mockAuthorRepository;
        private GetAuthorByBookQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockAuthorRepository = new Mock<IAuthorRepository>();
            _handler = new GetAuthorByBookQueryHandler(_mockAuthorRepository.Object);
        }

        [Test]
        public async Task Handle_ShouldCallGetAuthorByBookAsyncOnceWithCorrectParameters()
        {
            // Arrange
            var bookTitle = "Test Book";
            var expectedAuthor = new Author
            {
                AuthorId = Guid.NewGuid(),
                AuthorName = "John Doe",
            };
            _mockAuthorRepository.Setup(repo => repo.GetAuthorByBookAsync(bookTitle)).ReturnsAsync(expectedAuthor);

            // Act
            var result = await _handler.Handle(new GetAuthorByBookQuery(bookTitle), CancellationToken.None);

            // Assert
            _mockAuthorRepository.Verify(repo => repo.GetAuthorByBookAsync(bookTitle), Times.Once);
            Assert.That(result, Is.EqualTo(expectedAuthor));
        }

        [Test]
        public async Task Handle_ShouldReturnNullWhenRepoReturnsNull()
        {
            // Arrange
            var bookTitle = "Nonexistent Book";
            _mockAuthorRepository.Setup(repo => repo.GetAuthorByBookAsync(bookTitle)).ReturnsAsync((Author)null!);

            // Act
            var result = await _handler.Handle(new GetAuthorByBookQuery(bookTitle), CancellationToken.None);

            // Assert
            _mockAuthorRepository.Verify(repo => repo.GetAuthorByBookAsync(bookTitle), Times.Once);
            Assert.IsNull(result);
        }
    }
}
