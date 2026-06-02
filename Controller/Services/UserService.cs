using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Controller.Services
{
    public class UserService
    {
        private readonly StoreContext _context;

        public UserService()
        {
            _context = new StoreContext();
        }
        public UserService(StoreContext context)
        {
            _context = context;
        }

        // GET ALL USERS
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Products)
                .Include(u => u.Orders)
                .ToListAsync();
        }

        // GET USER BY ID
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Products)
                .Include(u => u.Orders)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        // CREATE USER
        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }

        // DELETE USER
        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return;
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }
        public async Task<User> Login(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync
                (x => x.Username == username && x.PasswordHash == password);
        }
    }
}
