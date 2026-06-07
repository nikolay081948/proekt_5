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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public Login(User seller, User buyer1)
        {
            InitializeComponent();
            Seller = seller;
            Buyer1 = buyer1;
        }
        private User Seller { get; set; }
        private User Buyer1 { get; set; }
        

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StoreContext storeContext = new StoreContext();
                UserService controller = new UserService(storeContext);

                User user = await controller.Login(textBox1.Text, textBox2.Text);
                if (user == null)
                {
                    MessageBox.Show("Грешно потребителско име или парола!");
                    return;
                }

                textBox1.Clear();
                textBox2.Clear();

                if (user.Role == Data.Enums.Roles.Seller)
                {
                    Seller frm1 = new Seller(user);
                    frm1.ShowDialog();
                }
                else
                {
                    Buyer frm = new Buyer(user);
                    frm.ShowDialog();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
