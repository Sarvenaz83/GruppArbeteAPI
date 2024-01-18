using Domain.Models;

namespace Infrastructure.Repository.WalletRepository
{
    public interface IWalletRepository
    {
        Task<Wallet> AddAsync(Wallet wallet);
    }
}