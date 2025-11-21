using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;

namespace Forms
{
    partial class LoginForm
    {
        private Panel panelContainer;
        private Panel panelDecorTop;
        private Panel panelDecorBottom;
        private Panel panelHeader;
        private PictureBox pictureBoxIcon;
        private Label labelTitle;
        private Label labelSubtitle;
        private Panel panelEmail;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private PictureBox pictureBoxEmailIcon;
        private Panel panelPassword;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private PictureBox pictureBoxPasswordIcon;
        private Button buttonLogin;
        private Button buttonAdminLogin;
        private Panel panelDivider;
        private Label labelOr;
        private Button buttonRegister;
        private Button buttonGoogleLogin;
        private LinkLabel linkForgotPassword;
        private Panel panelFooter;
        private Label labelFooter;
        private System.Windows.Forms.Timer timerFocus;
        private System.Windows.Forms.Timer timerHover;
        private Panel panelLoading;
        private PictureBox pictureBoxLoading;
        private Label labelVersion;
        private Panel panelLanguage;
        private Button buttonLanguage;

        // Константи для вирівнювання
        private const int FORM_WIDTH = 450;
        private const int FORM_HEIGHT = 650;
        private const int CONTENT_WIDTH = 350;
        private const int CONTENT_MARGIN = 50;
        private const int ELEMENT_HEIGHT = 50;
        private const int SPACING = 15;

