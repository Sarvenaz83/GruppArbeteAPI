using Domain.Models;

namespace Infrastructure.Repository.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author?> GetAuthorByIdAsync(Guid id);
        Task<Author> CreateAuthorAsync(Author author);
        Task UpdateAuthorByIdAsync(Guid authorId, Author updatedAuthor);
        Task<Author?> DeleteAuthorByIdAsync(Guid authorId);
        Task<Author?> GetAuthorByBookAsync(string title);
    }
}
