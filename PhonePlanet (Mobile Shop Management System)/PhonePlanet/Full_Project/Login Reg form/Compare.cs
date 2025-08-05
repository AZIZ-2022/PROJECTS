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
    public partial class Comparison : Form
    {
        public Comparison()
        {
            InitializeComponent();
  
        }
        SqlConnection con = new SqlConnection("Data Source=TAWSIF-AZIZ-AHM\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");

        private void Comparison_Load(object sender, EventArgs e)
        {
            string query = "select * from Add_Phones";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                phone_id_1_label.Text = dataGridView1.Rows[e.RowIndex].Cells["Phone ID"].FormattedValue.ToString();
                company_label_1.Text = dataGridView1.Rows[e.RowIndex].Cells["Company"].FormattedValue.ToString();
                model_label_1.Text = dataGridView1.Rows[e.RowIndex].Cells["Model"].FormattedValue.ToString();
                rear_label_1.Text = dataGridView1.Rows[e.RowIndex].Cells["Rear Camera"].FormattedValue.ToString();
                front_label_1.Text = dataGridView1.Rows[e.RowIndex].Cells["Front Camera"].FormattedValue.ToString();
                ram_label_1.Text = dataGridView1.Rows[e.RowIndex].Cells["Ram"].FormattedValue.ToString();
                storage_label_1.Text = dataGridView1.Rows[e.RowIndex].Cells["Storage"].FormattedValue.ToString();
                battery_label_1.Text = dataGridView1.Rows[e.RowIndex].Cells["Battery"].FormattedValue.ToString();
                guarantee_label_1.Text = dataGridView1.Rows[e.RowIndex].Cells["Guarantee"].FormattedValue.ToString();
                processor_label_1.Text = dataGridView1.Rows[e.RowIndex].Cells["Processor"].FormattedValue.ToString();
                price_label_1.Text = dataGridView1.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();
                display_label_1.Text = dataGridView1.Rows[e.RowIndex].Cells["Display"].FormattedValue.ToString();
                imei_label_1.Text = dataGridView1.Rows[e.RowIndex].Cells["IMEI"].FormattedValue.ToString();


            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView2.CurrentRow.Selected = true;
                phone_id_label_2.Text = dataGridView2.Rows[e.RowIndex].Cells["Phone ID"].FormattedValue.ToString();
                company_label_2.Text = dataGridView2.Rows[e.RowIndex].Cells["Company"].FormattedValue.ToString();
                model_label_2.Text = dataGridView2.Rows[e.RowIndex].Cells["Model"].FormattedValue.ToString();
                rear_label_2.Text = dataGridView2.Rows[e.RowIndex].Cells["Rear Camera"].FormattedValue.ToString();
                front_label_2.Text = dataGridView2.Rows[e.RowIndex].Cells["Front Camera"].FormattedValue.ToString();
                ram_label_2.Text = dataGridView2.Rows[e.RowIndex].Cells["Ram"].FormattedValue.ToString();
                storage_label_2.Text = dataGridView2.Rows[e.RowIndex].Cells["Storage"].FormattedValue.ToString();
                battery_label_2.Text = dataGridView2.Rows[e.RowIndex].Cells["Battery"].FormattedValue.ToString();
                guarantee_label_2.Text = dataGridView2.Rows[e.RowIndex].Cells["Guarantee"].FormattedValue.ToString();
                processor_label_2.Text = dataGridView2.Rows[e.RowIndex].Cells["Processor"].FormattedValue.ToString();
                price_label_2.Text = dataGridView2.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();
                display_label_2.Text = dataGridView2.Rows[e.RowIndex].Cells["Display"].FormattedValue.ToString();
                imei_label_2.Text = dataGridView2.Rows[e.RowIndex].Cells["IMEI"].FormattedValue.ToString();


            }
        }

        private void Back_button_compaare_Click(object sender, EventArgs e)
        {
            Customer_Homepage C = new Customer_Homepage();
            C.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_Homepage C = new Customer_Homepage();
            C.Show();
            this.Hide();
        }
    }

   

       
    }

