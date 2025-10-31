using System.Windows.Forms;

namespace WinFormsApp2
{
    partial class LoginForm
    {
        private Label labelEmail;
        private Label labelPassword;
        private TextBox textBoxEmail;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Button buttonRegister;
        private Button buttonGoogleLogin;
        private Button buttonAdminLogin;
        private Button buttonForgotPassword; // 🔹 нова кнопка

        private void InitializeComponent()
        {
            labelEmail = new Label();
            labelPassword = new Label();
            textBoxEmail = new TextBox();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            buttonRegister = new Button();
            buttonGoogleLogin = new Button();
            buttonAdminLogin = new Button();
            buttonForgotPassword = new Button(); // 🔹 ініціалізація
            SuspendLayout();
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(40, 40);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(49, 20);
            labelEmail.TabIndex = 0;
            labelEmail.Text = "Email:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(40, 80);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(65, 20);
            labelPassword.TabIndex = 1;
            labelPassword.Text = "Пароль:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(120, 35);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(200, 27);
            textBoxEmail.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(120, 75);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '●';
            textBoxPassword.Size = new Size(200, 27);
            textBoxPassword.TabIndex = 3;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(40, 120);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(80, 30);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "Увійти";
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonAdminLogin
            // 
            buttonAdminLogin.Location = new Point(130, 120);
            buttonAdminLogin.Name = "buttonAdminLogin";
            buttonAdminLogin.Size = new Size(218, 30);
            buttonAdminLogin.TabIndex = 5;
            buttonAdminLogin.Text = "👨‍💼 Увійти як адміністратор";
            buttonAdminLogin.Click += buttonAdminLogin_Click;
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(40, 170);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(100, 30);
            buttonRegister.TabIndex = 6;
            buttonRegister.Text = "Реєстрація";
            buttonRegister.Click += buttonRegister_Click;
            // 
            // buttonGoogleLogin
            // 
            buttonGoogleLogin.Location = new Point(150, 170);
            buttonGoogleLogin.Name = "buttonGoogleLogin";
            buttonGoogleLogin.Size = new Size(170, 30);
            buttonGoogleLogin.TabIndex = 7;
            buttonGoogleLogin.Text = "🔑 Вхід через Google";
            buttonGoogleLogin.Click += buttonGoogleLogin_Click;
            // 
            // buttonForgotPassword
            // 
            buttonForgotPassword.Location = new Point(220, 210);
            buttonForgotPassword.Name = "buttonForgotPassword";
            buttonForgotPassword.Size = new Size(130, 25);
            buttonForgotPassword.TabIndex = 8;
            buttonForgotPassword.Text = "Забув пароль?";
            buttonForgotPassword.Click += buttonForgotPassword_Click;
            // 
            // LoginForm
            // 
            ClientSize = new Size(380, 250);
            Controls.Add(labelEmail);
            Controls.Add(labelPassword);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonLogin);
            Controls.Add(buttonAdminLogin);
            Controls.Add(buttonRegister);
            Controls.Add(buttonGoogleLogin);
            Controls.Add(buttonForgotPassword); // 🔹 додано на форму
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизація";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
