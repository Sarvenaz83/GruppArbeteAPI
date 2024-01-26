using Application.Queries.PurchaseDetailQueries.GetAllPurchaseDetails;
using Domain.Models;
using Infrastructure.Repository.PurchaseDetailRepository;
using Moq;
using NUnit.Framework;

namespace Tests.Queries.PurchaseDetailQueries
{
    [TestFixture]
    public class GetAllPurchaseDetailQueryHandlerTests
    {
        private GetAllPurchaseDetailQueryHandler _handler;
        private Mock<IPurchaseDetailRepository> _mockPurchaseDetailRepository;

        [SetUp]
        public void Setup()
        {
            _mockPurchaseDetailRepository = new Mock<IPurchaseDetailRepository>();
            _handler = new GetAllPurchaseDetailQueryHandler(_mockPurchaseDetailRepository.Object);
        }

        [Test]
        public async Task Handle_ReturnsListOfPurchaseDetails()
        {
            // Arrange
            var purchaseDetailId = Guid.NewGuid();
            var expectedPurchaseDetails = new List<PurchaseDetail>
            {
                new PurchaseDetail
                {
                    PurchaseDetailId = purchaseDetailId,
                },
            };

            _mockPurchaseDetailRepository.Setup(repo => repo.GetAllPurchaseDetailsAsync())
                                         .ReturnsAsync(expectedPurchaseDetails);

            var query = new GetAllPurchaseDetailQuery(PurchaseDetailId: purchaseDetailId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<PurchaseDetail>>());
            Assert.That(result.Count, Is.EqualTo(expectedPurchaseDetails.Count));
        }
    }
}
