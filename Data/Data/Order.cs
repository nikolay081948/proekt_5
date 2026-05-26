using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class Order
    {
        public int Id { get; set; }

        // BUYER
        public int BuyerId { get; set; }

        public User Buyer { get; set; } = null!;

        // PRODUCT
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        // ORDER INFO
        public decimal TotalPrice { get; set; }

        public DateTime OrderedAt { get; set; }
    }
}
