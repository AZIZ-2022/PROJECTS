
namespace Login_Reg_form
{
    partial class DeletePhone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeletePhone));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DeleteSearch = new System.Windows.Forms.TextBox();
            this.DataGridViewDelete = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.companytxt = new System.Windows.Forms.TextBox();
            this.modeltxt = new System.Windows.Forms.TextBox();
            this.imeitxt = new System.Windows.Forms.TextBox();
            this.DeletePhoneButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Rockwell", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "        DELETE PHONE ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(127, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(373, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Search By :  Company / Model  / IMEI Number";
            // 
            // DeleteSearch
            // 
            this.DeleteSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSearch.Location = new System.Drawing.Point(131, 107);
            this.DeleteSearch.Multiline = true;
            this.DeleteSearch.Name = "DeleteSearch";
            this.DeleteSearch.Size = new System.Drawing.Size(293, 29);
            this.DeleteSearch.TabIndex = 10;
            this.DeleteSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeleteSearch_KeyDown);
            // 
            // DataGridViewDelete
            // 
            this.DataGridViewDelete.BackgroundColor = System.Drawing.Color.White;
            this.DataGridViewDelete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewDelete.Location = new System.Drawing.Point(28, 154);
            this.DataGridViewDelete.Name = "DataGridViewDelete";
            this.DataGridViewDelete.Size = new System.Drawing.Size(472, 275);
            this.DataGridViewDelete.TabIndex = 12;
            this.DataGridViewDelete.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewDelete_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(599, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(530, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Company Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(530, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Model Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(530, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "IMEI Number";
            // 
            // companytxt
            // 
            this.companytxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companytxt.Location = new System.Drawing.Point(670, 216);
            this.companytxt.Name = "companytxt";
            this.companytxt.Size = new System.Drawing.Size(129, 22);
            this.companytxt.TabIndex = 18;
            // 
            // modeltxt
            // 
            this.modeltxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeltxt.Location = new System.Drawing.Point(670, 257);
            this.modeltxt.Name = "modeltxt";
            this.modeltxt.Size = new System.Drawing.Size(129, 22);
            this.modeltxt.TabIndex = 19;
            // 
            // imeitxt
            // 
            this.imeitxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imeitxt.Location = new System.Drawing.Point(670, 299);
            this.imeitxt.Name = "imeitxt";
            this.imeitxt.Size = new System.Drawing.Size(129, 22);
            this.imeitxt.TabIndex = 20;
            // 
            // DeletePhoneButton
            // 
            this.DeletePhoneButton.BackColor = System.Drawing.Color.Crimson;
            this.DeletePhoneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeletePhoneButton.Location = new System.Drawing.Point(617, 370);
            this.DeletePhoneButton.Name = "DeletePhoneButton";
            this.DeletePhoneButton.Size = new System.Drawing.Size(182, 46);
            this.DeletePhoneButton.TabIndex = 21;
            this.DeletePhoneButton.Text = "DELETE PHONE";
            this.DeletePhoneButton.UseVisualStyleBackColor = false;
            this.DeletePhoneButton.Click += new System.EventHandler(this.DeletePhoneButton_Click);
            // 
            // DeletePhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.DeletePhoneButton);
            this.Controls.Add(this.imeitxt);
            this.Controls.Add(this.modeltxt);
            this.Controls.Add(this.companytxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DataGridViewDelete);
            this.Controls.Add(this.DeleteSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DeletePhone";
            this.Size = new System.Drawing.Size(816, 519);
            this.Enter += new System.EventHandler(this.DeletePhone_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DeleteSearch;
        private System.Windows.Forms.DataGridView DataGridViewDelete;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox companytxt;
        private System.Windows.Forms.TextBox modeltxt;
        private System.Windows.Forms.TextBox imeitxt;
        private System.Windows.Forms.Button DeletePhoneButton;
    }
}
