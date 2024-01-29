using Domain.Models;

namespace Infrastructure.Repository.ReceiptRepository
{
    public interface IReceiptRepository
    {
        Task<List<Receipt>> GetAllReceiptsAsync();
    }
}
