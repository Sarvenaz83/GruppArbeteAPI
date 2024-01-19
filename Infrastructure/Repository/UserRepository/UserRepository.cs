using Domain.Models;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly HarryPotterContext _context;

        public UserRepository(HarryPotterContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> AddAsync(User userToCreate)
        {
            _context.Users.Add(userToCreate);
            _context.SaveChanges();
            return await Task.FromResult(userToCreate);
        }
        public async Task<User> FindByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username can not be null or empty.", nameof(username));
            }
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == username.ToLower());
        }

        public async Task<User> GetById(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }
        public async Task<User> DeleteUser(Guid userId)
        {
            try
            {
                User userToDelete = await GetById(userId);

                _context.Users.Remove(userToDelete);

                _context.SaveChanges();

                return await Task.FromResult(userToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while deleting a user with Id {userId} from the database", ex);
            }
        }

    }
}
