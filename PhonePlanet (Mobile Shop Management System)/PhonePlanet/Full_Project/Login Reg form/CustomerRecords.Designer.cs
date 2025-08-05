
namespace Login_Reg_form
{
    partial class CustomerRecords
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerRecords));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.customersearchtxt = new System.Windows.Forms.TextBox();
            this.dataGridViewcustomerhistory = new System.Windows.Forms.DataGridView();
            this.banbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.customerphone = new System.Windows.Forms.Label();
            this.usertb = new System.Windows.Forms.TextBox();
            this.phonetb = new System.Windows.Forms.TextBox();
            this.emailtb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewcustomerhistory)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 151);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Rockwell", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(236, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "        CUSTOMER RECORD\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(238, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search By Username / Phone No / Email";
            // 
            // customersearchtxt
            // 
            this.customersearchtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customersearchtxt.Location = new System.Drawing.Point(579, 85);
            this.customersearchtxt.Multiline = true;
            this.customersearchtxt.Name = "customersearchtxt";
            this.customersearchtxt.Size = new System.Drawing.Size(198, 27);
            this.customersearchtxt.TabIndex = 9;
            this.customersearchtxt.TextChanged += new System.EventHandler(this.customersearchtxt_TextChanged);
            // 
            // dataGridViewcustomerhistory
            // 
            this.dataGridViewcustomerhistory.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewcustomerhistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewcustomerhistory.Location = new System.Drawing.Point(4, 160);
            this.dataGridViewcustomerhistory.Name = "dataGridViewcustomerhistory";
            this.dataGridViewcustomerhistory.Size = new System.Drawing.Size(555, 209);
            this.dataGridViewcustomerhistory.TabIndex = 10;
            this.dataGridViewcustomerhistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewcustomerhistory_CellClick);
            // 
            // banbutton
            // 
            this.banbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.banbutton.Location = new System.Drawing.Point(613, 384);
            this.banbutton.Name = "banbutton";
            this.banbutton.Size = new System.Drawing.Size(164, 43);
            this.banbutton.TabIndex = 11;
            this.banbutton.Text = "Ban Customer";
            this.banbutton.UseVisualStyleBackColor = true;
            this.banbutton.Click += new System.EventHandler(this.banbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(579, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(579, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Phone No :";
            // 
            // customerphone
            // 
            this.customerphone.AutoSize = true;
            this.customerphone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerphone.Location = new System.Drawing.Point(579, 286);
            this.customerphone.Name = "customerphone";
            this.customerphone.Size = new System.Drawing.Size(56, 20);
            this.customerphone.TabIndex = 14;
            this.customerphone.Text = "Email :";
            // 
            // usertb
            // 
            this.usertb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usertb.Location = new System.Drawing.Point(695, 173);
            this.usertb.Name = "usertb";
            this.usertb.Size = new System.Drawing.Size(100, 22);
            this.usertb.TabIndex = 15;
            // 
            // phonetb
            // 
            this.phonetb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phonetb.Location = new System.Drawing.Point(695, 233);
            this.phonetb.Name = "phonetb";
            this.phonetb.Size = new System.Drawing.Size(100, 22);
            this.phonetb.TabIndex = 16;
            // 
            // emailtb
            // 
            this.emailtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailtb.Location = new System.Drawing.Point(695, 288);
            this.emailtb.Name = "emailtb";
            this.emailtb.Size = new System.Drawing.Size(100, 22);
            this.emailtb.TabIndex = 17;
            // 
            // CustomerRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.emailtb);
            this.Controls.Add(this.phonetb);
            this.Controls.Add(this.usertb);
            this.Controls.Add(this.customerphone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.banbutton);
            this.Controls.Add(this.dataGridViewcustomerhistory);
            this.Controls.Add(this.customersearchtxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CustomerRecords";
            this.Size = new System.Drawing.Size(814, 443);
            this.Enter += new System.EventHandler(this.CustomerRecords_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewcustomerhistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox customersearchtxt;
        private System.Windows.Forms.DataGridView dataGridViewcustomerhistory;
        private System.Windows.Forms.Button banbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label customerphone;
        private System.Windows.Forms.TextBox usertb;
        private System.Windows.Forms.TextBox phonetb;
        private System.Windows.Forms.TextBox emailtb;
    }
}
