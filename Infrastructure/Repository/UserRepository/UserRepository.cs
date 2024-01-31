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
            return await _context.Users
                     .Include(u => u.Wallet)
                     .OrderBy(u => u.UserName)
                     .ToListAsync();
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

        public async Task<User> GetByIdAsync(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }
        public async Task<User> DeleteUserAsync(Guid userId)
        {
            try
            {
                User userToDelete = await GetByIdAsync(userId);

                _context.Users.Remove(userToDelete);

                _context.SaveChanges();

                return await Task.FromResult(userToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while deleting a user with Id {userId} from the database", ex);
            }
        }

        public async Task UpdateAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.UserId);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            // Uppdatera egenskaper
            existingUser.SurName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.TelephoneNumber = user.TelephoneNumber;
            // ... uppdatera andra egenskaper ...

            // Markera entiteten som ändrad
            _context.Entry(existingUser).State = EntityState.Modified;

            // Spara ändringarna i databasen
            await _context.SaveChangesAsync();
        }
    }
}
