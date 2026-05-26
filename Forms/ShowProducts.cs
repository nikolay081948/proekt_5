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
using Data.Data;

namespace Forms
{
    public partial class ShowProducts : Form
    {
        public ShowProducts()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

        }

        private async void ShowProducts_Load(object sender, EventArgs e)
        {
            StoreContext storeContext = new StoreContext();
            StoreService ps = new StoreService(storeContext);

            var pr = await ps.GetAllStoresAsync();

            comboBox1.DataSource = pr;

            comboBox1.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StoreContext storeContext = new StoreContext();
            var store = (Store)comboBox1.SelectedItem;
            dataGridView1.DataSource = store.Products;
        }
    }
}
