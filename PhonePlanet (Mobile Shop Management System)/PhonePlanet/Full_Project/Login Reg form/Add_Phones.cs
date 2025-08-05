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
    public partial class Add_Phones : UserControl
    {

     
        public Add_Phones()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=TAWSIF-AZIZ-AHM\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");

        private void Add_To_Stock_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxCompany.Text) &&
                !string.IsNullOrEmpty(textBoxModel.Text) &&
                 !string.IsNullOrEmpty(comboBoxStorage.Text) &&
                 !string.IsNullOrEmpty(comboBoxBattery.Text) &&
                 !string.IsNullOrEmpty(comboBoxRearCamera.Text) &&
                 !string.IsNullOrEmpty(comboBoxFrontCam.Text) &&
                 !string.IsNullOrEmpty(comboBoxRam.Text) &&
                 !string.IsNullOrEmpty(comboBoxGuarantee.Text) &&
                 !string.IsNullOrEmpty(comboBoxProcessor.Text) &&
                 !string.IsNullOrEmpty(textBoxPrice.Text) &&
                 !string.IsNullOrEmpty(comboBoxDisplay.Text) &&
                  !string.IsNullOrEmpty(textBoxIMEI.Text)){

                string query = "insert into Add_Phones values('" + textBoxCompany.Text + "','" + textBoxModel.Text + "','" + comboBoxRearCamera.Text + "','" + comboBoxFrontCam.Text + "','" + comboBoxRam.Text + "','" + comboBoxStorage.Text + "','" + comboBoxBattery.Text + "','" + comboBoxGuarantee.Text + "','" + comboBoxProcessor.Text + "','" + textBoxPrice.Text + "','" + comboBoxDisplay.Text + "','" + textBoxIMEI.Text + "')";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                if (con.State == ConnectionState.Open)
                {

                    int result = cmd.ExecuteNonQuery();//query execute

                    if (result > 0)
                        MessageBox.Show("Phone Added to Stock!!");
                }
                con.Close();
                textBoxIMEI.Clear();
            }
            else
            {
                MessageBox.Show("Please Fill  All Information!");
            }

        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxCompany.Text) &&
                !string.IsNullOrEmpty(textBoxModel.Text) &&
                 !string.IsNullOrEmpty(comboBoxStorage.Text) &&
                 !string.IsNullOrEmpty(comboBoxBattery.Text) &&
                 !string.IsNullOrEmpty(comboBoxRearCamera.Text) &&
                 !string.IsNullOrEmpty(comboBoxFrontCam.Text) &&
                 !string.IsNullOrEmpty(comboBoxRam.Text) &&
                 !string.IsNullOrEmpty(comboBoxGuarantee.Text) &&
                 !string.IsNullOrEmpty(comboBoxProcessor.Text) &&
                 !string.IsNullOrEmpty(textBoxPrice.Text) &&
                 !string.IsNullOrEmpty(comboBoxDisplay.Text) &&
                  !string.IsNullOrEmpty(textBoxIMEI.Text))
            {
                string query2 = "UPDATE Add_phones SET Company='" + textBoxCompany.Text + "', Model='" + textBoxModel.Text + "', Storage='" + comboBoxStorage.Text + "', Battery='" + comboBoxBattery.Text + "' ,[Rear Camera]='" + comboBoxRearCamera.Text + "', [Front Camera]='" + comboBoxFrontCam.Text + "', Ram='" + comboBoxRam.Text + "', Guarantee='" + comboBoxGuarantee.Text + "', Processor='" + comboBoxProcessor.Text + "', Price='" + textBoxPrice.Text + "', Display='" + comboBoxDisplay.Text + "' WHERE IMEI='" + textBoxIMEI.Text + "'";
                SqlCommand cmd = new SqlCommand(query2, con);

                con.Open();

                if (con.State == ConnectionState.Open)
                {
                    int result = cmd.ExecuteNonQuery(); //query execute
                    if (result > 0)
                        MessageBox.Show("Phone Details Updated!!");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Please Fill  All Information!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxCompany.Clear();
            textBoxModel.Clear();
            comboBoxRearCamera.ResetText();
            comboBoxFrontCam.ResetText();
            comboBoxRam.ResetText();
            comboBoxGuarantee.ResetText();
            comboBoxProcessor.ResetText();
            textBoxPrice.Clear();
            comboBoxDisplay.ResetText();
            textBoxIMEI.Clear();
            comboBoxStorage.ResetText();
            comboBoxBattery.ResetText();


        }
    }
    }

