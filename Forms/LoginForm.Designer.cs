using System;
using System.Drawing;
using System.Windows.Forms;

namespace Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelContainer;
        private TableLayoutPanel layoutMain;
        private Panel leftPanel;
        private Panel rightPanel;

        private PictureBox pictureLogo;
        private Label leftTitle;
        private Label leftSubtitle;
        private PictureBox leftArt;

        private Label labelTitle;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private CheckBox checkBoxRemember;
        private LinkLabel linkForgot;

        private Button buttonLogin;
        private Button buttonGoogleLogin;

        private FlowLayoutPanel bottomButtonsPanel;
        private Button buttonRegister;
        private Button buttonAdminLogin;

        private readonly Color Theme_Back = Color.FromArgb(18, 18, 20);
        private readonly Color Card_Back = Color.FromArgb(30, 30, 34);
        private readonly Color Panel_Left_Back = Color.FromArgb(38, 38, 42);
        private readonly Color Input_Back = Color.FromArgb(22, 22, 24);
        private readonly Color Input_Border = Color.FromArgb(55, 55, 58);
        private readonly Color Text_Primary = Color.FromArgb(235, 235, 240);
        private readonly Color Text_Secondary = Color.FromArgb(170, 170, 180);
        private readonly Color Accent = Color.FromArgb(66, 133, 244);

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Theme_Back;
            this.ClientSize = new Size(1100, 720);
            this.MinimumSize = new Size(900, 640);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Авторизація";
            this.Font = new Font("Segoe UI", 9F);
            this.ForeColor = Text_Primary;

            // CARD
            this.panelContainer = new Panel()
            {
                BackColor = Card_Back,
                Size = new Size(980, 560),
                Padding = new Padding(20),
                Anchor = AnchorStyles.None
            };
            this.panelContainer.Location = Center(panelContainer.Size);

            // MAIN LAYOUT
            this.layoutMain = new TableLayoutPanel()
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Padding = new Padding(8),
            };
            this.layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            this.layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));

            // LEFT
            this.leftPanel = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Panel_Left_Back,
                Padding = new Padding(24)
            };

            this.pictureLogo = new PictureBox()
            {
                Size = new Size(50, 50),
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(4, 4)
            };

            this.leftTitle = new Label()
            {
                Text = "Welcome Back",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Text_Primary,
                AutoSize = true,
                Location = new Point(4, 70)
            };

            this.leftSubtitle = new Label()
            {
                Text = "Escort · Agency · Company",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Text_Secondary,
                AutoSize = true,
                Location = new Point(4, 118)
            };

            this.leftArt = new PictureBox()
            {
                Size = new Size(300, 200),
                BackColor = Color.FromArgb(34, 40, 46),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(4, 170)
            };

            this.leftPanel.Controls.Add(pictureLogo);
            this.leftPanel.Controls.Add(leftTitle);
            this.leftPanel.Controls.Add(leftSubtitle);
            this.leftPanel.Controls.Add(leftArt);

            // RIGHT
            this.rightPanel = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = new Padding(6, 30, 6, 6)
            };

            // ELEMENTS
            labelTitle = new Label()
            {
                Text = "Авторизація",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Text_Primary,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 20)
            };

            labelEmail = new Label()
            {
                Text = "Email",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Text_Secondary,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 4)
            };

            textBoxEmail = new TextBox()
            {
                Font = new Font("Segoe UI", 11F),
                BackColor = Input_Back,
                ForeColor = Text_Primary,
                BorderStyle = BorderStyle.FixedSingle,
                Height = 42,
                Dock = DockStyle.Top
            };

            labelPassword = new Label()
            {
                Text = "Пароль",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Text_Secondary,
                AutoSize = true,
                Margin = new Padding(0, 14, 0, 4)
            };

            textBoxPassword = new TextBox()
            {
                Font = new Font("Segoe UI", 11F),
                BackColor = Input_Back,
                ForeColor = Text_Primary,
                BorderStyle = BorderStyle.FixedSingle,
                UseSystemPasswordChar = true,
                Height = 42,
                Dock = DockStyle.Top
            };

            var rememberRow = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                Margin = new Padding(0, 8, 0, 8)
            };

            checkBoxRemember = new CheckBox()
            {
                Text = "Запам'ятати мене",
                ForeColor = Text_Secondary,
                BackColor = Color.Transparent,
                AutoSize = true
            };

            linkForgot = new LinkLabel()
            {
                Text = "Забули пароль?",
                LinkColor = Accent,
                ActiveLinkColor = ControlPaint.Dark(Accent),
                AutoSize = true,
                Margin = new Padding(14, 3, 0, 0)
            };
            linkForgot.Click += this.buttonForgotPassword_Click;

            rememberRow.Controls.Add(checkBoxRemember);
            rememberRow.Controls.Add(linkForgot);

            buttonLogin = new Button()
            {
                Text = "Увійти",
                Height = 48,
                BackColor = Accent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Dock = DockStyle.Top,
                Margin = new Padding(0, 4, 0, 8)
            };
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.Click += this.buttonLogin_Click;

            buttonGoogleLogin = new Button()
            {
                Text = "Продовжити з Google",
                Height = 48,
                BackColor = Accent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, 12)
            };
            buttonGoogleLogin.FlatAppearance.BorderSize = 0;
            buttonGoogleLogin.Click += this.buttonGoogleLogin_Click;

            bottomButtonsPanel = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                Margin = new Padding(0, 12, 0, 0)
            };

            buttonRegister = new Button()
            {
                Text = "Реєстрація",
                Width = 210,
                Height = 40,
                BackColor = Color.FromArgb(42, 42, 46),
                ForeColor = Text_Primary,
                FlatStyle = FlatStyle.Flat
            };
            buttonRegister.FlatAppearance.BorderColor = Input_Border;
            buttonRegister.Click += this.buttonRegister_Click;

            buttonAdminLogin = new Button()
            {
                Text = "Вхід адміністратора",
                Width = 210,
                Height = 40,
                BackColor = Color.FromArgb(42, 42, 46),
                ForeColor = Text_Primary,
                FlatStyle = FlatStyle.Flat
            };
            buttonAdminLogin.FlatAppearance.BorderColor = Input_Border;
            buttonAdminLogin.Click += this.buttonAdminLogin_Click;

            bottomButtonsPanel.Controls.Add(buttonRegister);
            bottomButtonsPanel.Controls.Add(new Panel() { Width = 12 });
            bottomButtonsPanel.Controls.Add(buttonAdminLogin);

            // RIGHT LAYOUT FIXED
            var rightLayout = new FlowLayoutPanel()
            {
                Dock = DockStyle.Top,
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                WrapContents = false
            };

            rightLayout.Controls.Add(labelTitle);
            rightLayout.Controls.Add(labelEmail);
            rightLayout.Controls.Add(textBoxEmail);
            rightLayout.Controls.Add(labelPassword);
            rightLayout.Controls.Add(textBoxPassword);
            rightLayout.Controls.Add(rememberRow);
            rightLayout.Controls.Add(buttonLogin);
            rightLayout.Controls.Add(buttonGoogleLogin);
            rightLayout.Controls.Add(bottomButtonsPanel);

            rightPanel.Controls.Add(rightLayout);

            layoutMain.Controls.Add(leftPanel, 0, 0);
            layoutMain.Controls.Add(rightPanel, 1, 0);

            panelContainer.Controls.Add(layoutMain);
            this.Controls.Add(panelContainer);

            this.Resize += (s, e) =>
            {
                panelContainer.Location = Center(panelContainer.Size);
            };

            this.ResumeLayout(false);
        }

        private Point Center(Size s)
        {
            return new Point(
                (this.ClientSize.Width - s.Width) / 2,
                (this.ClientSize.Height - s.Height) / 2
            );
        }
    }
}
