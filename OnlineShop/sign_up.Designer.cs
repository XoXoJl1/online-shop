namespace OnlineShop
{
    partial class sign_up
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.CreateAccountButton = new System.Windows.Forms.Button();
            this.HidePassword = new System.Windows.Forms.PictureBox();
            this.ShowPassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.HidePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 13.8F);
            this.label1.Location = new System.Drawing.Point(122, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регистрация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.label2.Location = new System.Drawing.Point(54, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Придумайте логин:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.label3.Location = new System.Drawing.Point(54, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Придумайте пароль:";
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Font = new System.Drawing.Font("Cascadia Mono", 10.2F);
            this.LoginTextBox.Location = new System.Drawing.Point(58, 144);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(257, 27);
            this.LoginTextBox.TabIndex = 3;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Cascadia Mono", 10.2F);
            this.PasswordTextBox.Location = new System.Drawing.Point(58, 258);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(255, 27);
            this.PasswordTextBox.TabIndex = 4;
            // 
            // CreateAccountButton
            // 
            this.CreateAccountButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CreateAccountButton.FlatAppearance.BorderSize = 0;
            this.CreateAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateAccountButton.Font = new System.Drawing.Font("Cascadia Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateAccountButton.Location = new System.Drawing.Point(99, 304);
            this.CreateAccountButton.Name = "CreateAccountButton";
            this.CreateAccountButton.Size = new System.Drawing.Size(187, 46);
            this.CreateAccountButton.TabIndex = 5;
            this.CreateAccountButton.Text = "Создать аккаунт";
            this.CreateAccountButton.UseVisualStyleBackColor = false;
            this.CreateAccountButton.Click += new System.EventHandler(this.CreateAccountButton_Click);
            // 
            // HidePassword
            // 
            this.HidePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HidePassword.Image = global::OnlineShop.Properties.Resources.hide;
            this.HidePassword.Location = new System.Drawing.Point(319, 259);
            this.HidePassword.Name = "HidePassword";
            this.HidePassword.Size = new System.Drawing.Size(39, 26);
            this.HidePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HidePassword.TabIndex = 7;
            this.HidePassword.TabStop = false;
            this.HidePassword.Click += new System.EventHandler(this.HidePassword_Click);
            // 
            // ShowPassword
            // 
            this.ShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShowPassword.Image = global::OnlineShop.Properties.Resources.show;
            this.ShowPassword.Location = new System.Drawing.Point(319, 258);
            this.ShowPassword.Name = "ShowPassword";
            this.ShowPassword.Size = new System.Drawing.Size(40, 27);
            this.ShowPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ShowPassword.TabIndex = 6;
            this.ShowPassword.TabStop = false;
            this.ShowPassword.Click += new System.EventHandler(this.ShowPassword_Click);
            // 
            // sign_up
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 380);
            this.Controls.Add(this.HidePassword);
            this.Controls.Add(this.ShowPassword);
            this.Controls.Add(this.CreateAccountButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "sign_up";
            this.Text = "sign_up";
            this.Load += new System.EventHandler(this.sign_up_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HidePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button CreateAccountButton;
        private System.Windows.Forms.PictureBox ShowPassword;
        private System.Windows.Forms.PictureBox HidePassword;
    }
}