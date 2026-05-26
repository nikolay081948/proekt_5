using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller.Services;
using Data;

namespace Forms
{
    public partial class Leave_review : Form
    {
        public Leave_review()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();

        }

        private async void Leave_review_Load(object sender, EventArgs e)
        {
            StoreContext storeContext = new StoreContext();
            ProductService productService = new ProductService(storeContext);
            StoreService ss = new StoreService(storeContext);
            var stores = await ss.GetAllStoresAsync();
            comboBox1.DataSource = stores;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";


            List<string> list = new List<string>() { "1 STAR", "2 STARS", "3 STARS", "4 STARS", "5 STARS" };
            comboBox2.DataSource = list;


        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(comboBox1.SelectedValue?.ToString(), out int sId))
            {
                return;
            }
            StoreContext storeContext = new StoreContext();
            ProductService productService = new ProductService(storeContext);
            int storeId = (int)comboBox1.SelectedValue;
            var pr = await productService.GetAllProductsByStoreIdAsync(storeId);
            comboBox3.DataSource = pr;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            MessageBox.Show("Ревюто е качено!");
        }
    }
}
