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
        private Mock<IAuthorRepository> _mockAothorRepository;
        private DeleteAuthorByIdCommandHandler _handler;
        private Guid _testAuthorId;
        private Author _testAuthor;
        private Guid _nonExistentAuthorId;

        [SetUp]
        public void SetUp()
        {
            _mockAothorRepository = new Mock<IAuthorRepository>();
            _handler = new DeleteAuthorByIdCommandHandler(_mockAothorRepository.Object);
            _testAuthorId = Guid.NewGuid();
            _testAuthor = new Author();
            _nonExistentAuthorId = Guid.NewGuid();
        }
        [Test]
        public async Task Handle_ShouldReturnDeletedAuthor_WhenAuthorExists()
        {
            //Arrange
            _mockAothorRepository.Setup(repo => repo.GetAuthorByIdAsync(_testAuthorId)).ReturnsAsync(_testAuthor);

            //Act
            var result = await _handler.Handle(new DeleteAuthorByIdCommand(_testAuthorId), CancellationToken.None);

            //Assert
            Assert.That(result, Is.EqualTo(_testAuthor));
            _mockAothorRepository.Verify(repo => repo.DeleteAuthorByIdAsync(_testAuthorId), Times.Once());
        }
        [Test]
        public async Task Handle_ShouldReturnNull_WhenAuthorDoesNotExists()
        {
            //Arrange
            _mockAothorRepository.Setup(repo => repo.GetAuthorByIdAsync(_nonExistentAuthorId)).ReturnsAsync((Author)null);

            //Act
            var result = await _handler.Handle(new DeleteAuthorByIdCommand(_nonExistentAuthorId), CancellationToken.None);

            //Assert
            Assert.That(result, Is.Null);
            _mockAothorRepository.Verify(repo => repo.DeleteAuthorByIdAsync(_nonExistentAuthorId), Times.Never);
        }

        
    }
}
