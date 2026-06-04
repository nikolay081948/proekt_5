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

        public StoreService()
        {
            _context = new StoreContext();
        }
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
            if (store == null)
                throw new Exception("Магазинът е невалиден.");

            if (string.IsNullOrWhiteSpace(store.Name))
                throw new Exception("Въведете име на магазин.");

            if (store.Name.Trim().Length < 3)
                throw new Exception("Името трябва да е поне 3 символа.");

            bool storeExists = await _context.Stores
                .AnyAsync(s => s.Name.ToLower() == store.Name.ToLower());

            if (storeExists)
                throw new Exception("Магазин с това име вече съществува.");

            store.Name = store.Name.Trim();

            await _context.Stores.AddAsync(store);

            await _context.SaveChangesAsync();
        }

        // DELETE STORE
        public async Task DeleteStoreAsync(int id)
        {

            var store = await _context.Stores
        .Include(s => s.Products)
        .FirstOrDefaultAsync(s => s.Id == id);

            if (store == null)
                throw new Exception("Магазинът не е намерен.");

            if (store.Products.Any())
                throw new Exception("Не може да изтриете магазин, който съдържа продукти.");

            _context.Stores.Remove(store);

            await _context.SaveChangesAsync();
        }
    }
}
