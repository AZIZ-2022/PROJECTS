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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=TAWSIF-AZIZ-AHM\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");

        private void Log_label_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Show();
            this.Hide();
        }

        private void Forgotpass_Click(object sender, EventArgs e)
        {
            Varify_Form vf = new Varify_Form();
            vf.Show();
            this.Hide();
        }

        private void create_new_acc_label_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Signin_Click(object sender, EventArgs e)
        {

        }

        private void CustomerSignin_Click(object sender, EventArgs e)
        {
            string query = "select * from Approved_Customer where User_Name='" + tb_username.Text + "'and Password='" + tb_password.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Customer Login Successful!!");
            }
            else
            {
                MessageBox.Show("Wrong Credentials!!\n Try Again");
                tb_username.Clear();
                tb_password.Clear();
            }
        }

        private void Admin_Signin_Click(object sender, EventArgs e)
        {
            string query = "select * from Admin_Login where User_Name='" + tb_username.Text + "'and Password='" + tb_password.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Admin Login Successful!!");
            }
            else
            {
                MessageBox.Show("Wrong Credentials!!\n Try Again");
                tb_username.Clear();
                tb_password.Clear();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}