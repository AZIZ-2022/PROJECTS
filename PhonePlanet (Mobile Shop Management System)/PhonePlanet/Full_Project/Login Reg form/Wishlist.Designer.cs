
namespace Login_Reg_form
{
    partial class Wishlist
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
            this.Wishlist_label = new System.Windows.Forms.Label();
            this.Back_button_compaare = new System.Windows.Forms.Button();
            this.Delete_button = new System.Windows.Forms.Button();
            this.dataGridView_wishlist = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.usertb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_wishlist)).BeginInit();
            this.SuspendLayout();
            // 
            // Wishlist_label
            // 
            this.Wishlist_label.AutoSize = true;
            this.Wishlist_label.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Wishlist_label.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Wishlist_label.Location = new System.Drawing.Point(289, 9);
            this.Wishlist_label.Name = "Wishlist_label";
            this.Wishlist_label.Size = new System.Drawing.Size(79, 24);
            this.Wishlist_label.TabIndex = 1;
            this.Wishlist_label.Text = "Wishlist";
            // 
            // Back_button_compaare
            // 
            this.Back_button_compaare.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Back_button_compaare.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back_button_compaare.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Back_button_compaare.Location = new System.Drawing.Point(66, 364);
            this.Back_button_compaare.Name = "Back_button_compaare";
            this.Back_button_compaare.Size = new System.Drawing.Size(100, 37);
            this.Back_button_compaare.TabIndex = 40;
            this.Back_button_compaare.Text = "Back";
            this.Back_button_compaare.UseVisualStyleBackColor = false;
            this.Back_button_compaare.Click += new System.EventHandler(this.Back_button_compaare_Click);
            // 
            // Delete_button
            // 
            this.Delete_button.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Delete_button.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Delete_button.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Delete_button.Location = new System.Drawing.Point(523, 364);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(100, 37);
            this.Delete_button.TabIndex = 41;
            this.Delete_button.Text = "Delete";
            this.Delete_button.UseVisualStyleBackColor = false;
            // 
            // dataGridView_wishlist
            // 
            this.dataGridView_wishlist.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView_wishlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_wishlist.Location = new System.Drawing.Point(66, 36);
            this.dataGridView_wishlist.Name = "dataGridView_wishlist";
            this.dataGridView_wishlist.RowHeadersWidth = 51;
            this.dataGridView_wishlist.Size = new System.Drawing.Size(574, 294);
            this.dataGridView_wishlist.TabIndex = 46;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Location = new System.Drawing.Point(302, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 37);
            this.button1.TabIndex = 47;
            this.button1.Text = "Purchase";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // usertb
            // 
            this.usertb.Location = new System.Drawing.Point(697, 9);
            this.usertb.Name = "usertb";
            this.usertb.Size = new System.Drawing.Size(100, 20);
            this.usertb.TabIndex = 48;
            // 
            // Wishlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usertb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_wishlist);
            this.Controls.Add(this.Delete_button);
            this.Controls.Add(this.Back_button_compaare);
            this.Controls.Add(this.Wishlist_label);
            this.Name = "Wishlist";
            this.Text = "Form7";
            this.Load += new System.EventHandler(this.Wishlist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_wishlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Wishlist_label;
        private System.Windows.Forms.Button Back_button_compaare;
        private System.Windows.Forms.Button Delete_button;
        private System.Windows.Forms.DataGridView dataGridView_wishlist;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox usertb;
    }
}