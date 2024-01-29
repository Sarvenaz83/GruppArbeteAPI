using Application.Commands.AuthorCommands.DeleteAuthor;
using Domain.Models;
using Infrastructure.Repository.AuthorRepository;
using Microsoft.Identity.Client;
using Moq;
using NUnit.Framework;

namespace Tests.AuthorTests.CommandTests.AuthorCommandsTests
{
    [TestFixture]
    public class DeleteAuthorByIdCommandHandlerTest
    {
        private Mock<IAuthorRepository> _mockRepository;
        private DeleteAuthorByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IAuthorRepository>();
            _handler = new DeleteAuthorByIdCommandHandler(_mockRepository.Object);
        }

        [Test]
        public async Task WhenAuthorExists_ShouldReturnDeleteAuthorDto()
        {
            // Arrange
            var authorId = Guid.NewGuid();
            var mockAuthor = new Author { AuthorId = authorId, AuthorName = "Test Author" };

            _mockRepository.Setup(repo => repo.DeleteAuthorByIdAsync(authorId))
                           .ReturnsAsync(mockAuthor);

            var command = new DeleteAuthorByIdCommand(authorId); // Uppdaterad för att använda konstruktorn

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.AuthorId, Is.EqualTo(authorId));
            Assert.That(result.AuthorName, Is.EqualTo("Test Author"));
            Assert.IsTrue(result.Message.Contains("has been removed from the database"));
        }

        [Test]
        public void WhenAuthorDoesNotExist_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var authorId = Guid.NewGuid();
            _mockRepository.Setup(repo => repo.DeleteAuthorByIdAsync(authorId))
                           .ReturnsAsync((Author)null);

            var command = new DeleteAuthorByIdCommand(authorId); // Uppdaterad för att använda konstruktorn

            // Act & Assert
            Assert.ThrowsAsync<KeyNotFoundException>(async () => await _handler.Handle(command, CancellationToken.None));
        }
    }
}
