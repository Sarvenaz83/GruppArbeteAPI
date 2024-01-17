using Application.Queries.BookQueries.GetAllBooks;
using Domain.Models;
using Infrastructure.Repository.BookRepository;
using Moq;
using NUnit.Framework;

namespace Tests.BookTests
{
    [TestFixture]
    public class GetAllBooksQueryHandlerTest
    {
        private Mock<IBookRepository> _mockBookRepository;
        private GetAllBooksQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _handler = new GetAllBooksQueryHandler(_mockBookRepository.Object);
        }

        [Test]
        public async Task Handle_ReturnAllBooks()
        {
            //Arrange
            List<Book> expectedBooks = new List<Book>()
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
            _mockBookRepository.Setup(bookRepository => bookRepository.GetAllBooksAsync())
                .ReturnsAsync(expectedBooks);

            //Act
            List<Book> actualBooks = await _handler.Handle(new GetAllBooksQuery(), CancellationToken.None);

            //Assert
            Assert.That(actualBooks, Is.EqualTo(expectedBooks));
        }
    }
}
