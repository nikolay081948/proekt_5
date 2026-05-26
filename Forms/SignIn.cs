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
using Data.Enums;

namespace Forms
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            StoreContext storeContext = new StoreContext();

            User user = new User();

            user.Username = textBox1.Text;
            user.Email = textBox2.Text;
            user.PasswordHash = textBox3.Text;

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Попълнете всички полета!");
                return;
            }


            user.Role = (Roles)comboBox1.SelectedItem;

            if (storeContext.Users.Any(x => x.Username == textBox1.Text))
            {
                MessageBox.Show("Това потребителско име съществува!");
                return;
            }

            await storeContext.Users.AddAsync(user);
            await storeContext.SaveChangesAsync();

            DialogResult = DialogResult.OK;
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(Roles));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
