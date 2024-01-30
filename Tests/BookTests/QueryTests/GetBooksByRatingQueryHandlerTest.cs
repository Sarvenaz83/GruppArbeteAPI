using Application.Dtos;
using Application.Queries.BookQueries.GetBooksByRating;
using Domain.Models;
using Infrastructure.Repository.BookRepository;
using Moq;
using NUnit.Framework;

namespace Tests.BookTests.QueryTests
{
    [TestFixture]
    public class GetBooksByRatingQueryHandlerTest
    {
        private Mock<IBookRepository> _bookRepositoryMock;
        private GetBooksByRatingQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _handler = new GetBooksByRatingQueryHandler(_bookRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnBooks_WhenBooksWithRatingExisi()
        {
            // Arrange
            var expectedBooks = new List<Book>
            {
                new Book { Title = "Book1", Rating = 4, Author = new Author { AuthorName = "Author1" } },
                new Book { Title = "Book2", Rating = 5, Author = new Author { AuthorName = "Author2" } }
            };

            _bookRepositoryMock.Setup(r => r.GetBooksByRatingAsync(It.IsAny<decimal>())).ReturnsAsync(expectedBooks);
            var query = new GetBooksByRatingQuery(4);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Has.Count.EqualTo(expectedBooks.Count));
            _bookRepositoryMock.Verify(r => r.GetBooksByRatingAsync(It.IsAny<decimal>()), Times.Once());
        }

        [Test]
        public async Task Handle_ShouldReturnEmptyList_WhenNoBooksWithRatingExist()
        {
            //Arrange
            _bookRepositoryMock.Setup(r => r.GetBooksByRatingAsync(It.IsAny<decimal>())).ReturnsAsync(new List<Book>());
            var query = new GetBooksByRatingQuery(3);

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Null);
        }
    }
}
