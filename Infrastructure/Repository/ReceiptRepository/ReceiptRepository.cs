using Domain.Models;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.ReceiptRepository
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly HarryPotterContext _context;

        public ReceiptRepository(HarryPotterContext context)
        {
            _context = context;
        }

        public async Task<List<Receipt>> GetAllReceiptsAsync()
        {
            return await _context.Receipts.ToListAsync();
        }
    }
}
