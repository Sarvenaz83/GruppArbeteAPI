using Domain.Models;

namespace Infrastructure.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> FindByUsernameAsync(string username);
        Task<User> AddAsync(User userToCreate);
        Task<User> DeleteUser(Guid userId);
        Task<User> GetById(Guid userId);
    }
}