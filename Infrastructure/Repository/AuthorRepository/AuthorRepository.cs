using Domain.Models;
using Infrastructure.DbContexts;
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
