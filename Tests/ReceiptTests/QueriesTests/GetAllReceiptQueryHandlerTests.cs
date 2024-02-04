using Application.Queries.ReceiptQueries.GetAllReceipts;
using Domain.Models;
using Infrastructure.Repository.ReceiptRepository;
using Moq;
using NUnit.Framework;

namespace Tests.Queries.ReceiptQueries
{
    [TestFixture]
    public class GetAllReceiptQueryHandlerTests
    {
        private GetAllReceiptsQueryHandler _handler;
        private Mock<IReceiptRepository> _mockReceiptRepository;

        [SetUp]
        public void Setup()
        {
            _mockReceiptRepository = new Mock<IReceiptRepository>();
            _handler = new GetAllReceiptsQueryHandler(_mockReceiptRepository.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnCorrectReceipts_WhenReceiptsExists()
        {
            // Arrange
            var recepitId = Guid.NewGuid();
            var expectedReceipts = new List<Receipt> { /* Fyll i med kvitteringar */ };
            _mockReceiptRepository.Setup(repo => repo.GetAllReceiptsAsync())
                .ReturnsAsync(expectedReceipts);

            var query = new GetAllReceiptsQuery(recepitId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result.Count, Is.EqualTo(expectedReceipts.Count));
            _mockReceiptRepository.Verify(repo => repo.GetAllReceiptsAsync(), Times.Once());
        }
    }
}
