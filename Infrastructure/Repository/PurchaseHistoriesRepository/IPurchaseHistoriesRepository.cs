using System;
using Domain.Models;

namespace Infrastructure.Repository.PurchaseHistoriesRepository
{
    public interface IPurchaseHistoriesRepository
    {
        Task<List<PurchaseHistory>> GetAllPurchaseHistoriesAsync();
        Task<PurchaseHistory> GetPurchaseHistoryByUserIdAsync(Guid userId);
        Task<PurchaseHistory> CreatePurchaseHistoryAsync(PurchaseHistory purchaseHistory);
        Task<PurchaseHistory> UpdatePurchaseHistoryAsync(PurchaseHistory purchaseHistory);
    }
}

