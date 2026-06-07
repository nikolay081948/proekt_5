using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Forms
{
    public partial class Cart : Form
    {
        public Cart()
        {
            InitializeComponent();
        }
        public Cart(User user)
        {
            InitializeComponent();
            Buyer1 = user;
        }
        private User Buyer1 { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using StoreContext storeContext = new StoreContext();
                var orders = await storeContext.Orders
                    .Include(o => o.Product)
                    .Include(o => o.Buyer)
                    .Where(x => x.BuyerId == Buyer1.Id)
                    .Select(o => new
                    {
                        o.Id,
                        Продукт = o.Product.Name,
                        Количество = o.Quantity,
                        ОбщаЦена = o.TotalPrice,
                        Дата = o.OrderedAt
                    })
                    .ToListAsync();

                dataGridView1.DataSource = orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cart_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
