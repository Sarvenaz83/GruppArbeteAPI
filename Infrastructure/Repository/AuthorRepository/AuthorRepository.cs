using Domain.Models;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.AuthorRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly HarryPotterContext _context;

        public AuthorRepository(HarryPotterContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> CreateAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author?> UpdateAuthorAsync(Guid id)
        {
            Author? authorToUpdate = await _context.Authors.FirstOrDefaultAsync(author => author.AuthorId == id);
            if (authorToUpdate != null)
            {
                _context.Authors.Update(authorToUpdate);
                await _context.SaveChangesAsync();
                return authorToUpdate;
            }
            return null;
        }

        public async Task<Author?> DeleteAuthorAsync(Guid id)
        {
            Author? authorToDelete = await _context.Authors.FirstOrDefaultAsync(author => author.AuthorId == id);
            if (authorToDelete != null)
            {
                _context.Authors.Remove(authorToDelete);
                await _context.SaveChangesAsync();
                return authorToDelete;
            }
            return null;
        }
    }
}
