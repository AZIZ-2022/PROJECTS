namespace Login_Reg_form
{
    partial class Varify_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Varify_Form));
            this.Email_varify = new System.Windows.Forms.Label();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.tb_code = new System.Windows.Forms.TextBox();
            this.Code_varify = new System.Windows.Forms.Label();
            this.button_Varify = new System.Windows.Forms.Button();
            this.button_sendcode = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Email_varify
            // 
            this.Email_varify.AutoSize = true;
            this.Email_varify.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Email_varify.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_varify.Location = new System.Drawing.Point(163, 82);
            this.Email_varify.Name = "Email_varify";
            this.Email_varify.Size = new System.Drawing.Size(162, 25);
            this.Email_varify.TabIndex = 0;
            this.Email_varify.Text = "Enter Your Email";
            // 
            // tb_email
            // 
            this.tb_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_email.Location = new System.Drawing.Point(347, 82);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(154, 22);
            this.tb_email.TabIndex = 1;
            // 
            // tb_code
            // 
            this.tb_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_code.Location = new System.Drawing.Point(347, 248);
            this.tb_code.Name = "tb_code";
            this.tb_code.Size = new System.Drawing.Size(154, 22);
            this.tb_code.TabIndex = 2;
            // 
            // Code_varify
            // 
            this.Code_varify.AutoSize = true;
            this.Code_varify.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Code_varify.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Code_varify.Location = new System.Drawing.Point(163, 248);
            this.Code_varify.Name = "Code_varify";
            this.Code_varify.Size = new System.Drawing.Size(119, 25);
            this.Code_varify.TabIndex = 3;
            this.Code_varify.Text = "Verify Code";
            // 
            // button_Varify
            // 
            this.button_Varify.BackColor = System.Drawing.Color.LawnGreen;
            this.button_Varify.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Varify.Location = new System.Drawing.Point(382, 302);
            this.button_Varify.Name = "button_Varify";
            this.button_Varify.Size = new System.Drawing.Size(84, 30);
            this.button_Varify.TabIndex = 4;
            this.button_Varify.Text = "Verify";
            this.button_Varify.UseVisualStyleBackColor = false;
            this.button_Varify.Click += new System.EventHandler(this.button_Varify_Click);
            // 
            // button_sendcode
            // 
            this.button_sendcode.BackColor = System.Drawing.Color.Turquoise;
            this.button_sendcode.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sendcode.Location = new System.Drawing.Point(382, 137);
            this.button_sendcode.Name = "button_sendcode";
            this.button_sendcode.Size = new System.Drawing.Size(119, 30);
            this.button_sendcode.TabIndex = 5;
            this.button_sendcode.Text = "Send Code";
            this.button_sendcode.UseVisualStyleBackColor = false;
            this.button_sendcode.Click += new System.EventHandler(this.button_sendcode_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Back.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back.Location = new System.Drawing.Point(86, 344);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(82, 33);
            this.Back.TabIndex = 15;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.OrangeRed;
            this.Exit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(670, 344);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(79, 41);
            this.Exit.TabIndex = 22;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Varify_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.button_sendcode);
            this.Controls.Add(this.button_Varify);
            this.Controls.Add(this.Code_varify);
            this.Controls.Add(this.tb_code);
            this.Controls.Add(this.tb_email);
            this.Controls.Add(this.Email_varify);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Varify_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Varification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Email_varify;
        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.TextBox tb_code;
        private System.Windows.Forms.Label Code_varify;
        private System.Windows.Forms.Button button_Varify;
        private System.Windows.Forms.Button button_sendcode;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Exit;
    }
}