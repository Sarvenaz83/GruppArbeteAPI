using System;
using Domain.Models;
using MediatR;

namespace Application.Queries.PurchaseHistoriesQueries
{
    public class GetAllPurchaseHistoriesQuery : IRequest<List<PurchaseHistory>>
    {
        public GetAllPurchaseHistoriesQuery() //byta till tydligare namngivning?förvirrande med History och details
        {

        }

    }
}

