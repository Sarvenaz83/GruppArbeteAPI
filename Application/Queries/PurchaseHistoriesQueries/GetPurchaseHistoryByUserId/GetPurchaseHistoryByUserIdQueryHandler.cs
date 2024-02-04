
using Application.Dtos.PurchaseHistoryDto;
using Application.Dtos.ReceiptDto;
using MediatR;
using Infrastructure.Repository.PurchaseHistoriesRepository;



namespace Application.Queries.PurchaseHistoriesQueries
{
    public class GetPurchaseHistoryByUserIdQueryHandler : IRequestHandler<GetPurchaseHistoryByUserIdQuery, PurchaseHistoryDto>
    {
        private readonly IPurchaseHistoriesRepository _purchaseHistoriesRepository;

        public GetPurchaseHistoryByUserIdQueryHandler(IPurchaseHistoriesRepository purchaseHistoriesRepository)
        {
            _purchaseHistoriesRepository = purchaseHistoriesRepository;
        }

        public async Task<PurchaseHistoryDto> Handle(GetPurchaseHistoryByUserIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = new Guid(request.UserId);
                var purchaseHistories = await _purchaseHistoriesRepository.GetPurchaseHistoryByUserIdAsync(userId);

                var purchaseHistoryDto = new PurchaseHistoryDto
                {
                    PurchaseHistoryId = purchaseHistories.PurchaseHistoryId,
                    UserId = purchaseHistories.UserId,
                    Receipts = purchaseHistories.Receipts.Select(r => new ReceiptDto
                    {
                        ReceiptId = r.ReceiptId,
                        BookId = r.BookId,
                        Quantity = r.Quantity,
                        DateDetail = r.DateDetail

                    }).ToList()
                };

                return purchaseHistoryDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching purchase history.", ex);
            }
        }



    }
}
