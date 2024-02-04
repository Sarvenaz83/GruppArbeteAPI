using System;
using Domain.Models;
using Infrastructure.DatabaseContext;
using Infrastructure.Repository.PurchaseHistoriesRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.PurchaseHistoriesRepository
{
    public class PurchaseHistoriesRepository : IPurchaseHistoriesRepository
    {
        private readonly HarryPotterContext _context;

        public PurchaseHistoriesRepository(HarryPotterContext context)
        {
            _context = context;
        }

        public async Task<List<PurchaseHistory>> GetAllPurchaseHistoriesAsync()
        {
            return await _context.PurchaseHistories.ToListAsync();
        }

        public async Task<PurchaseHistory> GetPurchaseHistoryByUserIdAsync(Guid userId)
        {
            try
            {
                var purchaseHistories = await _context.PurchaseHistories
                    .Include(ph => ph.Receipts)
                    .Include(ph => ph.User)
                    .Where(ph => ph.UserId == userId)
                    .FirstOrDefaultAsync(x => x.UserId == userId);

                return purchaseHistories;
            }
            catch (Exception ex)
            {
                // Log the error and handle appropriately
                throw new Exception("An error occurred while fetching purchase history.", ex);
            }
        }
        public async Task<PurchaseHistory> CreatePurchaseHistoryAsync(PurchaseHistory purchaseHistory)
        {
            _context.PurchaseHistories.Add(purchaseHistory);
            await _context.SaveChangesAsync();
            return purchaseHistory;
        }

        public async Task<PurchaseHistory> UpdatePurchaseHistoryAsync(PurchaseHistory purchaseHistory)
        {
            _context.PurchaseHistories.Update(purchaseHistory);
            await _context.SaveChangesAsync();
            return purchaseHistory;
        }
    }


}


