using Application.Commands.BookCommands.CreateBook;
using Application.Dtos.BookDtos;
using Domain.Models;
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
                PubYear = DateTime.Now,
                Pages = 200,
                Rating = 4.5m,
                Summary = "Very good book"
            });
            var expectedBookId = Guid.NewGuid();
            _mockBookRepository.Setup(repo => repo.CreateBookAsync(It.IsAny<Book>())).Callback<Book>(book =>
            {
                if (book != null)
                {
                    book.BookId = expectedBookId;
                }

            });

            // Act
            var createdBook = await _handler.Handle(createBookCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(createdBook);
            Assert.That(createdBook.Title, Is.EqualTo(createBookCommand.NewBook.Title));
//            Assert.That(createdBook.Genre, Is.EqualTo(createBookCommand.NewBook.Genre));
//            Assert.That(createdBook.AuthorId, Is.EqualTo(createBookCommand.NewBook.AuthorId));
//            Assert.That(createdBook.PubYear, Is.EqualTo(createBookCommand.NewBook.PubYear));
//            Assert.That(createdBook.Pages, Is.EqualTo(createBookCommand.NewBook.Pages));
//            Assert.That(createdBook.Rating, Is.EqualTo(createBookCommand.NewBook.Rating));
//            Assert.That(createdBook.Summary, Is.EqualTo(createBookCommand.NewBook.Summary));

        }
    }
}
