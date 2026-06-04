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

        public ProductService()
        {
            _context = new StoreContext();
        }
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
            if (product == null)
                throw new Exception("Невалиден продукт.");

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new Exception("Въведете име на продукта.");

            if (string.IsNullOrWhiteSpace(product.Description))
                throw new Exception("Въведете описание.");

            if (product.Price <= 0)
                throw new Exception("Цената трябва да е по-голяма от 0.");

            if (product.Quantity < 0)
                throw new Exception("Количеството не може да бъде отрицателно.");

            bool sellerExists = await _context.Users
                .AnyAsync(u => u.Id == product.SellerId);

            if (!sellerExists)
                throw new Exception("Невалиден продавач.");

            bool storeExists = await _context.Stores
                .AnyAsync(s => s.Id == product.StoreId);

            if (!storeExists)
                throw new Exception("Невалиден магазин.");

            bool productExists = await _context.Products.AnyAsync(p =>
                p.Name.ToLower() == product.Name.ToLower() &&
                p.StoreId == product.StoreId);

            if (productExists)
                throw new Exception("Продукт с това име вече съществува в магазина.");

            product.Name = product.Name.Trim();
            product.Description = product.Description.Trim();

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        // DELETE PRODUCT
        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products
        .Include(p => p.Orders)
        .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                throw new Exception("Продуктът не е намерен.");

            if (product.Orders.Any())
                throw new Exception("Не може да изтриете продукт, който има поръчки.");

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }
    }
}
