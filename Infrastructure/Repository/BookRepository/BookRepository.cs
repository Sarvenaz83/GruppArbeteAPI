using Domain.Models;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly HarryPotterContext _context;

        public BookRepository(HarryPotterContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var bookList = await _context.Books.OrderBy(book => book.Title).ToListAsync();
            return bookList;
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> UpdateBookAsync(Guid bookId)
        {
            Book? bookToUpdate = await _context.Books.FirstOrDefaultAsync(book => book.BookId == bookId);
            if (bookToUpdate != null)
            {
                _context.Books.Update(bookToUpdate);
                await _context.SaveChangesAsync();
                return bookToUpdate;
            }
            return null;
        }

        public async Task<Book?> DeleteBookAsync(Guid bookId)
        {
            Book? bookToDelete = await _context.Books.FirstOrDefaultAsync(book => book.BookId == bookId);
            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
                await _context.SaveChangesAsync();
                return bookToDelete;
            }
            return null;
        }
    }
}
