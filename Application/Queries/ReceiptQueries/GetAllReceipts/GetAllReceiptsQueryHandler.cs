using Application.Dtos.ReceiptDto;
using Infrastructure.Repository.ReceiptRepository;
using MediatR;

namespace Application.Queries.ReceiptQueries.GetAllReceipts
{
    public class GetAllReceiptsQueryHandler : IRequestHandler<GetAllReceiptsQuery, List<ReceiptDto>>
    {
        private readonly IReceiptRepository _ReceiptRepository;

        public GetAllReceiptsQueryHandler(IReceiptRepository ReceiptRepository)
        {
            _ReceiptRepository = ReceiptRepository;
        }

        public async Task<List<ReceiptDto>> Handle(GetAllReceiptsQuery request, CancellationToken cancellationToken)
        {
            var recepitList = await _ReceiptRepository.GetAllReceiptsAsync();
            var receipts = recepitList.Select(r => new ReceiptDto
            {
                ReceiptId = r.ReceiptId,
                BookId = r.BookId,
                DateDetail = r.DateDetail,
                Price = r.TotalPrice,
                Quantity = r.Quantity,
            }).ToList();

            return receipts;
        }
    }
}
