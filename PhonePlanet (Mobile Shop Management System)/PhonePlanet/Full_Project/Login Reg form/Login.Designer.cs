namespace Login_Reg_form
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.Log_label = new System.Windows.Forms.Label();
            this.Username_label = new System.Windows.Forms.Label();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.Back = new System.Windows.Forms.Button();
            this.Signin = new System.Windows.Forms.Button();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.Pass_label = new System.Windows.Forms.Label();
            this.Forgotpass = new System.Windows.Forms.Label();
            this.create_new_acc_label = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Log_label
            // 
            this.Log_label.AutoSize = true;
            this.Log_label.BackColor = System.Drawing.Color.White;
            this.Log_label.Font = new System.Drawing.Font("MV Boli", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Log_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Log_label.Location = new System.Drawing.Point(257, 39);
            this.Log_label.Name = "Log_label";
            this.Log_label.Size = new System.Drawing.Size(210, 39);
            this.Log_label.TabIndex = 1;
            this.Log_label.Text = "Login Section";
            this.Log_label.Click += new System.EventHandler(this.Log_label_Click);
            // 
            // Username_label
            // 
            this.Username_label.AutoSize = true;
            this.Username_label.BackColor = System.Drawing.Color.White;
            this.Username_label.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_label.Location = new System.Drawing.Point(187, 146);
            this.Username_label.Name = "Username_label";
            this.Username_label.Size = new System.Drawing.Size(103, 23);
            this.Username_label.TabIndex = 4;
            this.Username_label.Text = "User Name";
            // 
            // tb_username
            // 
            this.tb_username.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_username.Location = new System.Drawing.Point(338, 146);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(165, 28);
            this.tb_username.TabIndex = 8;
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Back.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back.Location = new System.Drawing.Point(38, 354);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(94, 43);
            this.Back.TabIndex = 14;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Signin
            // 
            this.Signin.BackColor = System.Drawing.Color.Cyan;
            this.Signin.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signin.Location = new System.Drawing.Point(624, 272);
            this.Signin.Name = "Signin";
            this.Signin.Size = new System.Drawing.Size(148, 48);
            this.Signin.TabIndex = 13;
            this.Signin.Text = "Login As Customer";
            this.Signin.UseVisualStyleBackColor = false;
            this.Signin.Click += new System.EventHandler(this.CustomerSignin_Click);
            // 
            // tb_password
            // 
            this.tb_password.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_password.Location = new System.Drawing.Point(339, 206);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(165, 28);
            this.tb_password.TabIndex = 12;
            // 
            // Pass_label
            // 
            this.Pass_label.AutoSize = true;
            this.Pass_label.BackColor = System.Drawing.Color.White;
            this.Pass_label.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pass_label.Location = new System.Drawing.Point(190, 207);
            this.Pass_label.Name = "Pass_label";
            this.Pass_label.Size = new System.Drawing.Size(90, 23);
            this.Pass_label.TabIndex = 11;
            this.Pass_label.Text = "Password";
            // 
            // Forgotpass
            // 
            this.Forgotpass.AutoSize = true;
            this.Forgotpass.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Forgotpass.ForeColor = System.Drawing.Color.Black;
            this.Forgotpass.Location = new System.Drawing.Point(248, 332);
            this.Forgotpass.Name = "Forgotpass";
            this.Forgotpass.Size = new System.Drawing.Size(150, 22);
            this.Forgotpass.TabIndex = 16;
            this.Forgotpass.Text = "Forgot Password";
            this.Forgotpass.Click += new System.EventHandler(this.Forgotpass_Click);
            // 
            // create_new_acc_label
            // 
            this.create_new_acc_label.AutoSize = true;
            this.create_new_acc_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create_new_acc_label.ForeColor = System.Drawing.Color.Black;
            this.create_new_acc_label.Location = new System.Drawing.Point(237, 376);
            this.create_new_acc_label.Name = "create_new_acc_label";
            this.create_new_acc_label.Size = new System.Drawing.Size(189, 19);
            this.create_new_acc_label.TabIndex = 17;
            this.create_new_acc_label.Text = "Doesn\'t Have any Account?";
            this.create_new_acc_label.Click += new System.EventHandler(this.create_new_acc_label_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.OrangeRed;
            this.Exit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(691, 354);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(81, 51);
            this.Exit.TabIndex = 21;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Cyan;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(462, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 48);
            this.button1.TabIndex = 22;
            this.button1.Text = "Login As Admin";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Admin_Signin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.create_new_acc_label);
            this.Controls.Add(this.Forgotpass);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Signin);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.Pass_label);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.Username_label);
            this.Controls.Add(this.Log_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Log_label;
        private System.Windows.Forms.Label Username_label;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Signin;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label Pass_label;
        private System.Windows.Forms.Label Forgotpass;
        private System.Windows.Forms.Label create_new_acc_label;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button button1;
    }
}