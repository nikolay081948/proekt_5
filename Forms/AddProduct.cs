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
            StoreContext storeContext = new StoreContext();

            var store = (Store)comboBox1.SelectedItem;

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Попълнете всички полета!");
                return;
            }
            if (store.Products.Any(x => x.Name == textBox1.Text))
            {
                var pr = (store.Products.FirstOrDefault(x => x.Name == textBox1.Text));
                pr.Quantity += int.Parse(textBox2.Text);
            }
            Product p = new Product();

            p.Name = textBox1.Text;
            p.Description = richTextBox1.Text;
            p.Price = decimal.Parse(textBox3.Text);
            p.Quantity= int.Parse(textBox2.Text);
            p.StoreId = store.Id;
            p.SellerId = Seller.Id;

            store.Products.Add(p);
            await storeContext.Products.AddAsync(p);
            await storeContext.SaveChangesAsync();

            MessageBox.Show("Продукта е добавен!");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            richTextBox1.Clear();
        }

        private async void AddProduct_Load(object sender, EventArgs e)
        {
            StoreContext storeContext = new StoreContext();
            StoreService ss=new StoreService(storeContext);

            var stores = await ss.GetAllStoresAsync();

            comboBox1.DataSource = stores;

            comboBox1.DisplayMember = "Name";

        }
    }
}
