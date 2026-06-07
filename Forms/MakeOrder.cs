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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Forms
{
    public partial class MakeOrder : Form
    {
        public MakeOrder()
        {
            InitializeComponent();
        }
        public MakeOrder(User buyer1)
        {
            InitializeComponent();
            Buyer1 = buyer1;
        }

        private User Buyer1 {  get; set; }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

        }

        private async void MakeOrder_Load(object sender, EventArgs e)
        {
            try
            {
                StoreContext storeContext = new StoreContext();
                StoreService ss = new StoreService(storeContext);
                var stores = await ss.GetAllStoresAsync();
                comboBox2.DataSource = stores;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
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
                MessageBox.Show("Изберете продукт!");
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Попълнете всички полета!");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Въведете валидно количество!");
                return;
            }

            if (Buyer1 == null)
            {
                MessageBox.Show("User is null");
                return;
            }

            try
            {
                var selectedProduct = (Product)comboBox1.SelectedItem;

                using StoreContext storeContext = new StoreContext();
                var pr = await storeContext.Products.FindAsync(selectedProduct.Id);

                if (pr == null)
                {
                    MessageBox.Show("Продуктът не е намерен!");
                    return;
                }

                if (pr.Quantity < quantity)
                {
                    MessageBox.Show($"Недостатъчно количество! Налични: {pr.Quantity}");
                    return;
                }

                Order order = new Order();
                order.ProductId = pr.Id;
                order.OrderedAt = DateTime.Now;
                order.BuyerId = Buyer1.Id;
                order.Quantity = quantity;
                order.TotalPrice = pr.Price * quantity;

                pr.Quantity -= quantity;

                storeContext.Products.Update(pr);
                await storeContext.Orders.AddAsync(order);
                await storeContext.SaveChangesAsync();

                MessageBox.Show("Продуктите са добавени в количката!");
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(comboBox2.SelectedValue?.ToString(), out int sId))
                return;

            try
            {
                StoreContext storeContext = new StoreContext();
                ProductService productService = new ProductService(storeContext);
                var pr = await productService.GetAllProductsByStoreIdAsync(sId);
                comboBox1.DataSource = pr;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
