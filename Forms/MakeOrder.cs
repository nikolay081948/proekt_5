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
            StoreContext storeContext = new StoreContext();
            ProductService productService = new ProductService(storeContext);
            StoreService ss = new StoreService(storeContext);
            var stores=await ss.GetAllStoresAsync();
            comboBox2.DataSource = stores;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            StoreContext storeContext = new StoreContext();
            var pr = (Product)comboBox1.SelectedItem;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Попълнете всички полета!");
                return;
            }
            decimal price = pr.Price * int.Parse(textBox1.Text);
            Order order = new Order();
            if (Buyer1 == null)
            {
                MessageBox.Show("User is null");
                return;
            }
            order.ProductId= pr.Id;
            order.TotalPrice = price;
            order.OrderedAt= DateTime.Now;
            order.BuyerId = Buyer1.Id;

            await storeContext.Orders.AddAsync(order);
            await storeContext.SaveChangesAsync();

            MessageBox.Show("Продуктите са добавен в количката!");

            textBox1.Clear();
            
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(comboBox2.SelectedValue?.ToString(), out int sId))
            {
                return;
            }
            StoreContext storeContext = new StoreContext();
            ProductService productService = new ProductService(storeContext);
            int storeId = (int)comboBox2.SelectedValue;
            var pr = await productService.GetAllProductsByStoreIdAsync(sId);
            comboBox1.DataSource = pr;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }
    }
}
