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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void Log_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

      

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
