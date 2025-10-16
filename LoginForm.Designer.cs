using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp2
{
    partial class LoginForm
    {
        private Label labelTitle;
        private TextBox textBoxEmail;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Button buttonGoogleLogin;
        private Button buttonRegister;
        private Button buttonClose;
        private Panel cardPanel;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // === Форма ===
            this.Text = "Авторизація";
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(460, 600);
            this.BackColor = Color.FromArgb(240, 245, 255);
            this.DoubleBuffered = true;

            // === Кнопка Закрити ===
            buttonClose = new Button();
            buttonClose.Text = "✕";
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.ForeColor = Color.Gray;
            buttonClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonClose.Size = new Size(35, 35);
            buttonClose.Location = new Point(this.ClientSize.Width - 45, 10);
            buttonClose.Cursor = Cursors.Hand;
            buttonClose.Click += (s, e) => this.Close();

            // === Панель (карта входу) ===
            cardPanel = new Panel();
            cardPanel.Size = new Size(360, 440);
            cardPanel.Location = new Point((this.ClientSize.Width - cardPanel.Width) / 2, 90);
            cardPanel.BackColor = Color.White;
            cardPanel.Padding = new Padding(20);
            cardPanel.BorderStyle = BorderStyle.None;
            cardPanel.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, cardPanel.Width, cardPanel.Height, 25, 25)
            );

            // === Заголовок ===
            labelTitle = new Label();
            labelTitle.Text = "Вхід до системи";
            labelTitle.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(35, 40, 60);
            labelTitle.AutoSize = true;

            // Центруємо горизонтально відносно cardPanel
            labelTitle.Location = new Point(
                (cardPanel.Width - labelTitle.PreferredWidth) / 2,
                30 // відступ від верхнього краю панелі
            );


            // === Поле Email ===
            textBoxEmail = new TextBox();
            textBoxEmail.PlaceholderText = "Email";
            textBoxEmail.Font = new Font("Segoe UI", 10.5F);
            textBoxEmail.BackColor = Color.White;
            textBoxEmail.BorderStyle = BorderStyle.None;
            textBoxEmail.Dock = DockStyle.Fill;
            textBoxEmail.Margin = new Padding(0);
            textBoxEmail.Padding = new Padding(10, 8, 10, 8);

            Panel emailPanel = new Panel();
            emailPanel.Size = new Size(290, 35);
            emailPanel.Location = new Point(35, 130);
            emailPanel.BackColor = Color.White;
            emailPanel.Padding = new Padding(0);
            emailPanel.Controls.Add(textBoxEmail);

            emailPanel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                int radius = 10;
                using (Pen pen = new Pen(Color.FromArgb(66, 133, 244), 2f))
                {
                    var rect = new Rectangle(1, 1, emailPanel.Width - 3, emailPanel.Height - 3);
                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                        path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
                        path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                        path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                        path.CloseFigure();
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            // === Поле Пароль ===
            textBoxPassword = new TextBox();
            textBoxPassword.PlaceholderText = "Пароль";
            textBoxPassword.Font = new Font("Segoe UI", 10.5F);
            textBoxPassword.BackColor = Color.White;
            textBoxPassword.BorderStyle = BorderStyle.None;
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPassword.Dock = DockStyle.Fill;
            textBoxPassword.Margin = new Padding(0);
            textBoxPassword.Padding = new Padding(10, 8, 10, 8);

            Panel passwordPanel = new Panel();
            passwordPanel.Size = new Size(290, 35);
            passwordPanel.Location = new Point(35, 190);
            passwordPanel.BackColor = Color.White;
            passwordPanel.Padding = new Padding(0);
            passwordPanel.Controls.Add(textBoxPassword);

            passwordPanel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                int radius = 10;
                using (Pen pen = new Pen(Color.FromArgb(66, 133, 244), 2f))
                {
                    var rect = new Rectangle(1, 1, passwordPanel.Width - 3, passwordPanel.Height - 3);
                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                        path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
                        path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                        path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                        path.CloseFigure();
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };






            // === Кнопка "Увійти" ===
            buttonLogin = new Button();
            buttonLogin.Text = "Увійти";
            buttonLogin.Font = new Font("Segoe UI Semibold", 10.5F);
            buttonLogin.BackColor = Color.FromArgb(66, 133, 244);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.Size = new Size(290, 45);
            buttonLogin.Location = new Point(35, 250);
            buttonLogin.Cursor = Cursors.Hand;
            buttonLogin.Click += buttonLogin_Click;

            // === Кнопка "Google" ===
            buttonGoogleLogin = new Button();
            buttonGoogleLogin.Text = "  Увійти через Google";
            buttonGoogleLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonGoogleLogin.BackColor = Color.White;
            buttonGoogleLogin.ForeColor = Color.FromArgb(60, 60, 60);
            buttonGoogleLogin.FlatStyle = FlatStyle.Flat;
            buttonGoogleLogin.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220);
            buttonGoogleLogin.Size = new Size(290, 42);
            buttonGoogleLogin.Location = new Point(35, 310);
            buttonGoogleLogin.Cursor = Cursors.Hand;
            buttonGoogleLogin.TextAlign = ContentAlignment.MiddleCenter;
            buttonGoogleLogin.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonGoogleLogin.Click += buttonGoogleLogin_Click;

            string iconPath = Path.Combine(Application.StartupPath, "Resources", "google_icon.png");
            if (File.Exists(iconPath))
                buttonGoogleLogin.Image = new Bitmap(Image.FromFile(iconPath), new Size(20, 20));

            // === Кнопка "Зареєструватися" ===
            buttonRegister = new Button();
            buttonRegister.Text = "Створити акаунт";
            buttonRegister.Font = new Font("Segoe UI", 9F);
            buttonRegister.BackColor = Color.Transparent;
            buttonRegister.ForeColor = Color.FromArgb(66, 133, 244);
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.Size = new Size(290, 40);
            buttonRegister.Location = new Point(35, 370);
            buttonRegister.Cursor = Cursors.Hand;
            buttonRegister.Click += buttonRegister_Click;

            // === Додаємо елементи на карту ===
            cardPanel.Controls.Add(labelTitle);
            cardPanel.Controls.Add(emailPanel);
            cardPanel.Controls.Add(passwordPanel);
            cardPanel.Controls.Add(buttonLogin);
            cardPanel.Controls.Add(buttonGoogleLogin);
            cardPanel.Controls.Add(buttonRegister);

            // === Усе додаємо до форми ===
            this.Controls.Add(buttonClose);
            this.Controls.Add(cardPanel);

            this.ResumeLayout(false);
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);
    }
}
