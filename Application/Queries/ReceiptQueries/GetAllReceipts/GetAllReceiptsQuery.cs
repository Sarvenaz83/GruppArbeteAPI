using Domain.Models;
using MediatR;

namespace Application.Queries.ReceiptQueries.GetAllReceipts
{
    public class GetAllReceiptsQuery : IRequest<List<Receipt>>
    {
        public GetAllReceiptsQuery(Guid ReceiptId)
        {
            Id = ReceiptId;
        }
        public Guid Id { get; }
    }
}
