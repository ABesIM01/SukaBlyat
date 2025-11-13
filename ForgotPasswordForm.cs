using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class ForgotPasswordForm : Form
    {
        private string connectionString = "Data Source=app.db;Version=3;";
        private string foundUsername = "";
        private string foundEmail = "";

        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        // ======== ПОШУК КОРИСТУВАЧА ========
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string email = textBoxEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Будь ласка, введіть і логін, і пошту.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id FROM users WHERE username=@username AND email=@email";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);

                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        foundUsername = username;
                        foundEmail = email;

                        MessageBox.Show("Користувача знайдено! Тепер можна змінити пароль.",
                            "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        buttonRecover.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Користувача з такими даними не знайдено.",
                            "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ======== ВІДНОВЛЕННЯ ПАРОЛЯ ========
        private void buttonRecover_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(foundUsername) || string.IsNullOrEmpty(foundEmail))
            {
                MessageBox.Show("Спочатку знайдіть користувача.", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Відкриваємо форму зміни пароля
            ResetPasswordForm resetForm = new ResetPasswordForm(foundUsername, foundEmail);
            DialogResult result = resetForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("Пароль успішно змінено!",
                    "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        // ======== СКАСУВАТИ ========
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
