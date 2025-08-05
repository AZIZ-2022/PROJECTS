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
    public partial class CustomerRecords : UserControl
    {
        public CustomerRecords()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=TAWSIF-AZIZ-AHM\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");


        private void CustomerRecords_Enter(object sender, EventArgs e)
        {
            string query = "select * from Approved_Customer";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewcustomerhistory.DataSource = dt;
        }




        private void customersearchtxt_TextChanged(object sender, EventArgs e)
        {
      
                {
                    string query = "select * from Approved_Customer where User_Name like '%" + customersearchtxt.Text + "%'or Mobile_No like'%" + customersearchtxt.Text + "%'or Email like'%" + customersearchtxt.Text + "%' ";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridViewcustomerhistory.DataSource = dt;
                }
            
        }
        

        private void dataGridViewcustomerhistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewcustomerhistory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridViewcustomerhistory.CurrentRow.Selected = true;
                usertb.Text = dataGridViewcustomerhistory.Rows[e.RowIndex].Cells["User_Name"].FormattedValue.ToString();
                phonetb.Text = dataGridViewcustomerhistory.Rows[e.RowIndex].Cells["Mobile_No"].FormattedValue.ToString();
                emailtb.Text = dataGridViewcustomerhistory.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
                
            }
        }

        private void banbutton_Click(object sender, EventArgs e)
        {
            string query = "delete from Approved_Customer where User_Name='" + usertb.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                int result = cmd.ExecuteNonQuery();

                if(result > 0)
                {
                    MessageBox.Show("Customer Banned!!");
                }
                con.Close();
                usertb.Clear();
                phonetb.Clear();
                emailtb.Clear();
            }
        }

        
    }
}
