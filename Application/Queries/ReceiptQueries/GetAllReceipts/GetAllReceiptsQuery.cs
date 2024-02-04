using Application.Dtos.ReceiptDto;
using MediatR;

namespace Application.Queries.ReceiptQueries.GetAllReceipts
{
    public class GetAllReceiptsQuery : IRequest<List<ReceiptDto>>
    {
        public GetAllReceiptsQuery(Guid ReceiptId)
        {
            Id = ReceiptId;
        }
        public Guid Id { get; }
    }
}
