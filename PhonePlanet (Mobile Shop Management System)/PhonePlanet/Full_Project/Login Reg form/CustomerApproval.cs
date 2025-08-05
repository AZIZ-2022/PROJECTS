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
    public partial class CustomerApproval : UserControl
    {
        public CustomerApproval()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=TAWSIF-AZIZ-AHM\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");



        private void CustomerApproval_Enter(object sender, EventArgs e)
        {
            string query = "select * from Registration";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewapproval.DataSource = dt;
        }


        private void dataGridViewapproval_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewapproval.CurrentRow.Selected = true;
            usernametb.Text = dataGridViewapproval.Rows[e.RowIndex].Cells["User_Name"].FormattedValue.ToString();
            fullnametb.Text = dataGridViewapproval.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
            phonetb.Text = dataGridViewapproval.Rows[e.RowIndex].Cells["Mobile_No"].FormattedValue.ToString();
            emailtb.Text = dataGridViewapproval.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
            addresstb.Text = dataGridViewapproval.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
            passtextbox.Text = dataGridViewapproval.Rows[e.RowIndex].Cells["Password"].FormattedValue.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into Approved_Customer values('" + fullnametb.Text + "','" + usernametb.Text + "','" + phonetb.Text + "','" + emailtb.Text + "','" + addresstb.Text + "','" + passtextbox.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    MessageBox.Show("Customer Approved!!");
                con.Close();
            }
            string query2 = "delete from Registration where User_Name='" + usernametb.Text + "' and Password='"+passtextbox.Text+"' ";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                int result = cmd2.ExecuteNonQuery();
                if (result > 0)
                    
                con.Close();
            }
            usernametb.Clear();
            fullnametb.Clear();
            phonetb.Clear();
            emailtb.Clear();
            addresstb.Clear();
            passtextbox.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query3 = "delete from Registration where User_Name='" + usernametb.Text + "' and Password='" + passtextbox.Text + "' ";
            SqlCommand cmd2 = new SqlCommand(query3, con);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                int result = cmd2.ExecuteNonQuery();
                if (result > 0)
                    MessageBox.Show("Customer Rejected!!!");
                    con.Close();
            }
            usernametb.Clear();
            fullnametb.Clear();
            phonetb.Clear();
            emailtb.Clear();
            addresstb.Clear();
            passtextbox.Clear();
        }
    }
}
