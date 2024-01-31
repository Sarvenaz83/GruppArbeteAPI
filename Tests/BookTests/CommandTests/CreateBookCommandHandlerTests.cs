using Application.Commands.BookCommands.CreateBook;
using Application.Dtos.BookDtos;
using Infrastructure.Repository.BookRepository;
using Moq;
using NUnit.Framework;

namespace Tests.Commands.BookCommands
{
    [TestFixture]
    public class AddBookCommandHandlerTests
    {
        private AddBookCommandHandler _handler;
        private Mock<IBookRepository> _mockBookRepository;

        [SetUp]
        public void Setup()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _handler = new AddBookCommandHandler(_mockBookRepository.Object);
        }

        [Test]
        public async Task Handle_AddsBookToRepository()
        {
            // Arrange
            var createBookCommand = new CreateBookCommand(new BookDto
            {
                Title = "Harry Potter",
                Genre = "Fantasy",
                AuthorId = Guid.NewGuid(),
                PubYear = DateTime.Now,
                Pages = 200,
                StockBalance = 10,
                Rating = 4.5m,
                Summary = "Very good book"
            });

            // Act
            var createdBook = await _handler.Handle(createBookCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(createdBook);
            Assert.That(createdBook.Title, Is.EqualTo(createBookCommand.NewBook.Title));
            Assert.That(createdBook.Genre, Is.EqualTo(createBookCommand.NewBook.Genre));
            Assert.That(createdBook.AuthorId, Is.EqualTo(createBookCommand.NewBook.AuthorId));
            Assert.That(createdBook.PubYear, Is.EqualTo(createBookCommand.NewBook.PubYear));
            Assert.That(createdBook.Pages, Is.EqualTo(createBookCommand.NewBook.Pages));
            Assert.That(createdBook.StockBalance, Is.EqualTo(createBookCommand.NewBook.StockBalance));
            Assert.That(createdBook.Rating, Is.EqualTo(createBookCommand.NewBook.Rating));
            Assert.That(createdBook.Summary, Is.EqualTo(createBookCommand.NewBook.Summary));

        }
    }
}
