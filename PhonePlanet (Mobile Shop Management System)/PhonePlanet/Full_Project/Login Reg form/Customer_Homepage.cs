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
  
    public partial class Customer_Homepage : Form
    {
       


        public Customer_Homepage()
        {
            InitializeComponent();
           
        }
        public static string Phone_No = "";
        public static string Address = "";

        private void Profile_button_Click(object sender, EventArgs e)
        {

            Customer_Profile f2 = new Customer_Profile();
            
            f2.Show();
            this.Hide();
        }

        private void All_products_button_Click(object sender, EventArgs e)
        {
            
            Available_Phones f3 = new Available_Phones();
            f3.Show();
            this.Hide();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("print");
        }

        private void Purchase_history_button_Click(object sender, EventArgs e)
        {
            Purchase_History f5 = new Purchase_History();
            f5.Show();
            this.Hide();
        }

        private void exit_button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Comapre_button_Click(object sender, EventArgs e)
        {
            Comparison f6 = new Comparison();
            f6.Show();
            this.Hide();
        }

        private void Customer_Homepage_Load(object sender, EventArgs e)
        {
           
        }

        private void Log_out_button_Click(object sender, EventArgs e)
        {
            Login L = new Login();
            L.Show();
            this.Hide();
        }
    }
}
