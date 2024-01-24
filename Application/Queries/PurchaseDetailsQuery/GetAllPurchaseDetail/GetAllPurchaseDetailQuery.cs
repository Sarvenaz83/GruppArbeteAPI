using Domain.Models;
using MediatR;

namespace Application.Queries.PurchaseDetailQueries.GetAllPurchaseDetails
{
    public class GetAllPurchaseDetailQuery : IRequest<List<PurchaseDetail>>
    {
        public GetAllPurchaseDetailQuery(Guid PurchaseDetailId)
        {
            Id = PurchaseDetailId;
        }
        public Guid Id { get; }
    }
}
