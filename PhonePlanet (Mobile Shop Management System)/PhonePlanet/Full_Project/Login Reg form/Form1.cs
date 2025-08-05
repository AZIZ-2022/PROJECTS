using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login_Reg_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=AYAN\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");


        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            welcomeAdmin1.Show();
            customerApproval1.Hide();
            customerRecords1.Hide();
            sellHistory1.Hide();
            add_Phones1.Hide();
            deletePhone1.Hide();
            stock1.Hide();

        }

        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            welcomeAdmin1.Hide();
            customerApproval1.Hide();
            customerRecords1.Hide();
            sellHistory1.Hide();
            add_Phones1.Show();
            deletePhone1.Hide();
            stock1.Hide();
        }

        private void btnShowAllPhones_Click(object sender, EventArgs e)
        {
            welcomeAdmin1.Hide();
            customerApproval1.Hide();
            customerRecords1.Hide();
            sellHistory1.Hide();
            add_Phones1.Hide();
            deletePhone1.Hide();
            stock1.Show();
            
        }

        private void btnDeletePhone_Click(object sender, EventArgs e)
        {
            welcomeAdmin1.Hide();
            customerApproval1.Hide();
            customerRecords1.Hide();
            sellHistory1.Hide();
            add_Phones1.Hide();
            deletePhone1.Show();
            stock1.Hide();
        }

        private void btnCustomerHistory_Click(object sender, EventArgs e)
        {
            welcomeAdmin1.Hide();
            customerApproval1.Hide();
            customerRecords1.Show();
            sellHistory1.Hide();
            add_Phones1.Hide();
            deletePhone1.Hide();
            stock1.Hide();
        }

        private void btnSellHistory_Click(object sender, EventArgs e)
        {
            welcomeAdmin1.Hide();
            customerApproval1.Hide();
            customerRecords1.Hide();
            sellHistory1.Show();
            add_Phones1.Hide();
            deletePhone1.Hide();
            stock1.Hide();
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            welcomeAdmin1.Hide();
            customerApproval1.Show();
            customerRecords1.Hide();
            sellHistory1.Hide();
            add_Phones1.Hide();
            deletePhone1.Hide();
            stock1.Hide();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            welcomeAdmin1.Show();
            customerApproval1.Hide();
            customerRecords1.Hide();
            sellHistory1.Hide();
            add_Phones1.Hide();
            deletePhone1.Hide();
            stock1.Hide();
        }

        private void welcomeAdmin1_Load(object sender, EventArgs e)
        {
            Login login = new Login();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start S = new Start();
            S.Show();
            this.Hide();
        }
    }
}
