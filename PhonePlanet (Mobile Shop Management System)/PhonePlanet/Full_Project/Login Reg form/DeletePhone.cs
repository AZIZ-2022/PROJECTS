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
    public partial class DeletePhone : UserControl
    {

        SqlConnection con = new SqlConnection("Data Source=TAWSIF-AZIZ-AHM\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");
    
        
        public DeletePhone()
        {
            InitializeComponent();
            
           
        }

        private void DeleteSearch_KeyDown(object sender, KeyEventArgs e)
        {
            string query = "select * from Add_Phones where Company like '%" +DeleteSearch.Text +"%'or Model like '%"+ DeleteSearch.Text +"%'or IMEI like '%"+DeleteSearch.Text+"%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataGridViewDelete.DataSource = dt;
        }

        private void DeletePhone_Enter(object sender, EventArgs e)
        {
            string query = "select * from Add_Phones";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataGridViewDelete.DataSource = dt;
        }


        private void DataGridViewDelete_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridViewDelete.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                DataGridViewDelete.CurrentRow.Selected = true;
                companytxt.Text = DataGridViewDelete.Rows[e.RowIndex].Cells["Company"].FormattedValue.ToString();
                modeltxt.Text = DataGridViewDelete.Rows[e.RowIndex].Cells["Model"].FormattedValue.ToString();
                imeitxt.Text = DataGridViewDelete.Rows[e.RowIndex].Cells["IMEI"].FormattedValue.ToString();

            }


        }

        private void DeletePhoneButton_Click(object sender, EventArgs e)
        {
            string query2 = "delete from Add_Phones where IMEI='" + imeitxt.Text + "'";
            SqlCommand cmd = new SqlCommand(query2, con);

            con.Open();

            if (con.State == ConnectionState.Open)
            {

                int result = cmd.ExecuteNonQuery();//query execute

                if (result > 0)
                    MessageBox.Show("Phone Deleted!!");
            }
            con.Close();

            companytxt.Clear();
            modeltxt.Clear();
            imeitxt.Clear();

          

        }
        

       
    }
    }

