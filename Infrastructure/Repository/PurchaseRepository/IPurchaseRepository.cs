using Domain.Models;

namespace Infrastructure.Repository.PurchaseDetailRepository
{
    public interface IPurchaseDetailRepository
    {
        Task<List<PurchaseDetail>> GetAllPurchaseDetailsAsync();
    }
}
