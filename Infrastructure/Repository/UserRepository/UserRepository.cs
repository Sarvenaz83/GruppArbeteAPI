using Domain.Models;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly HarryPotterContext _context;
        public UserRepository(HarryPotterContext context)
        {
            _context = context;
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
    }
}
