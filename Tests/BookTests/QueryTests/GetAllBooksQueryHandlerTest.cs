using Application.Dtos.BookDtos;
using Application.Queries.BookQueries.GetAllBooks;
using Domain.Models;
using Infrastructure.Repository.BookRepository;
using Moq;
using NUnit.Framework;

namespace Tests.BookTests.QueryTests
{
    [TestFixture]
    public class GetAllBooksQueryHandlerTests
    {
        private Mock<IBookRepository> _bookRepositoryMock;
        private GetAllBooksQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _handler = new GetAllBooksQueryHandler(_bookRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ReturnsListOfGetAllBooksDto()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book
                {
                    Title = "Book 1",
                    Author = new Author { AuthorName = "Author 1" },
                    Genre = "Genre 1",
                    PubYear = DateTime.UtcNow,
                    Pages = 200,
                    Rating = 4.5m,
                    Summary = "Summary 1"
                },
                new Book
                {
                    Title = "Book 2",
                    Author = new Author { AuthorName = "Author 2" },
                    Genre = "Genre 2",
                    PubYear = DateTime.UtcNow,
                    Pages = 250,
                    Rating = 4.7m,
                    Summary = "Summary 2"
                }
            };

            _bookRepositoryMock.Setup(repo => repo.GetAllBooksAsync()).ReturnsAsync(books);

            var request = new GetAllBooksQuery();

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<GetAllBooksDto>>(result);
            Assert.That(result.Count, Is.EqualTo(2));

            var firstBookDto = result.First();
            Assert.That(firstBookDto.Title, Is.EqualTo("Book 1"));
            Assert.That(firstBookDto.AuthorName, Is.EqualTo("Author 1"));
            Assert.That(firstBookDto.Genre, Is.EqualTo("Genre 1"));
            Assert.That(firstBookDto.Pages, Is.EqualTo(200));
            Assert.That(firstBookDto.Rating, Is.EqualTo(4.5));
            Assert.That(firstBookDto.Summary, Is.EqualTo("Summary 1"));

            var secondBookDto = result.Skip(1).First();
            Assert.That(secondBookDto.Title, Is.EqualTo("Book 2"));
            Assert.That(secondBookDto.AuthorName, Is.EqualTo("Author 2"));
            Assert.That(secondBookDto.Genre, Is.EqualTo("Genre 2"));
            Assert.That(secondBookDto.Pages, Is.EqualTo(250));
            Assert.That(secondBookDto.Rating, Is.EqualTo(4.7));
            Assert.That(secondBookDto.Summary, Is.EqualTo("Summary 2"));
        }

        [Test]
        public void Handle_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            _bookRepositoryMock.Setup(repo => repo.GetAllBooksAsync()).ThrowsAsync(new Exception("Simulated repository exception"));
            var request = new GetAllBooksQuery();

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await _handler.Handle(request, CancellationToken.None));
        }
    }
}
