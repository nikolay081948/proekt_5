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
    public class OrderService
    {
        private readonly StoreContext _context;

        public OrderService()
        {
            _context = new StoreContext();
        }
        public OrderService(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Buyer)
                .Include(o => o.Product)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Buyer)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task CreateOrderAsync(Order order)
        {
            if (order == null)
                throw new Exception("Невалидна поръчка.");

            if (order.Quantity <= 0)
                throw new Exception("Количеството трябва да е по-голямо от 0.");

            var buyer = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == order.BuyerId);

            if (buyer == null)
                throw new Exception("Купувачът не съществува.");

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == order.ProductId);

            if (product == null)
                throw new Exception("Продуктът не съществува.");

            if (product.Quantity < order.Quantity)
                throw new Exception("Недостатъчно количество в склада.");

            order.OrderedAt = DateTime.UtcNow;

            order.TotalPrice = product.Price * order.Quantity;

            product.Quantity -= order.Quantity;

            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders
       .Include(o => o.Product)
       .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                throw new Exception("Поръчката не е намерена.");

            order.Product.Quantity += order.Quantity;

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();
        }
    }
}
