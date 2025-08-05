using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Login_Reg_form
{
    public partial class Varify_Form : Form
    {
        string randomCode;
        public static string to;
        public Varify_Form()
        {
            InitializeComponent();
        }
        


        private void button_Varify_Click(object sender, EventArgs e)
        { if(randomCode== (tb_code.Text).ToString())
            {
                to = tb_email.Text;
                Newpass_set newpass_Set = new Newpass_set();
                newpass_Set.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Code!!");
            }
           
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_sendcode_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (tb_email.Text).ToString();
            from = "ayanpaul564@gmail.com"; //...........The mail that receive the code.......
            pass = "ffplhidffuoasmxe"; //............The pass of that mail..creating app pass......
            messageBody = "Your Verify Code is " + randomCode;
            message.To.Add(to);
            message.From=new MailAddress(from);
            message.Body=messageBody;
            message.Subject = "Your Password Reseting Code...";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Code Sent Successfully...");
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);

            }

        }
    }
}
