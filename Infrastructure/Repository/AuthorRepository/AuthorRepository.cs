using Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.AuthorRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly HarryPotterContext _harrypotterContext;
        public AuthorRepository(HarryPotterContext context)
        {
            _harrypotterContext = context;
        }
        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _harrypotterContext.Authors.ToListAsync();
        }

    }
    
}
