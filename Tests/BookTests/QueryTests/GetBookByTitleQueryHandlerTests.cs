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
        public async Task Handle_GetBookByTitle_ShouldReturnBooksByTitleSubstring()
        {
            //Arrange
            var titleSubstring = "Harry";
            var testBooks = new List<Book>
            {
                new Book {BookId = Guid.NewGuid(), Title = "Harry Potter and the Sorcerer's Stone", Rating = 4.5M },
                new Book { BookId = Guid.NewGuid(), Title = "The Chamber of Secrets", Rating = 4.0M },
            };
            _bookRepositoryMock.Setup(repo => repo.GetBooksByTitleContainsAsync(It.IsAny<string>()))
                .ReturnsAsync((string startsWith) => testBooks.Where(book => book.Title!.StartsWith(startsWith)).ToList());

            //Act
            var result = await _handler.Handle(new GetBookByTitleQuery(titleSubstring), CancellationToken.None);

            //Assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.IsTrue(result.All(book => book.Title!.StartsWith(titleSubstring)));
        }

    }
}
