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
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new Exception("Потребителското име е задължително.");

            if (string.IsNullOrWhiteSpace(user.Email))
                throw new Exception("Имейлът е задължителен.");

            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                throw new Exception("Паролата е задължителна.");

            if (await _context.Users.AnyAsync(x => x.Username == user.Username))
                throw new Exception("Потребителското име вече съществува.");

            if (await _context.Users.AnyAsync(x => x.Email == user.Email))
                throw new Exception("Имейлът вече е регистриран.");

           
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
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Въведете потребителско име.");

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Въведете парола.");

            return await _context.Users.FirstOrDefaultAsync
                (x => x.Username == username && x.PasswordHash == password);
        }
    }
}
