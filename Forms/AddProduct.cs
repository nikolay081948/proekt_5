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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        public AddProduct(User seller)
        {         
            InitializeComponent();
            Seller=seller;
        }
        private User Seller { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Попълнете всички полета!");
                return;
            }

            if (!int.TryParse(textBox2.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Въведете валидно количество!");
                return;
            }

            if (!decimal.TryParse(textBox3.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Въведете валидна цена!");
                return;
            }

            try
            {
                using StoreContext storeContext = new StoreContext();
                ProductService productService = new ProductService(storeContext);
                StoreService storeService = new StoreService(storeContext);

                var selectedStore = (Store)comboBox1.SelectedItem;
                var store = await storeService.GetStoreByIdAsync(selectedStore.Id);

                if (store == null)
                {
                    MessageBox.Show("Магазинът не е намерен!");
                    return;
                }

                var existingProduct = store.Products.FirstOrDefault(x =>
                    x.Name.ToLower() == textBox1.Text.Trim().ToLower());

                if (existingProduct != null)
                {
                    existingProduct.Quantity += quantity;
                    storeContext.Products.Update(existingProduct);
                    await storeContext.SaveChangesAsync();
                    MessageBox.Show("Количеството на продукта е обновено!");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    richTextBox1.Clear();
                    return;
                }

                Product p = new Product();
                p.Name = textBox1.Text.Trim();
                p.Description = richTextBox1.Text.Trim();
                p.Price = price;
                p.Quantity = quantity;
                p.StoreId = store.Id;
                p.SellerId = Seller.Id;

                await productService.AddProductAsync(p);

                MessageBox.Show("Продукта е добавен!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                richTextBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void AddProduct_Load(object sender, EventArgs e)
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
    }
}
