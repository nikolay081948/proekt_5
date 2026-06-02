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
            order.OrderedAt = DateTime.UtcNow;

            order.TotalPrice=order.Product.Price*order.Product.Quantity;

            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return;
            }

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();
        }
    }
}
