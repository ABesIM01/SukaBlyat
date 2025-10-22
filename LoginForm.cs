using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;

namespace WinFormsApp2
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

            if (!Database.UserExists(email))
            {
                MessageBox.Show("Користувача з таким email не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Database.ValidateUser(email, password))
            {
                MessageBox.Show("✅ Вхід успішний!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var adminForm = new AdminForm();
                adminForm.FormClosed += (s, args) => this.Close();
                adminForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("❌ Невірний пароль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === Перехід на форму реєстрації ===
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm(this);
            registerForm.Show();
            this.Hide();
        }

        // === Google Login — офіційний потік Microsoft/Google ===
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

                // Використовує офіційний LocalServerCodeReceiver — все робить сам
                var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = clientSecrets,
                    Scopes = scopes,
                    DataStore = new FileDataStore("GoogleOAuthWinForms") // зберігає токен локально
                });

                var codeReceiver = new LocalServerCodeReceiver();
                var authCode = new AuthorizationCodeInstalledApp(flow, codeReceiver);
                var credential = await authCode.AuthorizeAsync("user", CancellationToken.None);

                if (credential.Token == null || string.IsNullOrEmpty(credential.Token.IdToken))
                {
                    MessageBox.Show("Не вдалося отримати токен Google.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Отримуємо дані користувача з токена
                var payload = await GoogleJsonWebSignature.ValidateAsync(credential.Token.IdToken);
                string email = payload.Email;
                string name = payload.Name ?? email;

                if (!Database.UserExists(email))
                    Database.AddUser(name, email, "google_auth");

                MessageBox.Show($"👋 Ласкаво просимо, {name}!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var adminForm = new AdminForm();
                adminForm.FormClosed += (s, args) => this.Close();
                adminForm.Show();
                this.Hide();
            }
            catch (TokenResponseException tex)
            {
                MessageBox.Show("Помилка авторизації Google: " + tex.Error.ErrorDescription, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка під час входу через Google: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
