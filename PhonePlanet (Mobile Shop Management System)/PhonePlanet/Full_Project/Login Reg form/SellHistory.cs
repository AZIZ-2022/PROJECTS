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
    public partial class SellHistory : UserControl
    {
        public SellHistory()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=TAWSIF-AZIZ-AHM\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SellHistory_Enter(object sender, EventArgs e)
        {
            string query = "select * from Add_to_Cart";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewsellhistory.DataSource = dt;
        }

        private void dataGridViewsellhistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewsellhistory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridViewsellhistory.CurrentRow.Selected = true;
                lblcususer.Text = dataGridViewsellhistory.Rows[e.RowIndex].Cells["User_Name"].FormattedValue.ToString();
                lblcompany.Text = dataGridViewsellhistory.Rows[e.RowIndex].Cells["Company_Name"].FormattedValue.ToString();
                lblmodel.Text = dataGridViewsellhistory.Rows[e.RowIndex].Cells["Model_Name"].FormattedValue.ToString();
                lblquantity.Text = dataGridViewsellhistory.Rows[e.RowIndex].Cells["Quantity"].FormattedValue.ToString();
                lblprice.Text = dataGridViewsellhistory.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();
                lbldiscount.Text = dataGridViewsellhistory.Rows[e.RowIndex].Cells["Discount"].FormattedValue.ToString();
               lbltotalprice.Text = dataGridViewsellhistory.Rows[e.RowIndex].Cells["Total_Price"].FormattedValue.ToString();
                


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query2 = "SELECT SUM(CONVERT(INT, Total_Price)) FROM Add_to_Cart";
            SqlDataAdapter sda = new SqlDataAdapter(query2, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // Check if there is any row and column containing data
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                // Retrieve the value from the first row and first column
                object sum = dt.Rows[0][0];

                // Check if the retrieved value is not null
                if (sum != DBNull.Value)
                {
                    // Convert the value to string and assign it to the TextBox
                    textBox1.Text = sum.ToString();
                }
                else
                {
                    // Handle DBNull value if needed
                    textBox1.Text = "No data";
                }
            }
            else
            {
                // Handle empty DataTable if needed
                textBox1.Text = "No data";
            }
            


        }

        
    }
}
