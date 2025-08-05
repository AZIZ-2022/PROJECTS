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
    public partial class Customer_Profile : Form
    {
        public string uname { get; set; }
       

        public Customer_Profile()
        {
            InitializeComponent();
            usernametb.Text = Login.uname;
         
        }
        
        
        


        SqlConnection con = new SqlConnection("Data Source=TAWSIF-AZIZ-AHM\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");
        private int loggedInCustomerID;

        private void Back_button_profile_Click(object sender, EventArgs e)
        {
            
            Customer_Homepage C = new Customer_Homepage();
            C.Show();
            
            this.Hide();
            

        }

        

        private void Phone_label_Click(object sender, EventArgs e)
        {

        }

        private void Gender_label_Click(object sender, EventArgs e)
        {

        }

        private void Id_label_Click(object sender, EventArgs e)
        {

        }

        private void address_label_Click(object sender, EventArgs e)
        {

        }

        private void tb2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Customer_Profile_Load(object sender, EventArgs e)
        {
            con.Open();
            string query = "select Name,Mobile_No,Email,Address from Approved_Customer where User_Name='" + usernametb.Text + "'";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("User_Name", loggedInCustomerID);

               
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    
                    Full_nametb.Text = reader["Name"].ToString();
                    phn_tb.Text = reader["Mobile_No"].ToString();
                    Addresstb.Text = reader["Address"].ToString();
                    Emailtb.Text = reader["Email"].ToString();


                    

                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }

                reader.Close();
            }
           







        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
