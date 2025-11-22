using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Util;
using Google.Apis.Util.Store;
using DatabaseLibrary;
using Forms;

namespace Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent(); 
            Database.Init();
        }

        // === Вхід через email/password ===
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Database.ValidateUser(email, password, out string role))
            {
                if (role == "admin")
                {
                    MessageBox.Show("👨‍💼 Вітаємо, адміністратор!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var adminForm = new AdminServiceForm();
                    adminForm.FormClosed += (s, args) => this.Close();
                    adminForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("✅ Вхід успішний!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var shopForm = new UseServiceTg();
                    shopForm.FormClosed += (s, args) => this.Close();
                    shopForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("❌ Невірний email або пароль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === Вхід як адміністратор ===
        private void buttonAdminLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введіть email і пароль адміністратора.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Database.ValidateUser(email, password, out string role))
            {
                if (role == "admin")
                {
                    MessageBox.Show("👨‍💼 Вхід адміністратора успішний!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var adminForm = new StartAdminPanelForm();
                    adminForm.FormClosed += (s, args) => this.Close();
                    adminForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("🚫 У вас немає прав адміністратора.", "Доступ заборонено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("❌ Невірні дані входу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === Перехід на форму реєстрації ===
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm(this);
            registerForm.Show();
            this.Hide();
        }

        // === Вхід через Google ===
        private async void buttonGoogleLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var clientSecrets = new ClientSecrets
                {
                    ClientId = "74696745247-v3m332f58sdmf1jgohcj0a7v186vh9ja.apps.googleusercontent.com",
                    ClientSecret = "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"
                };

                var scopes = new[] { "email", "profile", "openid" };

                var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = clientSecrets,
                    Scopes = scopes,
                    DataStore = new FileDataStore("GoogleOAuthWinFormsV2", true)
                });

                var codeReceiver = new LocalServerCodeReceiver();
                var authApp = new AuthorizationCodeInstalledApp(flow, codeReceiver);

                var credential = await authApp.AuthorizeAsync("user", CancellationToken.None);

                if (credential.Token.IsExpired(SystemClock.Default))
                    await credential.RefreshTokenAsync(CancellationToken.None);

                if (credential.Token == null || string.IsNullOrEmpty(credential.Token.IdToken))
                {
                    MessageBox.Show("Не вдалося отримати токен Google.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var payload = await GoogleJsonWebSignature.ValidateAsync(credential.Token.IdToken);
                string email = payload.Email;
                string name = payload.Name ?? email;

                if (!Database.UserExists(email))
                    Database.AddUser(name, email, "google_auth");

                MessageBox.Show($"👋 Ласкаво просимо, {name}!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var shopForm = new UseServiceTg();
                shopForm.FormClosed += (s, args) => this.Close();
                shopForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка Google авторизації: " + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === 🆕 Перехід на форму скидання пароля ===
        private void buttonForgotPassword_Click(object sender, EventArgs e)
        {
            var forgotForm = new ForgotPasswordForm();
            forgotForm.ShowDialog();
        }
    }
}
