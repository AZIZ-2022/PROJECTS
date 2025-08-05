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
    public partial class Stock : UserControl
    {

        public Stock()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=TAWSIF-AZIZ-AHM\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Stock_Enter(object sender, EventArgs e)
        {
            string query = "select * from Add_Phones";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewStock.DataSource = dt;
        }


        private void dataGridViewStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if(dataGridViewStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
            {
                dataGridViewStock.CurrentRow.Selected = true;
                Idlabel.Text = dataGridViewStock.Rows[e.RowIndex].Cells["Phone ID"].FormattedValue.ToString();
                Companylabel.Text= dataGridViewStock.Rows[e.RowIndex].Cells["Company"].FormattedValue.ToString();
                Modellabel.Text= dataGridViewStock.Rows[e.RowIndex].Cells["Model"].FormattedValue.ToString();
                Rearcameralabel.Text= dataGridViewStock.Rows[e.RowIndex].Cells["Rear Camera"].FormattedValue.ToString();
                Frontcameralabel.Text= dataGridViewStock.Rows[e.RowIndex].Cells["Front Camera"].FormattedValue.ToString();
                Ramlabel.Text= dataGridViewStock.Rows[e.RowIndex].Cells["Ram"].FormattedValue.ToString();
                Storagelabel.Text= dataGridViewStock.Rows[e.RowIndex].Cells["Storage"].FormattedValue.ToString();
                batterylabel.Text= dataGridViewStock.Rows[e.RowIndex].Cells["Battery"].FormattedValue.ToString();
                Guaranteelabel.Text= dataGridViewStock.Rows[e.RowIndex].Cells["Guarantee"].FormattedValue.ToString();
                processorlabel.Text= dataGridViewStock.Rows[e.RowIndex].Cells["Processor"].FormattedValue.ToString();
                PriceLabel.Text= dataGridViewStock.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();
                displaylabel.Text= dataGridViewStock.Rows[e.RowIndex].Cells["Display"].FormattedValue.ToString();
                IMEIlabel.Text= dataGridViewStock.Rows[e.RowIndex].Cells["IMEI"].FormattedValue.ToString();


            }
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