        private void InitializeComponent()
        {
            components = new Container();
            panelContainer = new Panel();
            panelDecorTop = new Panel();
            panelDecorBottom = new Panel();
            panelHeader = new Panel();
            pictureBoxIcon = new PictureBox();
            labelTitle = new Label();
            labelSubtitle = new Label();
            panelEmail = new Panel();
            pictureBoxEmailIcon = new PictureBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            panelPassword = new Panel();
            pictureBoxPasswordIcon = new PictureBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            buttonAdminLogin = new Button();
            panelDivider = new Panel();
            labelOr = new Label();
            buttonRegister = new Button();
            buttonGoogleLogin = new Button();
            linkForgotPassword = new LinkLabel();
            panelFooter = new Panel();
            labelFooter = new Label();
            timerFocus = new System.Windows.Forms.Timer(components);
            timerHover = new System.Windows.Forms.Timer(components);
            panelLoading = new Panel();
            pictureBoxLoading = new PictureBox();
            labelVersion = new Label();
            panelLanguage = new Panel();
            buttonLanguage = new Button();
            ((ISupportInitialize)pictureBoxIcon).BeginInit();
            ((ISupportInitialize)pictureBoxEmailIcon).BeginInit();
            ((ISupportInitialize)pictureBoxPasswordIcon).BeginInit();
            ((ISupportInitialize)pictureBoxLoading).BeginInit();
            SuspendLayout();
            // 
            // panelContainer
            // 
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(200, 100);
            panelContainer.TabIndex = 0;
            // 
            // panelDecorTop
            // 
            panelDecorTop.Location = new Point(0, 0);
            panelDecorTop.Name = "panelDecorTop";
            panelDecorTop.Size = new Size(200, 100);
            panelDecorTop.TabIndex = 0;
            // 
            // panelDecorBottom
            // 
            panelDecorBottom.Location = new Point(0, 0);
            panelDecorBottom.Name = "panelDecorBottom";
            panelDecorBottom.Size = new Size(200, 100);
            panelDecorBottom.TabIndex = 0;
            // 
            // panelHeader
            // 
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(200, 100);
            panelHeader.TabIndex = 0;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Location = new Point(0, 0);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(100, 50);
            pictureBoxIcon.TabIndex = 0;
            pictureBoxIcon.TabStop = false;
            // 
            // labelTitle
            // 
            labelTitle.Location = new Point(0, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(100, 23);
            labelTitle.TabIndex = 0;
            // 
            // labelSubtitle
            // 
            labelSubtitle.Location = new Point(0, 0);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(100, 23);
            labelSubtitle.TabIndex = 0;
            // 
            // panelEmail
            // 
            panelEmail.Location = new Point(0, 0);
            panelEmail.Name = "panelEmail";
            panelEmail.Size = new Size(200, 100);
            panelEmail.TabIndex = 0;
            // 
            // pictureBoxEmailIcon
            // 
            pictureBoxEmailIcon.Location = new Point(0, 0);
            pictureBoxEmailIcon.Name = "pictureBoxEmailIcon";
            pictureBoxEmailIcon.Size = new Size(100, 50);
            pictureBoxEmailIcon.TabIndex = 0;
            pictureBoxEmailIcon.TabStop = false;
            // 
            // labelEmail
            // 
            labelEmail.Location = new Point(0, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(100, 23);
            labelEmail.TabIndex = 0;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(0, 0);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(100, 27);
            textBoxEmail.TabIndex = 0;
            // 
            // panelPassword
            // 
            panelPassword.Location = new Point(0, 0);
            panelPassword.Name = "panelPassword";
            panelPassword.Size = new Size(200, 100);
            panelPassword.TabIndex = 0;
            // 
            // pictureBoxPasswordIcon
            // 
            pictureBoxPasswordIcon.Location = new Point(0, 0);
            pictureBoxPasswordIcon.Name = "pictureBoxPasswordIcon";
            pictureBoxPasswordIcon.Size = new Size(100, 50);
            pictureBoxPasswordIcon.TabIndex = 0;
            pictureBoxPasswordIcon.TabStop = false;
            // 
            // labelPassword
            // 
            labelPassword.Location = new Point(0, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(100, 23);
            labelPassword.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(0, 0);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(100, 27);
            textBoxPassword.TabIndex = 0;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(0, 0);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(75, 23);
            buttonLogin.TabIndex = 0;
            // 
            // buttonAdminLogin
            // 
            buttonAdminLogin.Location = new Point(0, 0);
            buttonAdminLogin.Name = "buttonAdminLogin";
            buttonAdminLogin.Size = new Size(75, 23);
            buttonAdminLogin.TabIndex = 0;
            // 
            // panelDivider
            // 
            panelDivider.Location = new Point(0, 0);
            panelDivider.Name = "panelDivider";
            panelDivider.Size = new Size(200, 100);
            panelDivider.TabIndex = 0;
            // 
            // labelOr
            // 
            labelOr.Location = new Point(0, 0);
            labelOr.Name = "labelOr";
            labelOr.Size = new Size(100, 23);
            labelOr.TabIndex = 0;
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(0, 0);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(75, 23);
            buttonRegister.TabIndex = 0;
            // 
            // buttonGoogleLogin
            // 
            buttonGoogleLogin.Location = new Point(0, 0);
            buttonGoogleLogin.Name = "buttonGoogleLogin";
            buttonGoogleLogin.Size = new Size(75, 23);
            buttonGoogleLogin.TabIndex = 0;
            // 
            // linkForgotPassword
            // 
            linkForgotPassword.Location = new Point(0, 0);
            linkForgotPassword.Name = "linkForgotPassword";
            linkForgotPassword.Size = new Size(100, 23);
            linkForgotPassword.TabIndex = 0;
            // 
            // panelFooter
            // 
            panelFooter.Location = new Point(0, 0);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(200, 100);
            panelFooter.TabIndex = 0;
            // 
            // labelFooter
            // 
            labelFooter.Location = new Point(0, 0);
            labelFooter.Name = "labelFooter";
            labelFooter.Size = new Size(100, 23);
            labelFooter.TabIndex = 0;
            // 
            // panelLoading
            // 
            panelLoading.Location = new Point(0, 0);
            panelLoading.Name = "panelLoading";
            panelLoading.Size = new Size(200, 100);
            panelLoading.TabIndex = 0;
            // 
            // pictureBoxLoading
            // 
            pictureBoxLoading.Location = new Point(0, 0);
            pictureBoxLoading.Name = "pictureBoxLoading";
            pictureBoxLoading.Size = new Size(100, 50);
            pictureBoxLoading.TabIndex = 0;
            pictureBoxLoading.TabStop = false;
            // 
            // labelVersion
            // 
            labelVersion.Location = new Point(0, 0);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(100, 23);
            labelVersion.TabIndex = 0;
            // 
            // panelLanguage
            // 
            panelLanguage.Location = new Point(0, 0);
            panelLanguage.Name = "panelLanguage";
            panelLanguage.Size = new Size(200, 100);
            panelLanguage.TabIndex = 0;
            // 
            // buttonLanguage
            // 
            buttonLanguage.Location = new Point(0, 0);
            buttonLanguage.Name = "buttonLanguage";
            buttonLanguage.Size = new Size(75, 23);
            buttonLanguage.TabIndex = 0;
            // 
            // LoginForm
            // 
            ClientSize = new Size(282, 253);
            Name = "LoginForm";
            ((ISupportInitialize)pictureBoxIcon).EndInit();
            ((ISupportInitialize)pictureBoxEmailIcon).EndInit();
            ((ISupportInitialize)pictureBoxPasswordIcon).EndInit();
            ((ISupportInitialize)pictureBoxLoading).EndInit();
            ResumeLayout(false);
        }

        private void InitializeComponents()
        {
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(FORM_WIDTH, FORM_HEIGHT);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизація";
            Padding = new Padding(1);
            DoubleBuffered = true;

            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.FromArgb(250, 250, 252);
            panelContainer.BorderStyle = BorderStyle.None;
            panelContainer.Controls.Add(panelLanguage);
            panelContainer.Controls.Add(panelLoading);
            panelContainer.Controls.Add(panelDecorTop);
            panelContainer.Controls.Add(panelDecorBottom);
            panelContainer.Controls.Add(panelHeader);
            panelContainer.Controls.Add(panelEmail);
            panelContainer.Controls.Add(panelPassword);
            panelContainer.Controls.Add(buttonLogin);
            panelContainer.Controls.Add(buttonAdminLogin);
            panelContainer.Controls.Add(panelDivider);
            panelContainer.Controls.Add(labelOr);
            panelContainer.Controls.Add(buttonRegister);
            panelContainer.Controls.Add(buttonGoogleLogin);
            panelContainer.Controls.Add(linkForgotPassword);
            panelContainer.Controls.Add(panelFooter);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(1, 1);
            panelContainer.Margin = new Padding(0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(FORM_WIDTH - 2, FORM_HEIGHT - 2);
            panelContainer.TabIndex = 0;
            panelContainer.Paint += PanelContainer_Paint;

            // 
            // panelLanguage
            // 
            panelLanguage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelLanguage.BackColor = Color.Transparent;
            panelLanguage.Controls.Add(buttonLanguage);
            panelLanguage.Location = new Point(FORM_WIDTH - 90, 10);
            panelLanguage.Name = "panelLanguage";
            panelLanguage.Size = new Size(70, 30);
            panelLanguage.TabIndex = 18;
            panelLanguage.Paint += PanelLanguage_Paint;

            // 
            // buttonLanguage
            // 
            buttonLanguage.BackColor = Color.Transparent;
            buttonLanguage.Dock = DockStyle.Fill;
            buttonLanguage.FlatAppearance.BorderSize = 0;
            buttonLanguage.FlatAppearance.MouseDownBackColor = Color.FromArgb(240, 245, 255);
            buttonLanguage.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 240, 255);
            buttonLanguage.FlatStyle = FlatStyle.Flat;
            buttonLanguage.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLanguage.ForeColor = Color.FromArgb(80, 80, 80);
            buttonLanguage.Image = CreateLanguageIcon();
            buttonLanguage.ImageAlign = ContentAlignment.MiddleLeft;
            buttonLanguage.Location = new Point(0, 0);
            buttonLanguage.Margin = new Padding(0);
            buttonLanguage.Name = "buttonLanguage";
            buttonLanguage.Size = new Size(70, 30);
            buttonLanguage.TabIndex = 0;
            buttonLanguage.Text = "UA";
            buttonLanguage.TextAlign = ContentAlignment.MiddleRight;
            buttonLanguage.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonLanguage.UseVisualStyleBackColor = false;
            buttonLanguage.Click += buttonLanguage_Click;

            // 
            // panelLoading
            // 
            panelLoading.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLoading.BackColor = Color.FromArgb(200, 250, 250, 252);
            panelLoading.Controls.Add(pictureBoxLoading);
            panelLoading.Controls.Add(labelVersion);
            panelLoading.Location = new Point(0, 0);
            panelLoading.Name = "panelLoading";
            panelLoading.Size = new Size(FORM_WIDTH - 2, FORM_HEIGHT - 2);
            panelLoading.TabIndex = 17;
            panelLoading.Visible = false;
            panelLoading.Paint += PanelLoading_Paint;

            // 
            // pictureBoxLoading
            // 
            pictureBoxLoading.Anchor = AnchorStyles.None;
            pictureBoxLoading.Image = CreateLoadingSpinner();
            pictureBoxLoading.Location = new Point((FORM_WIDTH - 40) / 2, (FORM_HEIGHT - 40) / 2);
            pictureBoxLoading.Name = "pictureBoxLoading";
            pictureBoxLoading.Size = new Size(40, 40);
            pictureBoxLoading.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLoading.TabIndex = 1;
            pictureBoxLoading.TabStop = false;

            // 
            // labelVersion
            // 
            labelVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelVersion.AutoSize = true;
            labelVersion.BackColor = Color.Transparent;
            labelVersion.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labelVersion.ForeColor = Color.FromArgb(120, 120, 120);
            labelVersion.Location = new Point(10, FORM_HEIGHT - 30);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(85, 15);
            labelVersion.TabIndex = 0;
            labelVersion.Text = "Версія 1.0.0.0";

            // 
            // panelDecorTop
            // 
            panelDecorTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelDecorTop.BackColor = Color.Transparent;
            panelDecorTop.Location = new Point(0, 0);
            panelDecorTop.Name = "panelDecorTop";
            panelDecorTop.Size = new Size(FORM_WIDTH - 2, 8);
            panelDecorTop.TabIndex = 15;
            panelDecorTop.Paint += PanelDecorTop_Paint;

            // 
            // panelDecorBottom
            // 
            panelDecorBottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDecorBottom.BackColor = Color.Transparent;
            panelDecorBottom.Location = new Point(0, FORM_HEIGHT - 10);
            panelDecorBottom.Name = "panelDecorBottom";
            panelDecorBottom.Size = new Size(FORM_WIDTH - 2, 8);
            panelDecorBottom.TabIndex = 16;
            panelDecorBottom.Paint += PanelDecorBottom_Paint;

            // 
            // panelHeader
            // 
            panelHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(pictureBoxIcon);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(labelSubtitle);
            panelHeader.Location = new Point(0, 40);
            panelHeader.Margin = new Padding(0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(FORM_WIDTH - 2, 120);
            panelHeader.TabIndex = 0;

            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Anchor = AnchorStyles.Top;
            pictureBoxIcon.Image = CreatePremiumIcon();
            pictureBoxIcon.Location = new Point((FORM_WIDTH - 60) / 2, 0);
            pictureBoxIcon.Margin = new Padding(0);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(60, 60);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIcon.TabIndex = 0;
            pictureBoxIcon.TabStop = false;

            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.ForeColor = Color.FromArgb(0, 51, 102);
            labelTitle.Location = new Point(CONTENT_MARGIN, 60);
            labelTitle.Margin = new Padding(0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(CONTENT_WIDTH, 40);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Ласкаво просимо";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // labelSubtitle
            // 
            labelSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            labelSubtitle.Location = new Point(CONTENT_MARGIN, 100);
            labelSubtitle.Margin = new Padding(0);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(CONTENT_WIDTH, 25);
            labelSubtitle.TabIndex = 2;
            labelSubtitle.Text = "Увійдіть у свій обліковий запис";
            labelSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // panelEmail
            // 
            panelEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelEmail.BackColor = Color.White;
            panelEmail.BorderStyle = BorderStyle.FixedSingle;
            panelEmail.Controls.Add(pictureBoxEmailIcon);
            panelEmail.Controls.Add(labelEmail);
            panelEmail.Controls.Add(textBoxEmail);
            panelEmail.Location = new Point(CONTENT_MARGIN, 180);
            panelEmail.Margin = new Padding(0);
            panelEmail.Name = "panelEmail";
            panelEmail.Size = new Size(CONTENT_WIDTH, ELEMENT_HEIGHT);
            panelEmail.TabIndex = 1;
            panelEmail.Paint += PanelInput_Paint;

            // 
            // pictureBoxEmailIcon
            // 
            pictureBoxEmailIcon.Anchor = AnchorStyles.Left;
            pictureBoxEmailIcon.Image = CreateEmailIcon();
            pictureBoxEmailIcon.Location = new Point(15, 25);
            pictureBoxEmailIcon.Margin = new Padding(0);
            pictureBoxEmailIcon.Name = "pictureBoxEmailIcon";
            pictureBoxEmailIcon.Size = new Size(18, 18);
            pictureBoxEmailIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxEmailIcon.TabIndex = 3;
            pictureBoxEmailIcon.TabStop = false;

            // 
            // labelEmail
            // 
            labelEmail.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmail.ForeColor = Color.FromArgb(80, 80, 80);
            labelEmail.Location = new Point(40, 8);
            labelEmail.Margin = new Padding(0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(36, 19);
            labelEmail.TabIndex = 2;
            labelEmail.Text = "Email";
            labelEmail.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // textBoxEmail
            // 
            textBoxEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxEmail.BackColor = Color.White;
            textBoxEmail.BorderStyle = BorderStyle.None;
            textBoxEmail.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmail.ForeColor = Color.FromArgb(32, 32, 32);
            textBoxEmail.Location = new Point(40, 25);
            textBoxEmail.Margin = new Padding(0);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(295, 23);
            textBoxEmail.TabIndex = 1;
            textBoxEmail.Enter += TextBox_Enter;
            textBoxEmail.Leave += TextBox_Leave;
            textBoxEmail.TextChanged += TextBox_TextChanged;
            textBoxEmail.KeyDown += TextBox_KeyDown;

            // 
            // panelPassword
            // 
            panelPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelPassword.BackColor = Color.White;
            panelPassword.BorderStyle = BorderStyle.FixedSingle;
            panelPassword.Controls.Add(pictureBoxPasswordIcon);
            panelPassword.Controls.Add(labelPassword);
            panelPassword.Controls.Add(textBoxPassword);
            panelPassword.Location = new Point(CONTENT_MARGIN, 180 + ELEMENT_HEIGHT + SPACING);
            panelPassword.Margin = new Padding(0);
            panelPassword.Name = "panelPassword";
            panelPassword.Size = new Size(CONTENT_WIDTH, ELEMENT_HEIGHT);
            panelPassword.TabIndex = 2;
            panelPassword.Paint += PanelInput_Paint;

            // 
            // pictureBoxPasswordIcon
            // 
            pictureBoxPasswordIcon.Anchor = AnchorStyles.Left;
            pictureBoxPasswordIcon.Image = CreatePasswordIcon();
            pictureBoxPasswordIcon.Location = new Point(15, 25);
            pictureBoxPasswordIcon.Margin = new Padding(0);
            pictureBoxPasswordIcon.Name = "pictureBoxPasswordIcon";
            pictureBoxPasswordIcon.Size = new Size(18, 18);
            pictureBoxPasswordIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPasswordIcon.TabIndex = 3;
            pictureBoxPasswordIcon.TabStop = false;

            // 
            // labelPassword
            // 
            labelPassword.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            labelPassword.ForeColor = Color.FromArgb(80, 80, 80);
            labelPassword.Location = new Point(40, 8);
            labelPassword.Margin = new Padding(0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(56, 19);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Пароль";
            labelPassword.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxPassword.BackColor = Color.White;
            textBoxPassword.BorderStyle = BorderStyle.None;
            textBoxPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPassword.ForeColor = Color.FromArgb(32, 32, 32);
            textBoxPassword.Location = new Point(40, 25);
            textBoxPassword.Margin = new Padding(0);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '●';
            textBoxPassword.Size = new Size(295, 23);
            textBoxPassword.TabIndex = 2;
            textBoxPassword.Enter += TextBox_Enter;
            textBoxPassword.Leave += TextBox_Leave;
            textBoxPassword.TextChanged += TextBox_TextChanged;
            textBoxPassword.KeyDown += TextBox_KeyDown;

            // 
            // buttonLogin
            // 
            buttonLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonLogin.BackColor = Color.FromArgb(0, 120, 215);
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 90, 180);
            buttonLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 140, 240);
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(CONTENT_MARGIN, 180 + (ELEMENT_HEIGHT + SPACING) * 2);
            buttonLogin.Margin = new Padding(0);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(CONTENT_WIDTH, ELEMENT_HEIGHT);
            buttonLogin.TabIndex = 3;
            buttonLogin.Text = "Продовжити";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            buttonLogin.MouseEnter += Button_MouseEnter;
            buttonLogin.MouseLeave += Button_MouseLeave;
            buttonLogin.Paint += ButtonLogin_Paint;

            // 
            // buttonAdminLogin
            // 
            buttonAdminLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonAdminLogin.BackColor = Color.FromArgb(107, 70, 166);
            buttonAdminLogin.FlatAppearance.BorderSize = 0;
            buttonAdminLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(85, 55, 135);
            buttonAdminLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(125, 85, 195);
            buttonAdminLogin.FlatStyle = FlatStyle.Flat;
            buttonAdminLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAdminLogin.ForeColor = Color.White;
            buttonAdminLogin.Location = new Point(CONTENT_MARGIN, 180 + (ELEMENT_HEIGHT + SPACING) * 3);
            buttonAdminLogin.Margin = new Padding(0);
            buttonAdminLogin.Name = "buttonAdminLogin";
            buttonAdminLogin.Size = new Size(CONTENT_WIDTH, ELEMENT_HEIGHT - 8);
            buttonAdminLogin.TabIndex = 4;
            buttonAdminLogin.Text = "👨‍💼 Адміністративний доступ";
            buttonAdminLogin.UseVisualStyleBackColor = false;
            buttonAdminLogin.Click += buttonAdminLogin_Click;
            buttonAdminLogin.MouseEnter += Button_MouseEnter;
            buttonAdminLogin.MouseLeave += Button_MouseLeave;

            // 
            // panelDivider
            // 
            panelDivider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelDivider.BackColor = Color.FromArgb(230, 230, 230);
            panelDivider.Location = new Point(CONTENT_MARGIN, 180 + (ELEMENT_HEIGHT + SPACING) * 4 + 10);
            panelDivider.Margin = new Padding(0);
            panelDivider.Name = "panelDivider";
            panelDivider.Size = new Size(CONTENT_WIDTH, 1);
            panelDivider.TabIndex = 5;

            // 
            // labelOr
            // 
            labelOr.Anchor = AnchorStyles.Top;
            labelOr.BackColor = Color.FromArgb(250, 250, 252);
            labelOr.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelOr.ForeColor = Color.FromArgb(120, 120, 120);
            labelOr.Location = new Point((FORM_WIDTH - 40) / 2, 180 + (ELEMENT_HEIGHT + SPACING) * 4 + 5);
            labelOr.Margin = new Padding(0);
            labelOr.Name = "labelOr";
            labelOr.Size = new Size(40, 20);
            labelOr.TabIndex = 6;
            labelOr.Text = "або";
            labelOr.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // buttonRegister
            // 
            buttonRegister.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonRegister.BackColor = Color.White;
            buttonRegister.FlatAppearance.BorderColor = Color.FromArgb(0, 120, 215);
            buttonRegister.FlatAppearance.BorderSize = 2;
            buttonRegister.FlatAppearance.MouseDownBackColor = Color.FromArgb(245, 248, 255);
            buttonRegister.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 248, 255);
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRegister.ForeColor = Color.FromArgb(0, 120, 215);
            buttonRegister.Location = new Point(CONTENT_MARGIN, 180 + (ELEMENT_HEIGHT + SPACING) * 4 + 20);
            buttonRegister.Margin = new Padding(0);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(CONTENT_WIDTH, ELEMENT_HEIGHT - 8);
            buttonRegister.TabIndex = 7;
            buttonRegister.Text = "Створити новий акаунт";
            buttonRegister.UseVisualStyleBackColor = false;
            buttonRegister.Click += buttonRegister_Click;
            buttonRegister.MouseEnter += Button_MouseEnter;
            buttonRegister.MouseLeave += Button_MouseLeave;

            // 
            // buttonGoogleLogin
            // 
            buttonGoogleLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonGoogleLogin.BackColor = Color.White;
            buttonGoogleLogin.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220);
            buttonGoogleLogin.FlatAppearance.BorderSize = 1;
            buttonGoogleLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(248, 248, 248);
            buttonGoogleLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 248, 248);
            buttonGoogleLogin.FlatStyle = FlatStyle.Flat;
            buttonGoogleLogin.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonGoogleLogin.ForeColor = Color.FromArgb(68, 68, 68);
            buttonGoogleLogin.Image = CreateGoogleIcon();
            buttonGoogleLogin.ImageAlign = ContentAlignment.MiddleLeft;
            buttonGoogleLogin.Location = new Point(CONTENT_MARGIN, 180 + (ELEMENT_HEIGHT + SPACING) * 5 + 12);
            buttonGoogleLogin.Margin = new Padding(0);
            buttonGoogleLogin.Name = "buttonGoogleLogin";
            buttonGoogleLogin.Padding = new Padding(5, 0, 0, 0);
            buttonGoogleLogin.Size = new Size(CONTENT_WIDTH, ELEMENT_HEIGHT - 8);
            buttonGoogleLogin.TabIndex = 8;
            buttonGoogleLogin.Text = "Продовжити з Google";
            buttonGoogleLogin.TextAlign = ContentAlignment.MiddleRight;
            buttonGoogleLogin.UseVisualStyleBackColor = false;
            buttonGoogleLogin.Click += buttonGoogleLogin_Click;
            buttonGoogleLogin.MouseEnter += Button_MouseEnter;
            buttonGoogleLogin.MouseLeave += Button_MouseLeave;

            // 
            // linkForgotPassword
            // 
            linkForgotPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            linkForgotPassword.ActiveLinkColor = Color.FromArgb(0, 100, 200);
            linkForgotPassword.DisabledLinkColor = Color.FromArgb(150, 150, 150);
            linkForgotPassword.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            linkForgotPassword.LinkBehavior = LinkBehavior.HoverUnderline;
            linkForgotPassword.LinkColor = Color.FromArgb(0, 120, 215);
            linkForgotPassword.Location = new Point(CONTENT_MARGIN + 150, 180 + (ELEMENT_HEIGHT + SPACING) * 2 - 25);
            linkForgotPassword.Margin = new Padding(0);
            linkForgotPassword.Name = "linkForgotPassword";
            linkForgotPassword.Size = new Size(200, 20);
            linkForgotPassword.TabIndex = 9;
            linkForgotPassword.TabStop = true;
            linkForgotPassword.Text = "Забули пароль?";
            linkForgotPassword.TextAlign = ContentAlignment.MiddleRight;
            linkForgotPassword.VisitedLinkColor = Color.FromArgb(0, 120, 215);
            linkForgotPassword.LinkClicked += LinkForgotPassword_LinkClicked;

            // 
            // panelFooter
            // 
            panelFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFooter.BackColor = Color.Transparent;
            panelFooter.Controls.Add(labelFooter);
            panelFooter.Location = new Point(0, FORM_HEIGHT - 40);
            panelFooter.Margin = new Padding(0);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(FORM_WIDTH - 2, 30);
            panelFooter.TabIndex = 10;

            // 
            // labelFooter
            // 
            labelFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelFooter.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            labelFooter.ForeColor = Color.FromArgb(120, 120, 120);
            labelFooter.Location = new Point(0, 5);
            labelFooter.Margin = new Padding(0);
            labelFooter.Name = "labelFooter";
            labelFooter.Size = new Size(FORM_WIDTH - 2, 18);
            labelFooter.TabIndex = 0;
            labelFooter.Text = "© 2024 Ваша компанія. Усі права захищено.";
            labelFooter.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // timerFocus
            // 
            timerFocus.Interval = 15;
            timerFocus.Tick += TimerFocus_Tick;

            // 
            // timerHover
            // 
            timerHover.Interval = 15;
            timerHover.Tick += TimerHover_Tick;

            Controls.Add(panelContainer);
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmailIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoading).EndInit();
            ResumeLayout(false);
        }

        // Решта методів залишаються незмінними (CreatePremiumIcon, CreateEmailIcon, CreatePasswordIcon, тощо)
        // ...

        private Bitmap CreatePremiumIcon()
        {
            var bmp = new Bitmap(60, 60);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                var gradientBrush = new LinearGradientBrush(
                    new Rectangle(0, 0, 60, 60),
                    Color.FromArgb(0, 120, 215),
                    Color.FromArgb(0, 80, 175),
                    LinearGradientMode.ForwardDiagonal);

                g.FillEllipse(gradientBrush, 0, 0, 60, 60);

                using (var shadowBrush = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
                {
                    g.FillEllipse(shadowBrush, 2, 4, 56, 56);
                }

                var innerBrush = new LinearGradientBrush(
                    new Rectangle(10, 10, 40, 40),
                    Color.White,
                    Color.FromArgb(230, 240, 255),
                    LinearGradientMode.Vertical);

                g.FillEllipse(innerBrush, 10, 10, 40, 40);

                using (var font = new Font("Segoe UI Emoji", 16, FontStyle.Bold))
                using (var textBrush = new SolidBrush(Color.FromArgb(0, 120, 215)))
                {
                    g.DrawString("🔐", font, textBrush, 14, 14);
                }

                var shineBrush = new LinearGradientBrush(
                    new Rectangle(0, 0, 60, 30),
                    Color.FromArgb(80, 255, 255, 255),
                    Color.FromArgb(0, 255, 255, 255),
                    LinearGradientMode.Vertical);

                g.FillEllipse(shineBrush, 5, 5, 50, 25);

                using (var borderPen = new Pen(Color.FromArgb(200, 255, 255, 255), 2))
                {
                    g.DrawEllipse(borderPen, 1, 1, 58, 58);
                }
            }
            return bmp;
        }

        private Bitmap CreateEmailIcon()
        {
            var bmp = new Bitmap(18, 18);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (var brush = new SolidBrush(Color.FromArgb(120, 120, 120)))
                using (var borderPen = new Pen(Color.FromArgb(80, 80, 80), 1))
                {
                    g.FillRectangle(brush, 2, 4, 14, 10);
                    g.DrawRectangle(borderPen, 2, 4, 14, 10);

                    Point[] lidPoints = { new Point(2, 4), new Point(9, 9), new Point(16, 4) };
                    g.FillPolygon(brush, lidPoints);
                    g.DrawPolygon(borderPen, lidPoints);
                }
            }
            return bmp;
        }

