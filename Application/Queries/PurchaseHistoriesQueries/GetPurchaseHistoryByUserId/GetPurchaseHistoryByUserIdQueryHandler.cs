
using Application.Dtos.PurchaseHistoryDto;
using Application.Dtos.ReceiptDto;
using MediatR;
using Infrastructure.Repository.PurchaseHistoriesRepository;



namespace Application.Queries.PurchaseHistoriesQueries
{
    public class GetPurchaseHistoryByUserIdQueryHandler : IRequestHandler<GetPurchaseHistoryByUserIdQuery, List<PurchaseHistoryDto>>
    {
        private readonly IPurchaseHistoriesRepository _purchaseHistoriesRepository;

        public GetPurchaseHistoryByUserIdQueryHandler(IPurchaseHistoriesRepository purchaseHistoriesRepository)
        {
            _purchaseHistoriesRepository = purchaseHistoriesRepository;
        }

        public async Task<List<PurchaseHistoryDto>> Handle(GetPurchaseHistoryByUserIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = new Guid(request.UserId);
                var purchaseHistories = await _purchaseHistoriesRepository.GetPurchaseHistoryByUserIdAsync(userId);

                var purchaseHistoryDto = purchaseHistories.Select(ph => new PurchaseHistoryDto
                {
                    PurchaseHistoryId = ph.PurchaseHistoryId,
                    UserId = ph.UserId,

                    Receipts = ph.Receipts.Select(r => new ReceiptDto
                    {
                        ReceiptId = r.ReceiptId,
                        BookId = r.BookId,
                        DateDetail = r.DateDetail,
                        PricePerUnit = r.PricePerUnit,
                        Quantity = r.Quantity
                    }).ToList(),
                }).ToList();

                return purchaseHistoryDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching purchase history.", ex);
            }
        }


    }
}
