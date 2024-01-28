using System;
using Domain.Models;
using Infrastructure.DatabaseContext;
using Infrastructure.Repository.PurchaseHistoriesRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.PurchaseHistoriesRepository
{
    public class PurchaseHistoriesRepository : IPurchaseHistoriesRepository
    {
        private readonly HarryPotterContext _context;

        public PurchaseHistoriesRepository(HarryPotterContext context)
        {
            _context = context;
        }

        public async Task<List<PurchaseHistory>> GetAllPurchaseHistoriesAsync()
        {
            return await _context.PurchaseHistories.ToListAsync();
        }
    }
}

