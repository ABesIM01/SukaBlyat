using System.Drawing;
using System.Windows.Forms;

namespace Forms
{
    partial class ForgotPasswordForm
    {
        private Panel panelContainer;
        private Label labelTitle;
        private Label labelSubtitle;

        private Label labelEmail;
        private TextBox textBoxEmail;

        private Button buttonSendOTP;

        private Label labelOTP;
        private TextBox textBoxOTP;

        private Label labelNewPassword;
        private TextBox textBoxNewPassword;

        private Button buttonChangePassword;
        private Button buttonCancel;

        private const int FORM_WIDTH = 500;
        private const int FORM_HEIGHT = 540;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // === FORM ===
            this.BackColor = Color.FromArgb(20, 20, 20);
            this.ClientSize = new Size(FORM_WIDTH, FORM_HEIGHT);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Font = new Font("Segoe UI", 11F);
            this.ForeColor = Color.White;
            this.Text = "Відновлення пароля";

            // === MAIN PANEL (all elements centered) ===
            panelContainer = new Panel();
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.BackColor = Color.FromArgb(20, 20, 20);
            panelContainer.Padding = new Padding(0, 20, 0, 0);
            this.Controls.Add(panelContainer);

            int centerX = (FORM_WIDTH - 300) / 2; // всі елементи шириною 300 px по центру

            // === TITLE ===
            labelTitle = new Label
            {
                Text = "Відновлення пароля",
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 22F),
                AutoSize = true,
                Location = new Point((FORM_WIDTH - 340) / 2, 25) // трохи ширше для центра
            };
            panelContainer.Controls.Add(labelTitle);

            // === SUBTITLE ===
            labelSubtitle = new Label
            {
                Text = "Введіть свою пошту — ми надішлемо OTP",
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 10.5F),
                AutoSize = true,
                Location = new Point((FORM_WIDTH - 340) / 2, 70)
            };
            panelContainer.Controls.Add(labelSubtitle);

            int currentY = 120;

            // === EMAIL LABEL ===
            labelEmail = new Label
            {
                Text = "Пошта:",
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(centerX, currentY)
            };
            panelContainer.Controls.Add(labelEmail);

            // EMAIL FIELD
            textBoxEmail = CreateInput(centerX, currentY + 25);
            panelContainer.Controls.Add(textBoxEmail);

            // SEND OTP BUTTON
            buttonSendOTP = CreateButton("🔑 Отримати OTP", centerX, currentY + 75, 300);
            buttonSendOTP.Click += buttonSendOTP_Click;
            panelContainer.Controls.Add(buttonSendOTP);

            // UPDATE POSITION
            currentY += 140;

            // === OTP LABEL ===
            labelOTP = new Label
            {
                Text = "Введіть OTP:",
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(centerX, currentY)
            };
            panelContainer.Controls.Add(labelOTP);

            // OTP FIELD
            textBoxOTP = CreateInput(centerX, currentY + 25);
            textBoxOTP.Enabled = false;
            panelContainer.Controls.Add(textBoxOTP);

            currentY += 80;

            // === NEW PASSWORD LABEL ===
            labelNewPassword = new Label
            {
                Text = "Новий пароль:",
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(centerX, currentY)
            };
            panelContainer.Controls.Add(labelNewPassword);

            // PASSWORD INPUT
            textBoxNewPassword = CreateInput(centerX, currentY + 25);
            textBoxNewPassword.PasswordChar = '*';
            textBoxNewPassword.Enabled = false;
            panelContainer.Controls.Add(textBoxNewPassword);

            currentY += 90;

            // BUTTONS ROW
            buttonChangePassword = CreateButton("✔ Змінити", centerX, currentY, 145);
            buttonChangePassword.Enabled = false;
            buttonChangePassword.Click += buttonChangePassword_Click;
            panelContainer.Controls.Add(buttonChangePassword);

            buttonCancel = CreateButton("Скасувати", centerX + 155, currentY, 145);
            buttonCancel.BackColor = Color.FromArgb(60, 20, 20);
            buttonCancel.MouseEnter += (s, e) => buttonCancel.BackColor = Color.FromArgb(90, 30, 30);
            buttonCancel.MouseLeave += (s, e) => buttonCancel.BackColor = Color.FromArgb(60, 20, 20);
            buttonCancel.Click += buttonCancel_Click;
            panelContainer.Controls.Add(buttonCancel);

            this.ResumeLayout(false);
        }

        private TextBox CreateInput(int x, int y)
        {
            return new TextBox
            {
                BackColor = Color.FromArgb(35, 35, 35),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 11F),
                Location = new Point(x, y),
                Size = new Size(300, 30)
            };
        }

        private Button CreateButton(string text, int x, int y, int width)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI Semibold", 12F),
                BackColor = Color.FromArgb(35, 35, 35),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(width, 48),
                Location = new Point(x, y),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(60, 60, 60);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(35, 35, 35);
            return btn;
        }
    }
}
