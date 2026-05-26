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
using Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Controller.Services;

namespace Forms
{
    public partial class ShowStores : Form
    {
        public ShowStores()
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
            StoreService storeService = new StoreService(storeContext);
            var stores=await storeService.GetAllStoresAsync();
            dataGridView1.DataSource = stores;
        }
    }
}
