using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;

namespace Data.Data
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public Roles Role { get; set; }

        // PRODUCTS CREATED BY SELLER
        public ICollection<Product> Products { get; set; } = new List<Product>();

        // ORDERS MADE BY BUYER
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
