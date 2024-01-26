// IPurchaseHistoriesRepository
using System;
using Domain.Models;

namespace Infrastructure.Repository.PurchaseHistoriesRepository
{
    public interface IPurchaseHistoriesRepository
    {
        Task<List<PurchaseHistory>> GetAllPurchaseHistoriesAsync();
    }
}

