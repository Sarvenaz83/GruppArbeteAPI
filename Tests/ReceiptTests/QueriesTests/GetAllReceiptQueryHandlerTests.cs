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
        public async Task Handle_ReturnsListOfPurchaseDetails()
        {
            // Arrange
            var purchaseDetailId = Guid.NewGuid();
            var expectedPurchaseDetails = new List<Receipt>
            {
                new Receipt
                {
                    ReceiptId = purchaseDetailId,
                },
            };

            _mockReceiptRepository.Setup(repo => repo.GetAllReceiptsAsync())
                                         .ReturnsAsync(expectedPurchaseDetails);

            var query = new GetAllReceiptsQuery(ReceiptId: purchaseDetailId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Receipt>>());
            Assert.That(result.Count, Is.EqualTo(expectedPurchaseDetails.Count));
        }
    }
}
