using Domain.Models;

namespace Infrastructure.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> FindByUsernameAsync(string username);
        Task<User> AddAsync(User userToCreate);
        Task<User> DeleteUserAsync(Guid userId);
        Task<User> GetByIdAsync(Guid userId);
        Task UpdateAsync(User user);
    }
}