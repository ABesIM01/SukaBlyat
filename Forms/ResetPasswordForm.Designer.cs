namespace Forms
{
    partial class ResetPasswordForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;

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
            this.ClientSize = new Size(420, 380);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Зміна пароля";

            // ---- Заголовок ----
            Label labelTitle = new Label
            {
                Text = "Зміна пароля",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(400, 50),
                Location = new Point(10, 20)
            };
            this.Controls.Add(labelTitle);

            Label labelSubtitle = new Label
            {
                Text = "Введіть новий пароль та підтвердження",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(100, 100, 100),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(400, 30),
                Location = new Point(10, 60)
            };
            this.Controls.Add(labelSubtitle);

            // ======= Новий пароль =======
            Panel panelNew = new Panel
            {
                Size = new Size(360, 55),
                Location = new Point(30, 110),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            panelNew.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(220, 220, 220)), 0, 0, panelNew.Width - 1, panelNew.Height - 1);
            };
            this.Controls.Add(panelNew);

            Label lblNew = new Label
            {
                Text = "Новий пароль",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(80, 80, 80),
                Location = new Point(15, 5),
                AutoSize = true
            };
            panelNew.Controls.Add(lblNew);

            textBoxNewPassword = new TextBox
            {
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.None,
                PasswordChar = '●',
                Location = new Point(15, 25),
                Width = 300
            };
            panelNew.Controls.Add(textBoxNewPassword);

            // ======= Підтвердження =======
            Panel panelConfirm = new Panel
            {
                Size = new Size(360, 55),
                Location = new Point(30, 180),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            panelConfirm.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(220, 220, 220)), 0, 0, panelConfirm.Width - 1, panelConfirm.Height - 1);
            };
            this.Controls.Add(panelConfirm);

            Label lblConfirm = new Label
            {
                Text = "Підтвердження пароля",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(80, 80, 80),
                Location = new Point(15, 5),
                AutoSize = true
            };
            panelConfirm.Controls.Add(lblConfirm);

            textBoxConfirmPassword = new TextBox
            {
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.None,
                PasswordChar = '●',
                Location = new Point(15, 25),
                Width = 300
            };
            panelConfirm.Controls.Add(textBoxConfirmPassword);

            // ======= Кнопка ЗБЕРЕГТИ =======
            buttonSave = new Button
            {
                Text = "Зберегти",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(0, 120, 215),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(360, 45),
                Location = new Point(30, 260)
            };
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.Click += buttonSave_Click;
            this.Controls.Add(buttonSave);

            // ======= Кнопка СКАСУВАТИ =======
            buttonCancel = new Button
            {
                Text = "Скасувати",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 215),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(360, 45),
                Location = new Point(30, 315)
            };
            buttonCancel.FlatAppearance.BorderColor = Color.FromArgb(0, 120, 215);
            buttonCancel.FlatAppearance.BorderSize = 2;
            buttonCancel.Click += buttonCancel_Click;
            this.Controls.Add(buttonCancel);
        }
    }
}