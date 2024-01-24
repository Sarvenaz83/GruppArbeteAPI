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
        private decimal _testRating;
        private List<Book> _testBooks;

        [SetUp]
        public void SetUp()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _handler = new GetBooksByRatingQueryHandler(_bookRepositoryMock.Object);
            _testRating = 3.5M;
            _testBooks = new List<Book>
            {
                new Book {Rating = _testRating},
                new Book {Rating = _testRating + 0.1M},
                new Book {Rating = _testRating - 0.1M}
            };
        }

        [Test]
        public async Task Handle_ShouldReturnBooks_WhenBooksWithRatingExisi()
        {
            // Arrange
            _bookRepositoryMock.Setup(repo => repo.GetBooksByRatingAsync(_testRating)).ReturnsAsync(_testBooks);

            // Act
            var result = await _handler.Handle(new GetBooksByRatingQuery(_testRating), CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(_testBooks));
        }

        [Test]
        public async Task Handle_ShouldReturnEmptyList_WhenNoBooksWithRatingExist()
        {
            //Arrange
            _bookRepositoryMock.Setup(repo => repo.GetBooksByRatingAsync(_testRating)).ReturnsAsync(new List<Book>());

            //Act
            var result = await _handler.Handle(new GetBooksByRatingQuery(_testRating), CancellationToken.None);

            //Assert
            Assert.That(result, Is.Empty);
        }
    }
}
