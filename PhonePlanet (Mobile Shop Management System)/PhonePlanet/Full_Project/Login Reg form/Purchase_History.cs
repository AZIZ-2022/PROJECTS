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
    public partial class Purchase_History : Form
    {

        public string uname { get; set; }
        public Purchase_History()
        {
            InitializeComponent();
            lblcususername.Text = Login.uname;
        }
        SqlConnection con = new SqlConnection("Data Source=TAWSIF-AZIZ-AHM\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hfgkf");
        }

        private void Back_button_history_Click(object sender, EventArgs e)
        {
            Customer_Homepage f1 = new Customer_Homepage();
            f1.Show();
            this.Hide();
        }

        private void Purchase_History_Load(object sender, EventArgs e)
        {
            string query = "select * from Add_to_Cart where User_Name ='" + lblcususername.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            purchasehistory_grid.DataSource = dt;
        }

        private void purchasehistory_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (purchasehistory_grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                purchasehistory_grid.CurrentRow.Selected = true;
               
                lblcompany.Text = purchasehistory_grid.Rows[e.RowIndex].Cells["Company_Name"].FormattedValue.ToString();
                lblmodelname.Text = purchasehistory_grid.Rows[e.RowIndex].Cells["Model_Name"].FormattedValue.ToString();
                lblquantity.Text = purchasehistory_grid.Rows[e.RowIndex].Cells["Quantity"].FormattedValue.ToString();
                lblprice.Text = purchasehistory_grid.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();
                lbldiscount.Text = purchasehistory_grid.Rows[e.RowIndex].Cells["Discount"].FormattedValue.ToString();
                lbltotalprice.Text = purchasehistory_grid.Rows[e.RowIndex].Cells["Total_Price"].FormattedValue.ToString();
                


            }
        }
    }
}
