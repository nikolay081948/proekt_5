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
            try
            {
                StoreContext storeContext = new StoreContext();
                StoreService ss = new StoreService(storeContext);
                var stores = await ss.GetAllStoresAsync();
                comboBox1.DataSource = stores;
                comboBox1.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Изберете магазин!");
                return;
            }

            try
            {
                var selectedStore = (Store)comboBox1.SelectedItem;

                using StoreContext storeContext = new StoreContext();
                ProductService productService = new ProductService(storeContext);

                var products = await productService.GetAllProductsByStoreIdAsync(selectedStore.Id);

                dataGridView1.DataSource = products.Select(p => new
                {
                    p.Id,
                    Наименование = p.Name,
                    Описание = p.Description,
                    Цена = p.Price,
                    Количество = p.Quantity
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
