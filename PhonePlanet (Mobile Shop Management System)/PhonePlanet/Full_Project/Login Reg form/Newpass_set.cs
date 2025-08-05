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
    public partial class Newpass_set : Form
    {
        public Newpass_set()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=AYAN\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");
        private void Back_Click(object sender, EventArgs e)
        {
            Varify_Form varify_Form = new Varify_Form();
            varify_Form.Show();
            this.Hide();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            if(tb_password.Text== tb_confirmpass.Text)
            {
                string query = "update Admin_Login set Password='" + tb_confirmpass.Text + "' where User_Name='" + tb_username.Text + "'  ";
                SqlCommand cmd= new SqlCommand(query, con);
                con.Open();
                if(con.State==ConnectionState.Open)
                {
                    int result= cmd.ExecuteNonQuery();
                    if(result>0)
                    {
                        MessageBox.Show("Your Password Has been Reset!!");
                    }
                    else
                    {
                        MessageBox.Show("OOPS!! You are not an eligible Admin...");
                        tb_password.Clear();
                        tb_confirmpass.Clear();
                        tb_username.Clear();

                    }
                }
                con.Close();

                Login login = new Login();
                login.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Password is not Matched...");
                tb_password.Clear();
                tb_confirmpass.Clear();
                tb_username.Clear();
            }
            
        }

        private void Customer_Reset_Click(object sender, EventArgs e)
        {
            if (tb_password.Text == tb_confirmpass.Text)
            {
                string query = "update Approved_Customer set Password='" + tb_confirmpass.Text + "' where User_Name='" + tb_username.Text + "'  ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Your Password Has been Reset!!");
                    }
                    else
                    {
                        MessageBox.Show("OOPS!! You are not an eligible Customer...");
                       
                    }
                }
                con.Close();

                Login login = new Login();
                login.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Password is not Matched...");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
