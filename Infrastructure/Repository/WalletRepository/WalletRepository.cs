using Domain.Models;
using Infrastructure.DatabaseContext;

namespace Infrastructure.Repository.WalletRepository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly HarryPotterContext _context;

        public WalletRepository(HarryPotterContext context)
        {
            _context = context;
        }

        public async Task<Wallet> AddAsync(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            await _context.SaveChangesAsync();
            return wallet;
        }
    }
}
