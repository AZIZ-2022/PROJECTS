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
    public partial class Wishlist : Form
    {
        public string uname { get; set; }

        public Wishlist()
        {
            InitializeComponent();
            usertb.Text = Login.uname;
            
        }
        SqlConnection con = new SqlConnection("Data Source=TAWSIF-AZIZ-AHM\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");
        private int loggedInCustomerID;
        private void Back_button_compaare_Click(object sender, EventArgs e)
        {
            Customer_Homepage f1 = new Customer_Homepage();
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Purchase f4 = new Purchase();
            f4.Show();
            this.Hide();
        }
        private void FILLwishlist()
        {
            con.Open();
            string query = "Select * from Add_to_Wishlist where Username='"+usertb.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView_wishlist.DataSource = dt;
            con.Close();
        }

        private void Wishlist_Load(object sender, EventArgs e)
        {
            FILLwishlist();
        }
    }
}
