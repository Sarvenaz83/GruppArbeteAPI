using Domain.Models;
using Infrastructure.DatabaseContext;
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

        public async Task<List<PurchaseHistory>> GetPurchaseHistoryByUserIdAsync(Guid userId)
        {
            try
            {
                var purchaseHistories = await _context.PurchaseHistories
                    .Include(ph => ph.Receipts)
                    .Include(ph => ph.User)
                    .Where(ph => ph.UserId == userId)
                    .ToListAsync();

                return purchaseHistories;
            }
            catch (Exception ex)
            {
                // Log the error and handle appropriately
                throw new Exception("An error occurred while fetching purchase history.", ex);
            }
        }
    }

}


