using Application.Queries.BookQueries.GetBookByTitle;
using Domain.Models;
using Infrastructure.Repository.BookRepository;
using Moq;
using NUnit.Framework;

namespace Tests.BookTests.QueryTests
{
    [TestFixture]
    public class GetBookByTitleQueryHandlerTests
    {
        private Mock<IBookRepository> _bookRepositoryMock;
        private GetBookByTitleQueryHandler _handler;


        [SetUp]
        public void SetUp()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _handler = new GetBookByTitleQueryHandler(_bookRepositoryMock.Object);

        }

        [Test]
        public void GetBookByTitleQuery_ShouldCreateInstanceWithTitleSubstring()
        {
            //Arrange
            var titleSubstring = "Harry Potter";

            //Act
            var query = new GetBookByTitleQuery(titleSubstring);

            //Assert
            Assert.That(query.TitleSubstring, Is.EqualTo(titleSubstring));
        }
        [Test]
        public async Task Handle_ShouldReturnCorrectBooks_WhenBooksExists()
        {
            // Arrange
            string titleSubstring = "H";
            var expectedBooks = new List<Book>
            {
                 new Book {BookId = Guid.NewGuid(), Title = "The Hobbit", Rating = 4.5M, ArticleNumber = "article", Genre = "genre", Pages = 10, Price = 10, Summary = "summary", PubYear = DateTime.UtcNow, IsDeleted = false, Author = new Author{ AuthorName = "Author"} }
            };
            _bookRepositoryMock.Setup(repo => repo.GetBooksByTitleContainsAsync(titleSubstring))
                .ReturnsAsync(expectedBooks);

            var query = new GetBookByTitleQuery(titleSubstring);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result.Count, Is.EqualTo(expectedBooks.Count));
            _bookRepositoryMock.Verify(repo => repo.GetBooksByTitleContainsAsync(titleSubstring), Times.Once);
        }

    }
}
