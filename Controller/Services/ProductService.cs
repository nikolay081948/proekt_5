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
    public class ProductService
    {
        private readonly StoreContext _context;

        public ProductService(StoreContext context)
        {
            _context = context;
        }

        // GET ALL PRODUCTS
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Seller)
                .Include(p => p.Store)
                .Include(p => p.Orders)
                .ToListAsync();
        }
        public async Task<List<Product>> GetAllProductsByStoreIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Seller)
                .Include(p => p.Store)
                .Include(p => p.Orders)
                .Where(s=>s.Store.Id==id)
                .ToListAsync();
        }

        // GET PRODUCT BY ID
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Seller)
                .Include(p => p.Store)
                .Include(p => p.Orders)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // ADD PRODUCT
        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();
        }

        // DELETE PRODUCT
        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return;
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }
    }
}
