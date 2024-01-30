// GetPurchaseHistoryByUserIdQuery
using System;
using Application.Dtos.PurchaseHistoryDto;
using MediatR;

namespace Application.Queries.PurchaseHistoriesQueries
{
    public class GetPurchaseHistoryByUserIdQuery : IRequest<List<PurchaseHistoryDto>>
    {
        public string UserId { get; }

        public GetPurchaseHistoryByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
