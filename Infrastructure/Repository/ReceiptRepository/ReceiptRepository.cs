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
        public async Task<Receipt> CreateReceiptAsync(Receipt receipt)
        {
            _context.Receipts.Add(receipt);
            await _context.SaveChangesAsync();
            return receipt;
        }

        public async Task<Receipt> GetReceiptByIdAsync(Guid receiptId)
        {
            return await _context.Receipts.FirstOrDefaultAsync(r => r.ReceiptId == receiptId);
        }
    }
}
