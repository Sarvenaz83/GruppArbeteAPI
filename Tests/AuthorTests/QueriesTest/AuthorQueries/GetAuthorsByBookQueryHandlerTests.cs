using Application.Dtos.AuthorDtos;
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
            var expectedAuthor = new Author { AuthorName = "Test Author" };
            _mockAuthorRepository.Setup(repo => repo.GetAuthorByBookAsync(It.IsAny<string>())).ReturnsAsync(expectedAuthor);

            var query = new GetAuthorByBookQuery("Some Book Title");
            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            Assert.That(result.AuthorName, Is.EqualTo(expectedAuthor.AuthorName));
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
