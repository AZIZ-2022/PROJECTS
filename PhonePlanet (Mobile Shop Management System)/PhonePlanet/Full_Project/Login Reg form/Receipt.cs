using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Reg_form
{
    public partial class Receipt : Form
    {
        public Receipt()
        {
            InitializeComponent();
        }

        private void receipt_back_button1_Click(object sender, EventArgs e)
        {
            Purchase f4 = new Purchase();
            f4.Show();
            this.Hide();
        }
    }
}
