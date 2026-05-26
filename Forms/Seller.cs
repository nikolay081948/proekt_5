using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Data;

namespace Forms
{
    public partial class Seller : Form
    {
        public Seller()
        {
            InitializeComponent();
        }
        public Seller(User user)
        {
            InitializeComponent();
            User = user;
        }
        private User User {  get; set; }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStore frm = new AddStore();
            DialogResult result = frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddProduct frm = new AddProduct(User);
            DialogResult result = frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowStores frm = new ShowStores();
            DialogResult result = frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowProducts frm = new ShowProducts();
            DialogResult result = frm.ShowDialog();
        }
    }
}
