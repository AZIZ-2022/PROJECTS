
namespace Login_Reg_form
{
    partial class Purchase
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchase));
            this.button1 = new System.Windows.Forms.Button();
            this.Purchase_button = new System.Windows.Forms.Button();
            this.phone_label_c = new System.Windows.Forms.Label();
            this.price_label_c = new System.Windows.Forms.Label();
            this.price_label = new System.Windows.Forms.Label();
            this.c_phone_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.discount_label = new System.Windows.Forms.Label();
            this.phone_name_label = new System.Windows.Forms.Label();
            this.company_name_label_c = new System.Windows.Forms.Label();
            this.address_label = new System.Windows.Forms.Label();
            this.userName_label = new System.Windows.Forms.Label();
            this.company_name_label = new System.Windows.Forms.Label();
            this.address_label_c = new System.Windows.Forms.Label();
            this.user_name_label_c = new System.Windows.Forms.Label();
            this.model_name_label_c = new System.Windows.Forms.Label();
            this.quantity_label = new System.Windows.Forms.Label();
            this.quantity_label_c = new System.Windows.Forms.Label();
            this.total_amount_label = new System.Windows.Forms.Label();
            this.discounttb = new System.Windows.Forms.TextBox();
            this.totalamounttb = new System.Windows.Forms.TextBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(37, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 36);
            this.button1.TabIndex = 16;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Purchase_button
            // 
            this.Purchase_button.BackColor = System.Drawing.Color.LightGreen;
            this.Purchase_button.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Purchase_button.ForeColor = System.Drawing.Color.Black;
            this.Purchase_button.Location = new System.Drawing.Point(343, 402);
            this.Purchase_button.Name = "Purchase_button";
            this.Purchase_button.Size = new System.Drawing.Size(138, 36);
            this.Purchase_button.TabIndex = 17;
            this.Purchase_button.Text = "Purchase";
            this.Purchase_button.UseVisualStyleBackColor = false;
            this.Purchase_button.Click += new System.EventHandler(this.Purchase_button_Click);
            // 
            // phone_label_c
            // 
            this.phone_label_c.AutoSize = true;
            this.phone_label_c.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_label_c.Location = new System.Drawing.Point(401, 72);
            this.phone_label_c.Name = "phone_label_c";
            this.phone_label_c.Size = new System.Drawing.Size(40, 22);
            this.phone_label_c.TabIndex = 33;
            this.phone_label_c.Text = "......";
            // 
            // price_label_c
            // 
            this.price_label_c.AutoSize = true;
            this.price_label_c.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.price_label_c.Location = new System.Drawing.Point(401, 334);
            this.price_label_c.Name = "price_label_c";
            this.price_label_c.Size = new System.Drawing.Size(40, 22);
            this.price_label_c.TabIndex = 34;
            this.price_label_c.Text = "......";
            // 
            // price_label
            // 
            this.price_label.AutoSize = true;
            this.price_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.price_label.Location = new System.Drawing.Point(226, 334);
            this.price_label.Name = "price_label";
            this.price_label.Size = new System.Drawing.Size(63, 22);
            this.price_label.TabIndex = 35;
            this.price_label.Text = "Price :";
            // 
            // c_phone_label
            // 
            this.c_phone_label.AutoSize = true;
            this.c_phone_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.c_phone_label.Location = new System.Drawing.Point(226, 72);
            this.c_phone_label.Name = "c_phone_label";
            this.c_phone_label.Size = new System.Drawing.Size(71, 22);
            this.c_phone_label.TabIndex = 42;
            this.c_phone_label.Text = "Phone :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox1.Image = global::Login_Reg_form.Properties.Resources.Bkash_Customer_Care1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // discount_label
            // 
            this.discount_label.AutoSize = true;
            this.discount_label.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discount_label.Location = new System.Drawing.Point(632, 72);
            this.discount_label.Name = "discount_label";
            this.discount_label.Size = new System.Drawing.Size(125, 31);
            this.discount_label.TabIndex = 43;
            this.discount_label.Text = "Discount ";
            // 
            // phone_name_label
            // 
            this.phone_name_label.AutoSize = true;
            this.phone_name_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_name_label.Location = new System.Drawing.Point(225, 175);
            this.phone_name_label.Name = "phone_name_label";
            this.phone_name_label.Size = new System.Drawing.Size(151, 22);
            this.phone_name_label.TabIndex = 45;
            this.phone_name_label.Text = "Company Name :";
            // 
            // company_name_label_c
            // 
            this.company_name_label_c.AutoSize = true;
            this.company_name_label_c.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.company_name_label_c.Location = new System.Drawing.Point(401, 175);
            this.company_name_label_c.Name = "company_name_label_c";
            this.company_name_label_c.Size = new System.Drawing.Size(40, 22);
            this.company_name_label_c.TabIndex = 46;
            this.company_name_label_c.Text = "......";
            // 
            // address_label
            // 
            this.address_label.AutoSize = true;
            this.address_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.address_label.Location = new System.Drawing.Point(226, 124);
            this.address_label.Name = "address_label";
            this.address_label.Size = new System.Drawing.Size(86, 22);
            this.address_label.TabIndex = 48;
            this.address_label.Text = "Address :";
            // 
            // userName_label
            // 
            this.userName_label.AutoSize = true;
            this.userName_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userName_label.Location = new System.Drawing.Point(226, 25);
            this.userName_label.Name = "userName_label";
            this.userName_label.Size = new System.Drawing.Size(116, 22);
            this.userName_label.TabIndex = 49;
            this.userName_label.Text = "User_Name :";
            // 
            // company_name_label
            // 
            this.company_name_label.AutoSize = true;
            this.company_name_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.company_name_label.Location = new System.Drawing.Point(226, 228);
            this.company_name_label.Name = "company_name_label";
            this.company_name_label.Size = new System.Drawing.Size(120, 22);
            this.company_name_label.TabIndex = 50;
            this.company_name_label.Text = "Model Name:";
            // 
            // address_label_c
            // 
            this.address_label_c.AutoSize = true;
            this.address_label_c.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.address_label_c.Location = new System.Drawing.Point(401, 124);
            this.address_label_c.Name = "address_label_c";
            this.address_label_c.Size = new System.Drawing.Size(40, 22);
            this.address_label_c.TabIndex = 52;
            this.address_label_c.Text = "......";
            // 
            // user_name_label_c
            // 
            this.user_name_label_c.AutoSize = true;
            this.user_name_label_c.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.user_name_label_c.Location = new System.Drawing.Point(401, 22);
            this.user_name_label_c.Name = "user_name_label_c";
            this.user_name_label_c.Size = new System.Drawing.Size(40, 22);
            this.user_name_label_c.TabIndex = 53;
            this.user_name_label_c.Text = "......";
            // 
            // model_name_label_c
            // 
            this.model_name_label_c.AutoSize = true;
            this.model_name_label_c.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.model_name_label_c.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.model_name_label_c.Location = new System.Drawing.Point(401, 228);
            this.model_name_label_c.Name = "model_name_label_c";
            this.model_name_label_c.Size = new System.Drawing.Size(40, 22);
            this.model_name_label_c.TabIndex = 54;
            this.model_name_label_c.Text = "......";
            // 
            // quantity_label
            // 
            this.quantity_label.AutoSize = true;
            this.quantity_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quantity_label.Location = new System.Drawing.Point(225, 277);
            this.quantity_label.Name = "quantity_label";
            this.quantity_label.Size = new System.Drawing.Size(91, 22);
            this.quantity_label.TabIndex = 55;
            this.quantity_label.Text = "Quantity :";
            // 
            // quantity_label_c
            // 
            this.quantity_label_c.AutoSize = true;
            this.quantity_label_c.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quantity_label_c.Location = new System.Drawing.Point(401, 277);
            this.quantity_label_c.Name = "quantity_label_c";
            this.quantity_label_c.Size = new System.Drawing.Size(40, 22);
            this.quantity_label_c.TabIndex = 56;
            this.quantity_label_c.Text = "......";
            // 
            // total_amount_label
            // 
            this.total_amount_label.AutoSize = true;
            this.total_amount_label.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.total_amount_label.Location = new System.Drawing.Point(606, 228);
            this.total_amount_label.Name = "total_amount_label";
            this.total_amount_label.Size = new System.Drawing.Size(182, 31);
            this.total_amount_label.TabIndex = 57;
            this.total_amount_label.Text = "Total Amount ";
            // 
            // discounttb
            // 
            this.discounttb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discounttb.Location = new System.Drawing.Point(629, 124);
            this.discounttb.Multiline = true;
            this.discounttb.Name = "discounttb";
            this.discounttb.Size = new System.Drawing.Size(128, 50);
            this.discounttb.TabIndex = 59;
            // 
            // totalamounttb
            // 
            this.totalamounttb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalamounttb.Location = new System.Drawing.Point(611, 290);
            this.totalamounttb.Multiline = true;
            this.totalamounttb.Name = "totalamounttb";
            this.totalamounttb.Size = new System.Drawing.Size(168, 40);
            this.totalamounttb.TabIndex = 60;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGreen;
            this.button2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(674, 402);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 36);
            this.button2.TabIndex = 67;
            this.button2.Text = "Home";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.totalamounttb);
            this.Controls.Add(this.discounttb);
            this.Controls.Add(this.total_amount_label);
            this.Controls.Add(this.quantity_label_c);
            this.Controls.Add(this.quantity_label);
            this.Controls.Add(this.model_name_label_c);
            this.Controls.Add(this.user_name_label_c);
            this.Controls.Add(this.address_label_c);
            this.Controls.Add(this.company_name_label);
            this.Controls.Add(this.userName_label);
            this.Controls.Add(this.address_label);
            this.Controls.Add(this.company_name_label_c);
            this.Controls.Add(this.phone_name_label);
            this.Controls.Add(this.discount_label);
            this.Controls.Add(this.c_phone_label);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.price_label);
            this.Controls.Add(this.price_label_c);
            this.Controls.Add(this.phone_label_c);
            this.Controls.Add(this.Purchase_button);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Purchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Purchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Purchase_button;
        private System.Windows.Forms.Label phone_label_c;
        private System.Windows.Forms.Label price_label_c;
        private System.Windows.Forms.Label price_label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label c_phone_label;
        private System.Windows.Forms.Label discount_label;
        private System.Windows.Forms.Label phone_name_label;
        private System.Windows.Forms.Label company_name_label_c;
        private System.Windows.Forms.Label address_label;
        private System.Windows.Forms.Label userName_label;
        private System.Windows.Forms.Label company_name_label;
        private System.Windows.Forms.Label address_label_c;
        private System.Windows.Forms.Label user_name_label_c;
        private System.Windows.Forms.Label model_name_label_c;
        private System.Windows.Forms.Label quantity_label;
        private System.Windows.Forms.Label quantity_label_c;
        private System.Windows.Forms.Label total_amount_label;
        private System.Windows.Forms.TextBox discounttb;
        private System.Windows.Forms.TextBox totalamounttb;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button button2;
    }
}