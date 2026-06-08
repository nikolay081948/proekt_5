using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Enums;
using Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Data.Data;
using Controller.Services;

namespace Forms
{
    public partial class AddStore : Form
    {
        public AddStore()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Попълнете името на магазина!");
                return;
            }

            if (textBox1.Text.Trim().Length < 3)
            {
                MessageBox.Show("Името трябва да е поне 3 символа!");
                return;
            }

            try
            {
                using StoreContext storeContext = new StoreContext();
                StoreService storeService = new StoreService(storeContext);

                Store store = new Store();
                store.Name = textBox1.Text.Trim();

                await storeService.CreateStoreAsync(store);

                MessageBox.Show("Магазина е създаден!");
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Clear();
            textBox2.Clear();
            richTextBox1.Clear();
        }

        private void AddStore_Load(object sender, EventArgs e)
        {

        }
    }
}
