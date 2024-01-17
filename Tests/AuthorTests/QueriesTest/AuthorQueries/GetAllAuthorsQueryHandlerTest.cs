using Application.Queries.AuthorQueries.GetAllAuthor;
using Domain.Models;
using Infrastructure.Repository.AuthorRepository;
using Moq;
using NUnit.Framework;

namespace Tests.AuthorTests.QueriesTest.AuthorQueries
{
    [TestFixture]
    public class GetAllAuthorsQueryHandlerTest
    {
        private Mock<IAuthorRepository> _mockAuthorRepository;
        private GettAllAuthorsQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mockAuthorRepository = new Mock<IAuthorRepository>();
            _handler = new GettAllAuthorsQueryHandler(_mockAuthorRepository.Object);
        }

        [Test]
        public async Task Handle_ReturnAllAuthors()
        {
            //Arrange
            List<Author> expectedAuthors = new List<Author>()
            {
                new Author()
                {
                    AuthorId = Guid.NewGuid(),
                    AuthorName = "J.K. Rowling"
                },
                new Author()
                {
                    AuthorId = Guid.NewGuid(),
                    AuthorName = "J.R.R. Tolkien"
                }
            };
            _mockAuthorRepository.Setup(authorRepository => authorRepository.GetAllAuthorsAsync())
                .ReturnsAsync(expectedAuthors);

            //Act
            List<Author> actualAuthors = await _handler.Handle(new GetAllAuthorsQuery(), CancellationToken.None);

            //Assert
            Assert.That(actualAuthors, Is.EqualTo(expectedAuthors));
        }

    }
}