        private Bitmap CreatePasswordIcon()
        {
            var bmp = new Bitmap(18, 18);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (var brush = new SolidBrush(Color.FromArgb(120, 120, 120)))
                using (var borderPen = new Pen(Color.FromArgb(80, 80, 80), 1))
                {
                    g.FillRectangle(brush, 4, 7, 10, 7);
                    g.DrawRectangle(borderPen, 4, 7, 10, 7);

                    g.FillRectangle(brush, 6, 4, 6, 3);
                    g.DrawRectangle(borderPen, 6, 4, 6, 3);

                    g.FillEllipse(Brushes.White, 7, 11, 4, 4);
                    g.DrawEllipse(borderPen, 7, 11, 4, 4);
                }
            }
            return bmp;
        }

        private Bitmap CreateGoogleIcon()
        {
            var bmp = new Bitmap(18, 18);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (var brush = new LinearGradientBrush(
                    new Rectangle(0, 0, 18, 18),
                    Color.FromArgb(66, 133, 244),
                    Color.FromArgb(52, 120, 230),
                    LinearGradientMode.ForwardDiagonal))
                {
                    g.FillEllipse(brush, 0, 0, 18, 18);
                }

                using (var font = new Font("Arial", 9, FontStyle.Bold))
                using (var brush = new SolidBrush(Color.White))
                {
                    g.DrawString("G", font, brush, 5, 3);
                }

                using (var shineBrush = new LinearGradientBrush(
                    new Rectangle(0, 0, 18, 9),
                    Color.FromArgb(60, 255, 255, 255),
                    Color.Transparent,
                    LinearGradientMode.Vertical))
                {
                    g.FillEllipse(shineBrush, 2, 2, 14, 7);
                }
            }
            return bmp;
        }

        private Bitmap CreateLanguageIcon()
        {
            var bmp = new Bitmap(14, 14);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (var pen = new Pen(Color.FromArgb(100, 100, 100), 1.2f))
                {
                    g.DrawEllipse(pen, 2, 2, 10, 10);
                    g.DrawLine(pen, 7, 2, 7, 12);
                    g.DrawArc(pen, 2, 4, 10, 6, 0, 180);
                }
            }
            return bmp;
        }

        private Bitmap CreateLoadingSpinner()
        {
            var bmp = new Bitmap(40, 40);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (var pen = new Pen(Color.FromArgb(0, 120, 215), 3))
                {
                    pen.DashStyle = DashStyle.Dash;
                    g.DrawArc(pen, 5, 5, 30, 30, 0, 270);
                }
            }
            return bmp;
        }

        // Покращені анімації та ефекти
        private void TextBox_Enter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                var panel = textBox.Parent as Panel;
                if (panel != null)
                {
                    panel.BackColor = Color.FromArgb(245, 248, 255);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                }
                textBox.BackColor = Color.FromArgb(245, 248, 255);

                // Анімація підсвічування
                timerFocus.Start();
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                var panel = textBox.Parent as Panel;
                if (panel != null)
                {
                    panel.BackColor = Color.White;
                }
                textBox.BackColor = Color.White;
                timerFocus.Stop();
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && !string.IsNullOrEmpty(textBox.Text))
            {
                // Плавна зміна кольору плейсхолдера
                var label = textBox.Parent.Controls.OfType<Label>().FirstOrDefault();
                if (label != null)
                {
                    label.ForeColor = Color.FromArgb(0, 120, 215);
                }
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                buttonLogin.PerformClick();
            }
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                button.Cursor = Cursors.Hand;
                timerHover.Start();
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                button.Cursor = Cursors.Default;
                timerHover.Stop();
            }
        }

        private void ButtonLogin_Paint(object sender, PaintEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Enabled)
            {
                // Додатковий градієнт для основної кнопки
                var gradientBrush = new LinearGradientBrush(
                    button.ClientRectangle,
                    Color.FromArgb(0, 120, 215),
                    Color.FromArgb(0, 100, 200),
                    LinearGradientMode.Vertical);

                e.Graphics.FillRectangle(gradientBrush, button.ClientRectangle);

                // Текст з тінню
                using (var textBrush = new SolidBrush(button.ForeColor))
                using (var shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                using (var format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                })
                {
                    var shadowRect = new Rectangle(button.ClientRectangle.X, button.ClientRectangle.Y + 1, button.ClientRectangle.Width, button.ClientRectangle.Height);
                    e.Graphics.DrawString(button.Text, button.Font, shadowBrush, shadowRect, format);
                    e.Graphics.DrawString(button.Text, button.Font, textBrush, button.ClientRectangle, format);
                }
            }
        }

        private void PanelContainer_Paint(object sender, PaintEventArgs e)
        {
            // Градієнтний фон з ефектом глибини
            var gradientBrush = new LinearGradientBrush(
                panelContainer.ClientRectangle,
                Color.FromArgb(250, 250, 252),
                Color.FromArgb(240, 245, 255),
                LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(gradientBrush, panelContainer.ClientRectangle);

            // Тінь по краях
            using (var borderPen = new Pen(Color.FromArgb(200, 220, 230), 1))
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, panelContainer.Width - 1, panelContainer.Height - 1);
            }
        }

        private void PanelDecorTop_Paint(object sender, PaintEventArgs e)
        {
            // Декоративна верхня лінія з градієнтом
            var gradientBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(panelDecorTop.Width, 0),
                Color.FromArgb(0, 120, 215),
                Color.FromArgb(100, 180, 255));

            using (var pen = new Pen(gradientBrush, 3))
            {
                e.Graphics.DrawLine(pen, 100, 6, 400, 6);
            }

            // Додаткові декоративні елементи
            using (var dotBrush = new SolidBrush(Color.FromArgb(200, 230, 255)))
            {
                for (int i = 0; i < 5; i++)
                {
                    e.Graphics.FillEllipse(dotBrush, 50 + i * 20, 4, 3, 3);
                    e.Graphics.FillEllipse(dotBrush, 350 + i * 20, 4, 3, 3);
                }
            }
        }

        private void PanelDecorBottom_Paint(object sender, PaintEventArgs e)
        {
            // Декоративна нижня лінія
            using (var pen = new Pen(Color.FromArgb(220, 230, 240), 2))
            {
                e.Graphics.DrawLine(pen, 50, 6, 450, 6);
            }

            // Декоративні крапки
            using (var dotBrush = new SolidBrush(Color.FromArgb(180, 200, 220)))
            {
                for (int i = 0; i < 8; i++)
                {
                    e.Graphics.FillEllipse(dotBrush, 30 + i * 15, 4, 2, 2);
                }
            }
        }

        private void PanelInput_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            if (panel != null)
            {
                // Тонка обводка для полів вводу
                using (var borderPen = new Pen(Color.FromArgb(220, 220, 220), 1))
                {
                    e.Graphics.DrawRectangle(borderPen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            }
        }

        private void PanelLanguage_Paint(object sender, PaintEventArgs e)
        {
            // Стиль для панелі мови
            using (var borderPen = new Pen(Color.FromArgb(220, 220, 220), 1))
            using (var fillBrush = new SolidBrush(Color.FromArgb(250, 250, 250)))
            {
                e.Graphics.FillRectangle(fillBrush, 0, 0, panelLanguage.Width, panelLanguage.Height);
                e.Graphics.DrawRectangle(borderPen, 0, 0, panelLanguage.Width - 1, panelLanguage.Height - 1);
            }
        }

        private void PanelLoading_Paint(object sender, PaintEventArgs e)
        {
            // Напівпрозорий фон для завантаження
            using (var brush = new SolidBrush(Color.FromArgb(200, 250, 250, 252)))
            {
                e.Graphics.FillRectangle(brush, panelLoading.ClientRectangle);
            }
        }

        private void TimerFocus_Tick(object sender, EventArgs e)
        {
            // Анімація фокусу для полів вводу
            foreach (Control control in panelContainer.Controls)
            {
                if (control is Panel panel && (panel.Name == "panelEmail" || panel.Name == "panelPassword"))
                {
                    if (panel.BackColor != Color.White)
                    {
                        var currentColor = panel.BackColor;
                        var newColor = Color.FromArgb(
                            Math.Min(255, currentColor.R + 1),
                            Math.Min(255, currentColor.G + 1),
                            Math.Min(255, currentColor.B + 1));

                        panel.BackColor = newColor;
                        foreach (Control child in panel.Controls)
                        {
                            if (child is TextBox)
                                child.BackColor = newColor;
                        }
                    }
                }
            }
        }

        private void TimerHover_Tick(object sender, EventArgs e)
        {
            // Анімація ховер-ефектів для кнопок
            // Можна додати плавні зміни кольорів
        }

        private void buttonLanguage_Click(object sender, EventArgs e)
        {
            // Перемикання мови
            ShowLanguageMenu();
        }

        private void ShowLanguageMenu()
        {
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Українська", null, (s, e) => SetLanguage("UA"));
            contextMenu.Items.Add("English", null, (s, e) => SetLanguage("EN"));
            contextMenu.Items.Add("Deutsch", null, (s, e) => SetLanguage("DE"));

            contextMenu.Show(buttonLanguage, new Point(0, buttonLanguage.Height));
        }

        private void SetLanguage(string language)
        {
            buttonLanguage.Text = language;
            // Тут можна додати логіку зміни мови інтерфейсу
        }

        private void LinkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLoadingAnimation();
            // Імітація завантаження
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000;
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                HideLoadingAnimation();
                OpenForgotPasswordForm();
            };
            timer.Start();
        }

        private void ShowLoadingAnimation()
        {
            panelLoading.BringToFront();
            panelLoading.Visible = true;

            // Анімація обертання
            var rotateTimer = new System.Windows.Forms.Timer();
            rotateTimer.Interval = 50;
            float angle = 0;
            rotateTimer.Tick += (s, args) =>
            {
                angle += 10;
                if (angle >= 360) angle = 0;

                var oldImage = pictureBoxLoading.Image;
                pictureBoxLoading.Image = RotateImage(CreateLoadingSpinner(), angle);
                oldImage?.Dispose();
            };
            rotateTimer.Start();
        }

        private void HideLoadingAnimation()
        {
            panelLoading.Visible = false;
        }

        private Bitmap RotateImage(Bitmap bmp, float angle)
        {
            var rotated = new Bitmap(bmp.Width, bmp.Height);
            using (var g = Graphics.FromImage(rotated))
            {
                g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                g.DrawImage(bmp, new Point(0, 0));
            }
            return rotated;
        }

        private void OpenForgotPasswordForm()
        {
            var forgotForm = new ForgotPasswordForm();
            forgotForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            AnimateFormLoad();
        }

        private void AnimateFormLoad()
        {
            // Плавне з'явлення форми
            Opacity = 0;
            var fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = 20;
            fadeTimer.Tick += (s, args) =>
            {
                if (Opacity < 1)
                {
                    Opacity += 0.05;
                }
                else
                {
                    fadeTimer.Stop();
                    fadeTimer.Dispose();
                }
            };
            fadeTimer.Start();

            // Анімація появи елементів
            AnimateControlsSequentially();
        }

        private void AnimateControlsSequentially()
        {
            // Послідовна анімація появи елементів
            var controls = new Control[]
            {
                panelHeader,
                panelEmail,
                panelPassword,
                buttonLogin,
                buttonAdminLogin,
                buttonRegister,
                buttonGoogleLogin
            };

            for (int i = 0; i < controls.Length; i++)
            {
                var control = controls[i];
                control.Tag = control.Location;
                control.Location = new Point(control.Location.X, control.Location.Y + 20);
                control.Visible = false;

                var timer = new System.Windows.Forms.Timer();
                timer.Interval = 100 + (i * 80);
                timer.Tag = control;
                timer.Tick += (s, args) =>
                {
                    var t = s as System.Windows.Forms.Timer;
                    var c = t.Tag as Control;
                    var originalLocation = (Point)c.Tag;

                    c.Visible = true;
                    if (c.Location.Y > originalLocation.Y)
                    {
                        c.Location = new Point(c.Location.X, c.Location.Y - 2);
                    }
                    else
                    {
                        c.Location = originalLocation;
                        t.Stop();
                        t.Dispose();
                    }
                };
                timer.Start();
            }
        }
        private IContainer components;
    }
}