using System.Drawing.Drawing2D;

namespace Forms
{
    partial class ForgotPasswordForm
    {
        private Panel panelContainer;
        private Label labelTitle;
        private Label labelSubtitle;
        private Panel panelUsername;
        private Label labelUsername;
        private TextBox textBoxUsername;
        private Panel panelEmail;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Button buttonSearch;
        private Label labelQuestion;
        private Panel panelAnswer;
        private TextBox textBoxAnswer;
        private Button buttonRecover;
        private Button buttonCancel;

        private const int FORM_WIDTH = 420;
        private const int FORM_HEIGHT = 480;
        private const int CONTENT_WIDTH = 320;
        private const int CONTENT_MARGIN = 50;
        private const int ELEMENT_HEIGHT = 50;
        private const int SPACING = 15;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // === FORM ===
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(FORM_WIDTH, FORM_HEIGHT);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
            this.Padding = new Padding(1);

            // === PANEL CONTAINER ===
            panelContainer = new Panel();
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.BackColor = Color.FromArgb(250, 250, 252);
            panelContainer.Paint += PanelContainer_Paint;
            this.Controls.Add(panelContainer);

            // === HEADER ===
            labelTitle = new Label();
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(0, 51, 102);
            labelTitle.Text = "Відновлення пароля";
            labelTitle.Size = new Size(CONTENT_WIDTH, 40);
            labelTitle.Location = new Point(CONTENT_MARGIN, 30);
            panelContainer.Controls.Add(labelTitle);

            labelSubtitle = new Label();
            labelSubtitle.Font = new Font("Segoe UI", 10F);
            labelSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            labelSubtitle.Text = "Знайдемо ваш акаунт";
            labelSubtitle.Size = new Size(CONTENT_WIDTH, 30);
            labelSubtitle.Location = new Point(CONTENT_MARGIN, 70);
            panelContainer.Controls.Add(labelSubtitle);

            // === USERNAME ===
            panelUsername = new Panel();
            panelUsername.BackColor = Color.White;
            panelUsername.BorderStyle = BorderStyle.FixedSingle;
            panelUsername.Size = new Size(CONTENT_WIDTH, ELEMENT_HEIGHT);
            panelUsername.Location = new Point(CONTENT_MARGIN, 120);
            panelContainer.Controls.Add(panelUsername);

            labelUsername = new Label();
            labelUsername.Text = "Логін";
            labelUsername.Font = new Font("Segoe UI", 8F);
            labelUsername.ForeColor = Color.FromArgb(80, 80, 80);
            labelUsername.Location = new Point(10, 5);
            panelUsername.Controls.Add(labelUsername);

            textBoxUsername = new TextBox();
            textBoxUsername.BorderStyle = BorderStyle.None;
            textBoxUsername.Font = new Font("Segoe UI", 10F);
            textBoxUsername.ForeColor = Color.Black;
            textBoxUsername.Location = new Point(10, 25);
            textBoxUsername.Width = 290;
            panelUsername.Controls.Add(textBoxUsername);

            // === EMAIL ===
            panelEmail = new Panel();
            panelEmail.BackColor = Color.White;
            panelEmail.BorderStyle = BorderStyle.FixedSingle;
            panelEmail.Size = new Size(CONTENT_WIDTH, ELEMENT_HEIGHT);
            panelEmail.Location = new Point(CONTENT_MARGIN, 120 + ELEMENT_HEIGHT + SPACING);
            panelContainer.Controls.Add(panelEmail);

            labelEmail = new Label();
            labelEmail.Text = "Пошта";
            labelEmail.Font = new Font("Segoe UI", 8F);
            labelEmail.ForeColor = Color.FromArgb(80, 80, 80);
            labelEmail.Location = new Point(10, 5);
            panelEmail.Controls.Add(labelEmail);

            textBoxEmail = new TextBox();
            textBoxEmail.BorderStyle = BorderStyle.None;
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.ForeColor = Color.Black;
            textBoxEmail.Location = new Point(10, 25);
            textBoxEmail.Width = 290;
            panelEmail.Controls.Add(textBoxEmail);

            // === Search button ===
            buttonSearch = new Button();
            buttonSearch.Text = "🔍 Знайти користувача";
            buttonSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSearch.BackColor = Color.FromArgb(0, 120, 215);
            buttonSearch.ForeColor = Color.White;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.FlatAppearance.BorderSize = 0;
            buttonSearch.Size = new Size(CONTENT_WIDTH, 45);
            buttonSearch.Location = new Point(CONTENT_MARGIN, 230);
            buttonSearch.Click += buttonSearch_Click;
            panelContainer.Controls.Add(buttonSearch);

            // === SECURITY QUESTION ===
            labelQuestion = new Label();
            labelQuestion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelQuestion.ForeColor = Color.FromArgb(0, 51, 102);
            labelQuestion.Location = new Point(CONTENT_MARGIN, 285);
            labelQuestion.Size = new Size(CONTENT_WIDTH, 20);
            panelContainer.Controls.Add(labelQuestion);

            panelAnswer = new Panel();
            panelAnswer.BackColor = Color.White;
            panelAnswer.BorderStyle = BorderStyle.FixedSingle;
            panelAnswer.Size = new Size(CONTENT_WIDTH, ELEMENT_HEIGHT);
            panelAnswer.Location = new Point(CONTENT_MARGIN, 310);
            panelAnswer.Enabled = false;
            panelContainer.Controls.Add(panelAnswer);

            textBoxAnswer = new TextBox();
            textBoxAnswer.BorderStyle = BorderStyle.None;
            textBoxAnswer.Font = new Font("Segoe UI", 10F);
            textBoxAnswer.Location = new Point(10, 15);
            textBoxAnswer.Width = 290;
            panelAnswer.Controls.Add(textBoxAnswer);

            // === Recover button ===
            buttonRecover = new Button();
            buttonRecover.Text = "✔ Відновити";
            buttonRecover.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonRecover.BackColor = Color.FromArgb(0, 150, 90);
            buttonRecover.ForeColor = Color.White;
            buttonRecover.FlatStyle = FlatStyle.Flat;
            buttonRecover.FlatAppearance.BorderSize = 0;
            buttonRecover.Size = new Size(150, 45);
            buttonRecover.Location = new Point(CONTENT_MARGIN, 370);
            buttonRecover.Enabled = false;
            buttonRecover.Click += buttonRecover_Click;
            panelContainer.Controls.Add(buttonRecover);

            // === Cancel button ===
            buttonCancel = new Button();
            buttonCancel.Text = "Скасувати";
            buttonCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonCancel.BackColor = Color.FromArgb(200, 60, 60);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.Size = new Size(150, 45);
            buttonCancel.Location = new Point(CONTENT_MARGIN + 170, 370);
            buttonCancel.Click += buttonCancel_Click;
            panelContainer.Controls.Add(buttonCancel);

            this.ResumeLayout(false);
        }

        // === Gradient background like LoginForm ===
        private void PanelContainer_Paint(object sender, PaintEventArgs e)
        {
            var gradient = new LinearGradientBrush(
                panelContainer.ClientRectangle,
                Color.FromArgb(255, 255, 255),
                Color.FromArgb(240, 245, 255),
                LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(gradient, panelContainer.ClientRectangle);
        }
    }
}