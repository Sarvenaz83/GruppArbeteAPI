using Domain.Models;

namespace Infrastructure.Repository.WalletRepository
{
    public interface IWalletRepository
    {
        Task<Wallet> AddAsync(Wallet wallet);
        Task<Wallet> UpdateBalance(Guid userId, int balance);
        Task<Wallet> GetWalletByUserIdAsync(Guid userId);
    }
}