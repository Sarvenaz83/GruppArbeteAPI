using Domain.Models;

namespace Infrastructure.Repository.BookRepository
{
    public interface IBookRepository
    {
        Task<Book?> GetBookByIdAsync(Guid id);
        Task<List<Book>> GetBooksByAuthorName(string authorName);
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> CreateBookAsync(Book book);
        Task<Book?> UpdateBookByIdAsync(Book updateBook);
        Task<Book?> DeleteBookAsync(Guid bookId);
    }
}
