using Domain.Models;
using Infrastructure.Repository.PurchaseDetailRepository;
using MediatR;

namespace Application.Queries.PurchaseDetailQueries.GetAllPurchaseDetails
{
    public class GetAllPurchaseDetailQueryHandler : IRequestHandler<GetAllPurchaseDetailQuery, List<PurchaseDetail>>
    {
        private readonly IPurchaseDetailRepository _purchaseDetailRepository;

        public GetAllPurchaseDetailQueryHandler(IPurchaseDetailRepository purchaseDetailRepository)
        {
            _purchaseDetailRepository = purchaseDetailRepository;
        }

        public async Task<List<PurchaseDetail>> Handle(GetAllPurchaseDetailQuery request, CancellationToken cancellationToken)
        {
            return await _purchaseDetailRepository.GetAllPurchaseDetailsAsync();
        }
    }
}
