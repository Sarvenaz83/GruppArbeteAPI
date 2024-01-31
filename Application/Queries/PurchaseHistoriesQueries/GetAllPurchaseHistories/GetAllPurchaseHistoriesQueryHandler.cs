using System;
using Application.Queries.PurchaseHistoriesQueries;
using Domain.Models;
using Infrastructure.Repository.PurchaseHistoriesRepository;
using Infrastructure.Repository.ReceiptRepository;
using MediatR;

namespace Application.Queries.PurchaseHistoriesQueries
{
    public class GetAllPurchaseHistoriesQueryHandler : IRequestHandler<GetAllPurchaseHistoriesQuery, List<PurchaseHistory>>
    {
        private readonly IPurchaseHistoriesRepository _purchaseHistoriesRepository;

        public GetAllPurchaseHistoriesQueryHandler(IPurchaseHistoriesRepository purchaseHistoriesRepository)
        {
            _purchaseHistoriesRepository = purchaseHistoriesRepository;
        }

        public async Task<List<PurchaseHistory>> Handle(GetAllPurchaseHistoriesQuery request, CancellationToken cancellationToken)
        {
            return await _purchaseHistoriesRepository.GetAllPurchaseHistoriesAsync();
        }
    }
}

