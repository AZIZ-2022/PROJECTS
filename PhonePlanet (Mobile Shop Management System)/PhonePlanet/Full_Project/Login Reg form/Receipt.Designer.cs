
namespace Login_Reg_form
{
    partial class Receipt
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
            this.reciept_button = new System.Windows.Forms.Button();
            this.receipt_back_button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.thank_you_label1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // reciept_button
            // 
            this.reciept_button.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.reciept_button.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reciept_button.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.reciept_button.Location = new System.Drawing.Point(713, 431);
            this.reciept_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reciept_button.Name = "reciept_button";
            this.reciept_button.Size = new System.Drawing.Size(133, 46);
            this.reciept_button.TabIndex = 47;
            this.reciept_button.Text = "Receipt";
            this.reciept_button.UseVisualStyleBackColor = false;
            // 
            // receipt_back_button1
            // 
            this.receipt_back_button1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.receipt_back_button1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.receipt_back_button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.receipt_back_button1.Location = new System.Drawing.Point(51, 431);
            this.receipt_back_button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.receipt_back_button1.Name = "receipt_back_button1";
            this.receipt_back_button1.Size = new System.Drawing.Size(133, 46);
            this.receipt_back_button1.TabIndex = 49;
            this.receipt_back_button1.Text = "Back";
            this.receipt_back_button1.UseVisualStyleBackColor = false;
            this.receipt_back_button1.Click += new System.EventHandler(this.receipt_back_button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Login_Reg_form.Properties.Resources._40957fb4_00bb_4369_9df1_ef9e8f9b6c18;
            this.pictureBox1.Location = new System.Drawing.Point(51, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 331);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // thank_you_label1
            // 
            this.thank_you_label1.AutoSize = true;
            this.thank_you_label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thank_you_label1.Location = new System.Drawing.Point(367, 85);
            this.thank_you_label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.thank_you_label1.Name = "thank_you_label1";
            this.thank_you_label1.Size = new System.Drawing.Size(390, 51);
            this.thank_you_label1.TabIndex = 51;
            this.thank_you_label1.Text = "YOUR PRODUCT ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(525, 180);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 51);
            this.label1.TabIndex = 52;
            this.label1.Text = "IS ON THE WAY";
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.thank_you_label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.receipt_back_button1);
            this.Controls.Add(this.reciept_button);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form8";
            this.Text = "Form8";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button reciept_button;
        private System.Windows.Forms.Button receipt_back_button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label thank_you_label1;
        private System.Windows.Forms.Label label1;
    }
}