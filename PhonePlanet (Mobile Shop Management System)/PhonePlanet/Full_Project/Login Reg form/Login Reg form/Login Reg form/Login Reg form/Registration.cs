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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=AYAN\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");


        private void Back_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Show();
            this.Hide();
        }

        private void Signup_Click(object sender, EventArgs e)
        {

        }


        private void Already_acc_Click_1(object sender, EventArgs e)
        {

            Login login = new Login();
            login.Show();
            this.Hide();
        }



        private void Exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CustomerSignup_Click(object sender, EventArgs e)
        {
            /*Login login = new Login();
            login.Show();
            this.Hide();*/


            {

                string query = "insert into Registration values('" + tb_name.Text + "','" + tb_username.Text + "','" + tb_mobileno.Text + "','" + tb_email.Text + "','" + tb_address.Text + "','" + tb_password.Text + "')";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                if (con.State == ConnectionState.Open)
                {
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                        MessageBox.Show("Registration Successful!!! Wait For Admin Approval");
                }
                con.Close();

                Start s = new Start();
                s.Show();
                this.Hide();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into Admin_Login values('" + tb_name.Text + "','" + tb_username.Text + "','" + tb_mobileno.Text + "','" + tb_email.Text + "','" + tb_address.Text + "','" + tb_password.Text + "')";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                    MessageBox.Show(" Admin Registration Successful!!! \n You May Login");
            }
            con.Close();

            Start s = new Start();
            s.Show();
            this.Hide();
        }

        private void tb_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

  
