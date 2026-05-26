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
    public class StoreService
    {
        private readonly StoreContext _context;

        public StoreService(StoreContext context)
        {
            _context = context;
        }

        // GET ALL STORES
        public async Task<List<Store>> GetAllStoresAsync()
        {
            return await _context.Stores
                .Include(s => s.Products)
                .ToListAsync();
        }

        // GET STORE BY ID
        public async Task<Store?> GetStoreByIdAsync(int id)
        {
            return await _context.Stores
                .Include(s => s.Products)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // CREATE STORE
        public async Task CreateStoreAsync(Store store)
        {
            await _context.Stores.AddAsync(store);

            await _context.SaveChangesAsync();
        }

        // DELETE STORE
        public async Task DeleteStoreAsync(int id)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null)
            {
                return;
            }

            _context.Stores.Remove(store);

            await _context.SaveChangesAsync();
        }
    }
}
