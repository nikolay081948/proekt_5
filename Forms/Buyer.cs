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

namespace Forms
{
    public partial class Buyer : Form
    {
        public Buyer()
        {
            InitializeComponent();
        }
        public Buyer(User buyer1)
        {
            InitializeComponent();
            Buyer1= buyer1;
        }
        private User Buyer1 {  get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            MakeOrder frm = new MakeOrder(Buyer1);
            DialogResult result = frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Leave_review frm = new Leave_review();
            DialogResult result = frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cart frm = new Cart(Buyer1);
            DialogResult result = frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void Buyer_Load(object sender, EventArgs e)
        {

        }
    }
}
