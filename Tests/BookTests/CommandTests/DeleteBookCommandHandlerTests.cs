using Application.Commands.BookCommands.DeleteBook;
using Domain.Models;
using Infrastructure.Repository.BookRepository;
using Moq;
using NUnit.Framework;

namespace Tests.Commands.BookCommands
{
    [TestFixture]
    public class DeleteBookCommandHandlerTests
    {
        private DeleteBookCommandHandler _handler;
        private Mock<IBookRepository> _mockBookRepository;

        [SetUp]
        public void Setup()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _handler = new DeleteBookCommandHandler(_mockBookRepository.Object);
        }

        [Test]
        public async Task Handle_DeletesBookFromRepository()
        {
            // Arrange
            var bookIdToDelete = Guid.NewGuid();
            var deleteBookCommand = new DeleteBookCommand(bookIdToDelete);

            _mockBookRepository.Setup(repo => repo.DeleteBookAsync(bookIdToDelete))
                               .ReturnsAsync(new Book
                               {
                                   BookId = bookIdToDelete,
                                   Title = "Deleted Book",
                               });

            // Act
            var deletedBook = await _handler.Handle(deleteBookCommand, CancellationToken.None);

            // Assert
            Assert.That(deletedBook, Is.Not.Null);
            Assert.That(deletedBook.BookId, Is.EqualTo(bookIdToDelete));
        }

        [Test]
        public async Task Handle_BookNotFound_ReturnsNull()
        {
            // Arrange
            var bookIdToDelete = Guid.NewGuid();
            var deleteBookCommand = new DeleteBookCommand(bookIdToDelete);

            _mockBookRepository.Setup(repo => repo.DeleteBookAsync(bookIdToDelete))
                               .ReturnsAsync(null as Book);

            // Act
            var deletedBook = await _handler.Handle(deleteBookCommand, CancellationToken.None);

            // Assert
            Assert.That(deletedBook, Is.Null);
        }
    }
}
