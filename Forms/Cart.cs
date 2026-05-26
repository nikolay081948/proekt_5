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
        private User Buyer1 {  get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StoreContext storeContext = new StoreContext();
            var orders=storeContext.Orders.Where(x=>x.BuyerId==Buyer1.Id).ToList();
            dataGridView1.DataSource = orders;
        }
    }
}
