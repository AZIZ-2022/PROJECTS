
namespace Login_Reg_form
{
    partial class Purchase_History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchase_History));
            this.Purchaese_history_label = new System.Windows.Forms.Label();
            this.Back_button_history = new System.Windows.Forms.Button();
            this.purchasehistory_grid = new System.Windows.Forms.DataGridView();
            this.lblmodelname = new System.Windows.Forms.Label();
            this.Company_label = new System.Windows.Forms.Label();
            this.Model_label = new System.Windows.Forms.Label();
            this.ram_label = new System.Windows.Forms.Label();
            this.storage_label = new System.Windows.Forms.Label();
            this.back_label = new System.Windows.Forms.Label();
            this.display_label = new System.Windows.Forms.Label();
            this.lblcususername = new System.Windows.Forms.Label();
            this.lblprice = new System.Windows.Forms.Label();
            this.lbltotalprice = new System.Windows.Forms.Label();
            this.lblcompany = new System.Windows.Forms.Label();
            this.lblquantity = new System.Windows.Forms.Label();
            this.lbldiscount = new System.Windows.Forms.Label();
            this.phone_ID_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.purchasehistory_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Purchaese_history_label
            // 
            this.Purchaese_history_label.AutoSize = true;
            this.Purchaese_history_label.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Purchaese_history_label.Location = new System.Drawing.Point(46, 21);
            this.Purchaese_history_label.Name = "Purchaese_history_label";
            this.Purchaese_history_label.Size = new System.Drawing.Size(295, 31);
            this.Purchaese_history_label.TabIndex = 0;
            this.Purchaese_history_label.Text = "PURCHASE HISTORY";
            // 
            // Back_button_history
            // 
            this.Back_button_history.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Back_button_history.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back_button_history.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Back_button_history.Location = new System.Drawing.Point(12, 394);
            this.Back_button_history.Name = "Back_button_history";
            this.Back_button_history.Size = new System.Drawing.Size(131, 44);
            this.Back_button_history.TabIndex = 8;
            this.Back_button_history.Text = "Back";
            this.Back_button_history.UseVisualStyleBackColor = false;
            this.Back_button_history.Click += new System.EventHandler(this.Back_button_history_Click);
            // 
            // purchasehistory_grid
            // 
            this.purchasehistory_grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.purchasehistory_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.purchasehistory_grid.Location = new System.Drawing.Point(10, 69);
            this.purchasehistory_grid.Name = "purchasehistory_grid";
            this.purchasehistory_grid.RowHeadersWidth = 51;
            this.purchasehistory_grid.Size = new System.Drawing.Size(407, 308);
            this.purchasehistory_grid.TabIndex = 43;
            this.purchasehistory_grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.purchasehistory_grid_CellClick);
            // 
            // lblmodelname
            // 
            this.lblmodelname.AutoSize = true;
            this.lblmodelname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmodelname.ForeColor = System.Drawing.Color.Black;
            this.lblmodelname.Location = new System.Drawing.Point(639, 168);
            this.lblmodelname.Name = "lblmodelname";
            this.lblmodelname.Size = new System.Drawing.Size(40, 24);
            this.lblmodelname.TabIndex = 83;
            this.lblmodelname.Text = "......";
            // 
            // Company_label
            // 
            this.Company_label.AutoSize = true;
            this.Company_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Company_label.ForeColor = System.Drawing.Color.Black;
            this.Company_label.Location = new System.Drawing.Point(464, 116);
            this.Company_label.Name = "Company_label";
            this.Company_label.Size = new System.Drawing.Size(93, 22);
            this.Company_label.TabIndex = 85;
            this.Company_label.Text = "Company ";
            // 
            // Model_label
            // 
            this.Model_label.AutoSize = true;
            this.Model_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Model_label.ForeColor = System.Drawing.Color.Black;
            this.Model_label.Location = new System.Drawing.Point(464, 170);
            this.Model_label.Name = "Model_label";
            this.Model_label.Size = new System.Drawing.Size(115, 22);
            this.Model_label.TabIndex = 86;
            this.Model_label.Text = "Model Name";
            // 
            // ram_label
            // 
            this.ram_label.AutoSize = true;
            this.ram_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ram_label.ForeColor = System.Drawing.Color.Black;
            this.ram_label.Location = new System.Drawing.Point(465, 216);
            this.ram_label.Name = "ram_label";
            this.ram_label.Size = new System.Drawing.Size(81, 22);
            this.ram_label.TabIndex = 87;
            this.ram_label.Text = "Quantity";
            // 
            // storage_label
            // 
            this.storage_label.AutoSize = true;
            this.storage_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.storage_label.ForeColor = System.Drawing.Color.Black;
            this.storage_label.Location = new System.Drawing.Point(465, 263);
            this.storage_label.Name = "storage_label";
            this.storage_label.Size = new System.Drawing.Size(53, 22);
            this.storage_label.TabIndex = 88;
            this.storage_label.Text = "Price";
            // 
            // back_label
            // 
            this.back_label.AutoSize = true;
            this.back_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.back_label.ForeColor = System.Drawing.Color.Black;
            this.back_label.Location = new System.Drawing.Point(464, 355);
            this.back_label.Name = "back_label";
            this.back_label.Size = new System.Drawing.Size(100, 22);
            this.back_label.TabIndex = 89;
            this.back_label.Text = "Total Price";
            // 
            // display_label
            // 
            this.display_label.AutoSize = true;
            this.display_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.display_label.ForeColor = System.Drawing.Color.Black;
            this.display_label.Location = new System.Drawing.Point(464, 309);
            this.display_label.Name = "display_label";
            this.display_label.Size = new System.Drawing.Size(82, 22);
            this.display_label.TabIndex = 90;
            this.display_label.Text = "Discount";
            // 
            // lblcususername
            // 
            this.lblcususername.AutoSize = true;
            this.lblcususername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcususername.ForeColor = System.Drawing.Color.Black;
            this.lblcususername.Location = new System.Drawing.Point(639, 67);
            this.lblcususername.Name = "lblcususername";
            this.lblcususername.Size = new System.Drawing.Size(40, 24);
            this.lblcususername.TabIndex = 97;
            this.lblcususername.Text = "......";
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprice.ForeColor = System.Drawing.Color.Black;
            this.lblprice.Location = new System.Drawing.Point(639, 263);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(40, 24);
            this.lblprice.TabIndex = 98;
            this.lblprice.Text = "......";
            // 
            // lbltotalprice
            // 
            this.lbltotalprice.AutoSize = true;
            this.lbltotalprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalprice.ForeColor = System.Drawing.Color.Black;
            this.lbltotalprice.Location = new System.Drawing.Point(639, 353);
            this.lbltotalprice.Name = "lbltotalprice";
            this.lbltotalprice.Size = new System.Drawing.Size(40, 24);
            this.lbltotalprice.TabIndex = 99;
            this.lbltotalprice.Text = "......";
            // 
            // lblcompany
            // 
            this.lblcompany.AutoSize = true;
            this.lblcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcompany.ForeColor = System.Drawing.Color.Black;
            this.lblcompany.Location = new System.Drawing.Point(639, 116);
            this.lblcompany.Name = "lblcompany";
            this.lblcompany.Size = new System.Drawing.Size(40, 24);
            this.lblcompany.TabIndex = 103;
            this.lblcompany.Text = "......";
            // 
            // lblquantity
            // 
            this.lblquantity.AutoSize = true;
            this.lblquantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblquantity.ForeColor = System.Drawing.Color.Black;
            this.lblquantity.Location = new System.Drawing.Point(639, 216);
            this.lblquantity.Name = "lblquantity";
            this.lblquantity.Size = new System.Drawing.Size(40, 24);
            this.lblquantity.TabIndex = 104;
            this.lblquantity.Text = "......";
            // 
            // lbldiscount
            // 
            this.lbldiscount.AutoSize = true;
            this.lbldiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldiscount.ForeColor = System.Drawing.Color.Black;
            this.lbldiscount.Location = new System.Drawing.Point(639, 307);
            this.lbldiscount.Name = "lbldiscount";
            this.lbldiscount.Size = new System.Drawing.Size(40, 24);
            this.lbldiscount.TabIndex = 105;
            this.lbldiscount.Text = "......";
            // 
            // phone_ID_label
            // 
            this.phone_ID_label.AutoSize = true;
            this.phone_ID_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_ID_label.ForeColor = System.Drawing.Color.Black;
            this.phone_ID_label.Location = new System.Drawing.Point(463, 69);
            this.phone_ID_label.Name = "phone_ID_label";
            this.phone_ID_label.Size = new System.Drawing.Size(101, 22);
            this.phone_ID_label.TabIndex = 84;
            this.phone_ID_label.Text = "User Name";
            // 
            // Purchase_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbldiscount);
            this.Controls.Add(this.lblquantity);
            this.Controls.Add(this.lblcompany);
            this.Controls.Add(this.lbltotalprice);
            this.Controls.Add(this.lblprice);
            this.Controls.Add(this.lblcususername);
            this.Controls.Add(this.display_label);
            this.Controls.Add(this.back_label);
            this.Controls.Add(this.storage_label);
            this.Controls.Add(this.ram_label);
            this.Controls.Add(this.Model_label);
            this.Controls.Add(this.Company_label);
            this.Controls.Add(this.phone_ID_label);
            this.Controls.Add(this.lblmodelname);
            this.Controls.Add(this.purchasehistory_grid);
            this.Controls.Add(this.Back_button_history);
            this.Controls.Add(this.Purchaese_history_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Purchase_History";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Purchase_History_Load);
            ((System.ComponentModel.ISupportInitialize)(this.purchasehistory_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Purchaese_history_label;
        private System.Windows.Forms.Button Back_button_history;
        private System.Windows.Forms.DataGridView purchasehistory_grid;
        private System.Windows.Forms.Label lblmodelname;
        private System.Windows.Forms.Label Company_label;
        private System.Windows.Forms.Label Model_label;
        private System.Windows.Forms.Label ram_label;
        private System.Windows.Forms.Label storage_label;
        private System.Windows.Forms.Label back_label;
        private System.Windows.Forms.Label display_label;
        private System.Windows.Forms.Label lblcususername;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.Label lbltotalprice;
        private System.Windows.Forms.Label lblcompany;
        private System.Windows.Forms.Label lblquantity;
        private System.Windows.Forms.Label lbldiscount;
        private System.Windows.Forms.Label phone_ID_label;
    }
}