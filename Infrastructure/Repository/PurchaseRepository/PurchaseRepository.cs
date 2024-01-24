using Domain.Models;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.PurchaseDetailRepository
{
    public class PurchaseDetailRepository : IPurchaseDetailRepository
    {
        private readonly HarryPotterContext _context;

        public PurchaseDetailRepository(HarryPotterContext context)
        {
            _context = context;
        }

        public async Task<List<PurchaseDetail>> GetAllPurchaseDetailsAsync()
        {
            return await _context.PurchaseDetails.ToListAsync();
        }
    }
}
