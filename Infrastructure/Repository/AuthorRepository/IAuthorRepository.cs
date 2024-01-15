

using Domain.Models;

namespace Infrastructure.Repository.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthorsAsync();

    }
}
