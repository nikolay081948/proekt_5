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

        public OrderService(StoreContext context)
        {
            _context = context;
        }

        // GET ALL ORDERS
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Buyer)
                .Include(o => o.Product)
                .ToListAsync();
        }

        // GET ORDER BY ID
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Buyer)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        // CREATE ORDER
        public async Task CreateOrderAsync(Order order)
        {
            order.OrderedAt = DateTime.UtcNow;

            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();
        }

        // DELETE ORDER
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
