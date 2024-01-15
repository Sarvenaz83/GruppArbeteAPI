using Domain.Models;

namespace Infrastructure.Repository.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author> CreateAuthorAsync(Author author);
        Task<Author?> UpdateAuthorAsync(Guid authorId);
        Task<Author?> DeleteAuthorAsync(Guid authorId);
    }
}
