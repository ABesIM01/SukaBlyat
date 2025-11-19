using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    public partial class ResetPasswordForm : Form
    {
        private string username;
        private string email;
        private string connectionString = "Data Source=app.db;Version=3;";

        public ResetPasswordForm(string username, string email)
        {
            InitializeComponent();
            this.username = username;
            this.email = email;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string newPass = textBoxNewPassword.Text.Trim();
            string confirmPass = textBoxConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Усі поля повинні бути заповнені.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Паролі не співпадають!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newSalt = GenerateSalt();
            string newHash = HashPassword(newPass, newSalt);

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string update = "UPDATE users SET password=@hash, salt=@salt WHERE username=@username AND email=@email";
                using (var cmd = new SQLiteCommand(update, conn))
                {
                    cmd.Parameters.AddWithValue("@hash", newHash);
                    cmd.Parameters.AddWithValue("@salt", newSalt);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Пароль успішно змінено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string HashPassword(string password, string salt)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }
    }
}
