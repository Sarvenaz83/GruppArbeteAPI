using Domain.Models;
using Infrastructure.Repository.ReceiptRepository;
using MediatR;

namespace Application.Queries.ReceiptQueries.GetAllReceipts
{
    public class GetAllReceiptsQueryHandler : IRequestHandler<GetAllReceiptsQuery, List<Receipt>>
    {
        private readonly IReceiptRepository _ReceiptRepository;

        public GetAllReceiptsQueryHandler(IReceiptRepository ReceiptRepository)
        {
            _ReceiptRepository = ReceiptRepository;
        }

        public async Task<List<Receipt>> Handle(GetAllReceiptsQuery request, CancellationToken cancellationToken)
        {
            return await _ReceiptRepository.GetAllReceiptsAsync();
        }
    }
}
