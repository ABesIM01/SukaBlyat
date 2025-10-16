using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelTitle;
        private Guna2TextBox textBoxUsername;
        private Guna2TextBox textBoxEmail;
        private Guna2TextBox textBoxPassword;
        private Guna2Button buttonRegister;
        private Guna2CircleButton buttonBack;
        private Guna2Elipse elipse;
        private Guna2ShadowForm shadowForm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelTitle = new Label();
            this.textBoxUsername = new Guna2TextBox();
            this.textBoxEmail = new Guna2TextBox();
            this.textBoxPassword = new Guna2TextBox();
            this.buttonRegister = new Guna2Button();
            this.buttonBack = new Guna2CircleButton();
            this.elipse = new Guna2Elipse(this.components);
            this.shadowForm = new Guna2ShadowForm(this.components);

            // === RegisterForm ===
            this.BackColor = Color.FromArgb(250, 251, 253);
            this.ClientSize = new Size(420, 550); // збільшена форма
            this.Text = "Реєстрація";
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Закруглення форми
            this.elipse.BorderRadius = 20;
            this.elipse.TargetControl = this;

            // Тінь
            this.shadowForm.SetShadowForm(this);

            // === ButtonBack === 
            this.buttonBack.Size = new Size(40, 40);
            this.buttonBack.Location = new Point(15, 15);
            this.buttonBack.FillColor = Color.White;
            this.buttonBack.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.buttonBack.Image = Image.FromFile(Application.StartupPath + @"\Resources\arrow_back_24dp_E3E3E3.png");
            this.buttonBack.ImageSize = new Size(20, 20);
            this.buttonBack.Cursor = Cursors.Hand;
            this.buttonBack.HoverState.FillColor = Color.FromArgb(240, 240, 240);
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);

            // === LabelTitle ===
            this.labelTitle.Text = "Реєстрація";
            this.labelTitle.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            this.labelTitle.ForeColor = Color.FromArgb(45, 45, 48);
            this.labelTitle.AutoSize = true;

            // Центруємо заголовок по формі
            this.labelTitle.Location = new Point(
                (this.ClientSize.Width - this.labelTitle.PreferredWidth) / 2,
                50 // відступ зверху
            );

            // === TextBoxUsername ===
            this.textBoxUsername.PlaceholderText = "Ім'я користувача";
            this.textBoxUsername.BorderRadius = 12;
            this.textBoxUsername.FillColor = Color.White;
            this.textBoxUsername.Font = new Font("Segoe UI", 10F);
            this.textBoxUsername.Size = new Size(340, 50);
            this.textBoxUsername.Location = new Point(
                (this.ClientSize.Width - this.textBoxUsername.Width) / 2,
                140
            );

            // === TextBoxEmail ===
            this.textBoxEmail.PlaceholderText = "Email";
            this.textBoxEmail.BorderRadius = 12;
            this.textBoxEmail.FillColor = Color.White;
            this.textBoxEmail.Font = new Font("Segoe UI", 10F);
            this.textBoxEmail.Size = new Size(340, 50);
            this.textBoxEmail.Location = new Point(
                (this.ClientSize.Width - this.textBoxEmail.Width) / 2,
                210
            );

            // === TextBoxPassword ===
            this.textBoxPassword.PlaceholderText = "Пароль";
            this.textBoxPassword.PasswordChar = '●';
            this.textBoxPassword.BorderRadius = 12;
            this.textBoxPassword.FillColor = Color.White;
            this.textBoxPassword.Font = new Font("Segoe UI", 10F);
            this.textBoxPassword.Size = new Size(340, 50);
            this.textBoxPassword.Location = new Point(
                (this.ClientSize.Width - this.textBoxPassword.Width) / 2,
                280
            );

            // === ButtonRegister ===
            this.buttonRegister.Text = "Зареєструватися";
            this.buttonRegister.BorderRadius = 12;
            this.buttonRegister.FillColor = Color.FromArgb(94, 148, 255);
            this.buttonRegister.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            this.buttonRegister.ForeColor = Color.White;
            this.buttonRegister.Size = new Size(340, 55);
            this.buttonRegister.Location = new Point(
                (this.ClientSize.Width - this.buttonRegister.Width) / 2,
                360
            );
            this.buttonRegister.HoverState.FillColor = Color.FromArgb(74, 128, 235);
            this.buttonRegister.Cursor = Cursors.Hand;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);

            // === Додаємо контролли на форму ===
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonRegister);
        }
    }
}
