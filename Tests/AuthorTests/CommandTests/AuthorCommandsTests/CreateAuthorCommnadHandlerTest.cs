using Application.Commands.AuthorCommands.CreateAuthor;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Repository.AuthorRepository;
using Moq;
using NUnit.Framework;

namespace Tests.AuthorTests.CommandTests.AuthorCommandsTests
{
    [TestFixture]
    public class CreateAuthorCommnadHandlerTest
    {
        private Mock<IAuthorRepository> _mockAuthorRepo;
        private CreateAuthorCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mockAuthorRepo = new Mock<IAuthorRepository>();
            _handler = new CreateAuthorCommandHandler(_mockAuthorRepo.Object);
        }

        [Test]
        public async Task CreateAuthorCommandHandler_ShouldReturnAuthor_WhenAuthorIsCreated()
        {
            // Arrange
            var newAuthor = new AuthorDto
            {
                AuthorName = "New Author"
            };
            var author = new Author
            {
                AuthorName = newAuthor.AuthorName
            };
            _mockAuthorRepo.Setup(x => x.CreateAuthorAsync(It.IsAny<Author>())).ReturnsAsync(author);

            // Act
            var result = await _handler.Handle(new CreateAuthorCommand(newAuthor), new CancellationToken());

            // Assert
            Assert.That(result, Is.TypeOf<Author>());
            Assert.That(result.AuthorName, Is.EqualTo(newAuthor.AuthorName));
        }
    }
}
