using System;
using Application.Dtos.PurchaseHistoryDto;
using MediatR;

namespace Application.Queries.PurchaseHistoriesQueries
{
    public class GetPurchaseHistoryByUserIdQuery : IRequest<PurchaseHistoryDto>
    {
        public string UserId { get; }

        public GetPurchaseHistoryByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
