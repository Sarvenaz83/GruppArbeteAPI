using Domain.Models;

namespace Infrastructure.Repository.BookRepository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> CreateBookAsync(Book book);
        Task<Book?> UpdateBookAsync(Guid bookId);
        Task<Book?> DeleteBookAsync(Guid bookId);
    }
}
