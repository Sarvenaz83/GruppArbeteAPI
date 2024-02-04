using Application.Commands.BookCommands.UpdateBook;
using Application.Dtos;
using Application.Dtos.BookDtos;
using Domain.Models;
using Infrastructure.Repository.BookRepository;
using Moq;
using NUnit.Framework;

namespace Tests.BookTests.CommandTests
{
    [TestFixture]
    public class UpdateBookByIdCommandHandlerTests
    {
        private Mock<IBookRepository> _bookRepositoryMock;
        private UpdateBookByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _handler = new UpdateBookByIdCommandHandler(_bookRepositoryMock.Object);
        }
        [Test]
        public async Task Handle_WithValidBookId_UpdatesBookAndReturnsUpdatedBook()
        {
            // Arrange
            var command = new UpdateBookByIdCommand(Guid.NewGuid(), new BookDto
            {
                Title = "Test",
                AuthorId = Guid.NewGuid(),
                Genre = "Genre",
                PubYear = DateTime.UtcNow,
                Pages = 200,
                Rating = 3.4m,
                Summary = "Summary"
            });

            _bookRepositoryMock.Setup(x => x.GetBookByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Book
            {
                BookId = Guid.NewGuid(),
                Title = "Test",
                AuthorId = Guid.NewGuid(),
                Genre = "Genre",
                PubYear = DateTime.UtcNow,
                Pages = 200,
                Rating = 3.4m,
                Summary = "Summary"
            });
            _bookRepositoryMock.Setup(x => x.UpdateBookByIdAsync(It.IsAny<Book>()));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            _bookRepositoryMock.Verify(x => x.UpdateBookByIdAsync(It.Is<Book>(b => b.BookId == result.BookId)), Times.Once);
            _bookRepositoryMock.Verify(x => x.UpdateBookByIdAsync(It.Is<Book>(b => b.Title == result.Title)), Times.Once);
        }

        [Test]
        public async Task Handle_WithInvalidBookId_ReturnsNull()
        {
            // Arrange
            var command = new UpdateBookByIdCommand(Guid.NewGuid(), new BookDto
            {
                Title = "Test",
                AuthorId = Guid.NewGuid(),
                Genre = "Genre",
                PubYear = DateTime.UtcNow,
                Pages = 200,
                Rating = 3.4m,
                Summary = "Summary"
            });

            _bookRepositoryMock.Setup(x => x.GetBookByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Book)null!);
            _bookRepositoryMock.Setup(x => x.UpdateBookByIdAsync(It.IsAny<Book>()));

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            Assert.That(result, Is.Null);
            _bookRepositoryMock.Verify(x => x.GetBookByIdAsync(It.IsAny<Guid>()), Times.Once);
            _bookRepositoryMock.Verify(x => x.UpdateBookByIdAsync(It.IsAny<Book>()), Times.Never);
        }
    }
}
