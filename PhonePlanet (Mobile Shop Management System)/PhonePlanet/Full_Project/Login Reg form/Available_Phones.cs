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
using System.Reflection.Emit;

namespace Login_Reg_form
{
    public partial class Available_Phones : Form
    {
        public string uname { get; set; }

        public Available_Phones()
        {
            InitializeComponent();
            
        }
        
        public static string Company_Name = "";
        public static string Model_Name = "";
        public static string Quantity = "";
        public static string Price = "";




        SqlConnection con = new SqlConnection("Data Source=TAWSIF-AZIZ-AHM\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");


        private void Available_Phones_Load(object sender, EventArgs e)
        {
            string query = "select * from Add_Phones";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewcus.DataSource = dt;
        }

        private void dataGridViewcus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridViewcus.CurrentRow.Selected = true;
                all_phone_text_label2.Text = dataGridViewcus.Rows[e.RowIndex].Cells["Phone ID"].FormattedValue.ToString();
                comanylabel.Text = dataGridViewcus.Rows[e.RowIndex].Cells["Company"].FormattedValue.ToString();
                modellabel.Text = dataGridViewcus.Rows[e.RowIndex].Cells["Model"].FormattedValue.ToString();
                label6.Text = dataGridViewcus.Rows[e.RowIndex].Cells["Ram"].FormattedValue.ToString();
                label7.Text = dataGridViewcus.Rows[e.RowIndex].Cells["Storage"].FormattedValue.ToString();
                label2.Text = dataGridViewcus.Rows[e.RowIndex].Cells["Rear Camera"].FormattedValue.ToString();
                label8.Text = dataGridViewcus.Rows[e.RowIndex].Cells["Front Camera"].FormattedValue.ToString();
                label9.Text = dataGridViewcus.Rows[e.RowIndex].Cells["Display"].FormattedValue.ToString();
                label10.Text = dataGridViewcus.Rows[e.RowIndex].Cells["Battery"].FormattedValue.ToString();
                label12.Text = dataGridViewcus.Rows[e.RowIndex].Cells["Processor"].FormattedValue.ToString();
                label3.Text = dataGridViewcus.Rows[e.RowIndex].Cells["IMEI"].FormattedValue.ToString();
                label11.Text = dataGridViewcus.Rows[e.RowIndex].Cells["Guarantee"].FormattedValue.ToString();
                pricelabel.Text = dataGridViewcus.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();

            }
        }

            private void button10_Click(object sender, EventArgs e)
        {
            Customer_Homepage C = new Customer_Homepage();
            C.Show();
            this.Hide();
        }

        private void Cart_button_Click(object sender, EventArgs e)
        {
            
                Company_Name = comanylabel.Text;
                Model_Name = modellabel.Text;
                Quantity = quantity_combo.Text;
                Price = pricelabel.Text;
            if (!string.IsNullOrEmpty(quantity_combo.Text))
            {
                Purchase P = new Purchase();
                P.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Fill The Quantity");
            }
        }
        
        
        

        private void Wishlist_button_Click(object sender, EventArgs e)
        {
           
        }

        private void searchphn_KeyDown(object sender, KeyEventArgs e)
        {
            string query2 = "select * from Add_Phones where Company like '%" + searchphn.Text + "%'or Model like '%" + searchphn.Text + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query2, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewcus.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer_Homepage C = new Customer_Homepage();
            C.Show();
            this.Hide();
        }
    }
    }

