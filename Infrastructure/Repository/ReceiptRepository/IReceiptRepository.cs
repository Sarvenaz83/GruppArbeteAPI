using Domain.Models;

namespace Infrastructure.Repository.ReceiptRepository
{
    public interface IReceiptRepository
    {
        Task<List<Receipt>> GetAllReceiptsAsync();
        Task<Receipt> CreateReceiptAsync(Receipt receipt);
        Task<Receipt> GetReceiptByIdAsync(Guid receiptId);
    }
}
