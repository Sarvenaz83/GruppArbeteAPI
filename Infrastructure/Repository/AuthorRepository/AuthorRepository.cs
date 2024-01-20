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

        public async Task<Author?> GetAuthorByIdAsync(Guid id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task<Author> CreateAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task UpdateAuthorByIdAsync(Guid id, Author updatedAuthor)
        {
            _context.Entry(updatedAuthor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorByIdAsync(Guid authorId)
        {
            var authorToDelete = await _context.Authors.FindAsync(authorId);
            if (authorToDelete != null)
            {
                _context.Authors.Remove(authorToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
