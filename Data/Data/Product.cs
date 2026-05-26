using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        // SELLER
        public int SellerId { get; set; }

        public User Seller { get; set; } = null!;

        // STORE
        public int StoreId { get; set; }

        public Store Store { get; set; } = null!;

        // ORDERS
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}

