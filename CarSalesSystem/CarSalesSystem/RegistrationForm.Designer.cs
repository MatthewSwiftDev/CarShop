namespace CarSalesSystem
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.PasswordForAdmin = new System.Windows.Forms.TextBox();
            this.ContinueAsGuest = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RePasswordText = new System.Windows.Forms.TextBox();
            this.NumberText = new System.Windows.Forms.TextBox();
            this.NameText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonRegistration = new System.Windows.Forms.Button();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.LoginText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(175)))), ((int)(((byte)(215)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.PasswordForAdmin);
            this.panel1.Controls.Add(this.ContinueAsGuest);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 877);
            this.panel1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(122, 768);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(431, 36);
            this.label7.TabIndex = 13;
            this.label7.Text = "Пароль для Администратора:";
            // 
            // PasswordForAdmin
            // 
            this.PasswordForAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordForAdmin.Location = new System.Drawing.Point(128, 824);
            this.PasswordForAdmin.Name = "PasswordForAdmin";
            this.PasswordForAdmin.Size = new System.Drawing.Size(435, 41);
            this.PasswordForAdmin.TabIndex = 13;
            this.PasswordForAdmin.UseSystemPasswordChar = true;
            this.PasswordForAdmin.TextChanged += new System.EventHandler(this.PasswordForAdmin_TextChanged);
            // 
            // ContinueAsGuest
            // 
            this.ContinueAsGuest.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContinueAsGuest.Location = new System.Drawing.Point(398, 12);
            this.ContinueAsGuest.Name = "ContinueAsGuest";
            this.ContinueAsGuest.Size = new System.Drawing.Size(310, 36);
            this.ContinueAsGuest.TabIndex = 2;
            this.ContinueAsGuest.Text = "Продолжить как гость";
            this.ContinueAsGuest.UseVisualStyleBackColor = true;
            this.ContinueAsGuest.Click += new System.EventHandler(this.ContinueAsGuest_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.RePasswordText);
            this.panel2.Controls.Add(this.NumberText);
            this.panel2.Controls.Add(this.NameText);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.buttonRegistration);
            this.panel2.Controls.Add(this.PasswordText);
            this.panel2.Controls.Add(this.LoginText);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(69, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(558, 691);
            this.panel2.TabIndex = 0;
            // 
            // RePasswordText
            // 
            this.RePasswordText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RePasswordText.Location = new System.Drawing.Point(59, 565);
            this.RePasswordText.Name = "RePasswordText";
            this.RePasswordText.Size = new System.Drawing.Size(435, 41);
            this.RePasswordText.TabIndex = 12;
            this.RePasswordText.UseSystemPasswordChar = true;
            // 
            // NumberText
            // 
            this.NumberText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberText.Location = new System.Drawing.Point(59, 258);
            this.NumberText.Name = "NumberText";
            this.NumberText.Size = new System.Drawing.Size(435, 41);
            this.NumberText.TabIndex = 11;
            // 
            // NameText
            // 
            this.NameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameText.Location = new System.Drawing.Point(59, 155);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(435, 41);
            this.NameText.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(53, 517);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(287, 36);
            this.label6.TabIndex = 9;
            this.label6.Text = "Повторите пароль:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(53, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 36);
            this.label5.TabIndex = 8;
            this.label5.Text = "Номер телефона:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(53, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 36);
            this.label4.TabIndex = 7;
            this.label4.Text = "Имя:";
            // 
            // buttonRegistration
            // 
            this.buttonRegistration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(213)))), ((int)(((byte)(242)))));
            this.buttonRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegistration.Location = new System.Drawing.Point(125, 624);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(301, 42);
            this.buttonRegistration.TabIndex = 6;
            this.buttonRegistration.Text = "Зарегистрироваться";
            this.buttonRegistration.UseVisualStyleBackColor = false;
            this.buttonRegistration.Click += new System.EventHandler(this.buttonRegistration_Click);
            // 
            // PasswordText
            // 
            this.PasswordText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordText.Location = new System.Drawing.Point(59, 464);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(435, 41);
            this.PasswordText.TabIndex = 5;
            this.PasswordText.UseSystemPasswordChar = true;
            // 
            // LoginText
            // 
            this.LoginText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginText.Location = new System.Drawing.Point(59, 360);
            this.LoginText.Name = "LoginText";
            this.LoginText.Size = new System.Drawing.Size(435, 41);
            this.LoginText.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(53, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 36);
            this.label3.TabIndex = 3;
            this.label3.Text = "Пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(53, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Логин:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(552, 91);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(110, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регистрация";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 877);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistrationForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonRegistration;
        private System.Windows.Forms.TextBox PasswordText;
        private System.Windows.Forms.TextBox LoginText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox RePasswordText;
        private System.Windows.Forms.TextBox NumberText;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.Button ContinueAsGuest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PasswordForAdmin;
    }
}