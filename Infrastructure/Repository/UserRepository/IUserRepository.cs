using Domain.Models;

namespace Infrastructure.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<User> FindByUsernameAsync(string username);
        Task<User> AddAsync(User userToCreate);
    }
}