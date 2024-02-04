using Domain.Models;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Wallet> UpdateBalance(Guid userId, int updatedBalance)
        {
            var wallet = await _context.Wallets
                           .FirstOrDefaultAsync(w => w.UserId == userId);

            if (wallet != null)
            {
                wallet.Balance = updatedBalance;
                _context.Update(wallet);
                await _context.SaveChangesAsync();
                return wallet;
            }
            else
            {
                throw new Exception("Wallet not found.");
            }
        }

        public async Task<Wallet> GetWalletByUserIdAsync(Guid userId)
        {
            var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
            if (wallet == null)
            {
                throw new Exception("Wallet not found.");
            }
            return wallet;
        }
    }
}
