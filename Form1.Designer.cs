namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxShowPassword;
        private System.Windows.Forms.LinkLabel linkForgotPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelCard = new System.Windows.Forms.Panel();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.linkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(240, 243, 248);
            this.ClientSize = new System.Drawing.Size(420, 480);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизація";
            // 
            // panelCard
            // 
            this.panelCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelCard.Controls.Add(this.buttonRegister);
            this.panelCard.Controls.Add(this.buttonCancel);
            this.panelCard.Controls.Add(this.buttonLogin);
            this.panelCard.Controls.Add(this.linkForgotPassword);
            this.panelCard.Controls.Add(this.checkBoxShowPassword);
            this.panelCard.Controls.Add(this.textBoxPassword);
            this.panelCard.Controls.Add(this.labelPassword);
            this.panelCard.Controls.Add(this.textBoxUsername);
            this.panelCard.Controls.Add(this.labelUsername);
            this.panelCard.Controls.Add(this.labelTitle);
            this.panelCard.Location = new System.Drawing.Point(40, 50);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(340, 380);
            this.panelCard.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(340, 60);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Увійдіть у систему";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.ForeColor = System.Drawing.Color.Gray;
            this.labelUsername.Location = new System.Drawing.Point(40, 80);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(43, 15);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "Логін:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxUsername.Location = new System.Drawing.Point(40, 100);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(260, 25);
            this.textBoxUsername.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.ForeColor = System.Drawing.Color.Gray;
            this.labelPassword.Location = new System.Drawing.Point(40, 145);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(52, 15);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Пароль:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxPassword.Location = new System.Drawing.Point(40, 165);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(260, 25);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.ForeColor = System.Drawing.Color.Gray;
            this.checkBoxShowPassword.Location = new System.Drawing.Point(40, 200);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(123, 19);
            this.checkBoxShowPassword.TabIndex = 5;
            this.checkBoxShowPassword.Text = "Показати пароль";
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowPassword_CheckedChanged);
            // 
            // linkForgotPassword
            // 
            this.linkForgotPassword.AutoSize = true;
            this.linkForgotPassword.LinkColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.linkForgotPassword.Location = new System.Drawing.Point(190, 200);
            this.linkForgotPassword.Name = "linkForgotPassword";
            this.linkForgotPassword.Size = new System.Drawing.Size(103, 15);
            this.linkForgotPassword.TabIndex = 6;
            this.linkForgotPassword.TabStop = true;
            this.linkForgotPassword.Text = "Забули пароль?";
            this.linkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForgotPassword_LinkClicked);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(40, 240);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(260, 40);
            this.buttonLogin.TabIndex = 7;
            this.buttonLogin.Text = "Увійти";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCancel.ForeColor = System.Drawing.Color.Gray;
            this.buttonCancel.Location = new System.Drawing.Point(40, 295);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 35);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Скасувати";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.buttonRegister.FlatAppearance.BorderSize = 0;
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonRegister.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.buttonRegister.Location = new System.Drawing.Point(180, 295);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(120, 35);
            this.buttonRegister.TabIndex = 9;
            this.buttonRegister.Text = "Реєстрація";
            this.buttonRegister.UseVisualStyleBackColor = false;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // Form1
            // 
            this.Controls.Add(this.panelCard);
            this.ResumeLayout(false);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
        }
    }
}
