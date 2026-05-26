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
            StoreContext storeContext = new StoreContext();
           

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Попълнете всички полета!");
                return;
            }
            if (storeContext.Stores.Any(x => x.Name == textBox1.Text))
            {
                MessageBox.Show("Този магазин вече съществува!");
                return;
            }
            Store store = new Store();

            store.Name =textBox1.Text;

            await storeContext.Stores.AddAsync(store);
            await storeContext.SaveChangesAsync();

            MessageBox.Show("Магазина е създаден!");

            textBox1.Clear();
            textBox2.Clear();
            richTextBox1.Clear();
        }
    }
}
