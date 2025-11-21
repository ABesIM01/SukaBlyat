namespace Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox textBoxUsername;
        private TextBox textBoxEmail;
        private TextBox textBoxPassword;

        private Button buttonRegister;
        private Button buttonBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.BackColor = Color.White;
            this.ClientSize = new Size(450, 540);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Реєстрація";
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // ---- Title ----
            Label labelTitle = new Label();
            labelTitle.Text = "Реєстрація";
            labelTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(0, 51, 102);
            labelTitle.AutoSize = false;
            labelTitle.Size = new Size(430, 60);
            labelTitle.Location = new Point(10, 25);
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(labelTitle);

            // ---- Subtitle ----
            Label labelSubtitle = new Label();
            labelSubtitle.Text = "Створіть новий обліковий запис";
            labelSubtitle.Font = new Font("Segoe UI", 11F);
            labelSubtitle.ForeColor = Color.Gray;
            labelSubtitle.AutoSize = false;
            labelSubtitle.Size = new Size(430, 30);
            labelSubtitle.Location = new Point(10, 80);
            labelSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(labelSubtitle);

            // -----------------------
            // PANELS with TEXTBOXES
            // -----------------------
            Panel panelUsername = CreateInputPanel("Ім'я користувача", out textBoxUsername);
            panelUsername.Location = new Point(45, 140);
            this.Controls.Add(panelUsername);

            Panel panelEmail = CreateInputPanel("Email", out textBoxEmail);
            panelEmail.Location = new Point(45, 215);
            this.Controls.Add(panelEmail);

            Panel panelPassword = CreateInputPanel("Пароль", out textBoxPassword, password: true);
            panelPassword.Location = new Point(45, 290);
            this.Controls.Add(panelPassword);

            // ---- Register button ----
            buttonRegister = new Button();
            buttonRegister.Text = "Зареєструватися";
            buttonRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonRegister.ForeColor = Color.White;
            buttonRegister.BackColor = Color.FromArgb(0, 120, 215);
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.Size = new Size(360, 50);
            buttonRegister.Location = new Point(45, 370);
            buttonRegister.Click += buttonRegister_Click;
            this.Controls.Add(buttonRegister);

            // ---- Back button ----
            buttonBack = new Button();
            buttonBack.Text = "← Назад";
            buttonBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonBack.ForeColor = Color.FromArgb(0, 120, 215);
            buttonBack.BackColor = Color.White;
            buttonBack.FlatAppearance.BorderSize = 2;
            buttonBack.FlatStyle = FlatStyle.Flat;
            buttonBack.Size = new Size(360, 45);
            buttonBack.Location = new Point(45, 430);
            buttonBack.Click += buttonBack_Click;
            this.Controls.Add(buttonBack);
        }


        // ============================================
        // Helper: Create nice input panels
        // ============================================
        private Panel CreateInputPanel(string title, out TextBox tb, bool password = false)
        {
            Panel panel = new Panel();
            panel.Size = new Size(360, 55);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;

            panel.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(
                    new Pen(Color.FromArgb(220, 220, 220)),
                    0, 0, panel.Width - 1, panel.Height - 1
                );
            };

            Label lbl = new Label();
            lbl.Text = title;
            lbl.Font = new Font("Segoe UI", 8F);
            lbl.ForeColor = Color.FromArgb(80, 80, 80);
            lbl.Location = new Point(12, 5);
            lbl.AutoSize = true;
            panel.Controls.Add(lbl);

            tb = new TextBox();
            tb.Font = new Font("Segoe UI", 10F);
            tb.BorderStyle = BorderStyle.None;
            tb.Location = new Point(12, 25);
            tb.Width = 330;
            if (password) tb.PasswordChar = '●';
            panel.Controls.Add(tb);

            return panel;
        }
    }
}