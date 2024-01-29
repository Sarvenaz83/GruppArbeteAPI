using Application.Commands.AuthorCommands.UpdateAuthor;
using Application.Dtos;
using Application.Dtos.AuthorDtos;
using Domain.Models;
using Infrastructure.Repository.AuthorRepository;
using Moq;
using NUnit.Framework;

namespace Tests.AuthorTests.CommandTests.AuthorCommandsTests
{
    //The author exists and is updated successfully.
    //The author does not exist.
    //An exception occurs during the update operation.
    public class UpdateAuthorByIdCommandHandlerTest
    {
        private Mock<IAuthorRepository> _mockAuthorRepository;
        private UpdateAuthorByIdCommandHandler _updateAuthorByIdCommandHandler;

        [SetUp]
        public void Setup()
        {
            _mockAuthorRepository = new Mock<IAuthorRepository>();
            _updateAuthorByIdCommandHandler = new UpdateAuthorByIdCommandHandler(_mockAuthorRepository.Object);
        }

        [Test]
        public async Task UpdateAuthorByIdCommandHandler_ShouldReturnUpdatedAuthor_WhenAuthorExists()
        {
            //Arrange
            var authorId = Guid.NewGuid();
            var author = new Author
            {
                AuthorId = authorId,
                AuthorName = "Test Author"
            };

            var updatedAuthorDto = new AuthorDto
            {
                AuthorName = "Updated Author"
            };
            var command = new UpdateAuthorByIdCommand(authorId, updatedAuthorDto);

            _mockAuthorRepository.Setup(repo => repo.GetAuthorByIdAsync(It.IsAny<Guid>())).ReturnsAsync(author);
            _mockAuthorRepository.Setup(repo => repo.UpdateAuthorByIdAsync(It.IsAny<Guid>(), It.IsAny<Author>()))
           .Callback((Guid id, Author a) => author = a)
           .Returns(Task.CompletedTask);

            //Act
            var result = await _updateAuthorByIdCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result.AuthorName, Is.EqualTo(updatedAuthorDto.AuthorName));
        }

        [Test]
        public async Task Handler_ShouldReturnNull_WhenAuthorDoesNotExist()
        {
            var authorId = Guid.NewGuid();
            var updatedAuthorDto = new AuthorDto
            {
                AuthorName = "Updated Author"
            };
            var command = new UpdateAuthorByIdCommand(authorId, updatedAuthorDto);

            _mockAuthorRepository.Setup(repo => repo.GetAuthorByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Author)null!);

            //Act
            var result = await _updateAuthorByIdCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Handler_ShouldThrowException_WhenExceptionOccursDuringUpdate()
        {
            var authorId = Guid.NewGuid();
            var updatedAuthorDto = new AuthorDto
            {
                AuthorName = "Updated Author"
            };
            var command = new UpdateAuthorByIdCommand(authorId, updatedAuthorDto);

            _mockAuthorRepository.Setup(repo => repo.GetAuthorByIdAsync(It.IsAny<Guid>())).Throws(new Exception());


            //Act
            //Assert
            Assert.ThrowsAsync<Exception>(async () => await _updateAuthorByIdCommandHandler.Handle(command, CancellationToken.None));
        }
    }
}
