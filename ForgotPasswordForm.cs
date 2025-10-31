using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class ForgotPasswordForm : Form
    {
        private string connectionString = "Data Source=users.db;Version=3;";
        private string foundUsername = "";
        private string foundEmail = "";
        private string correctAnswer = "";

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
                string query = "SELECT question, answer FROM users WHERE username=@username AND email=@email";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            labelQuestion.Text = "Контрольне запитання: " + reader["question"].ToString();
                            correctAnswer = reader["answer"].ToString();
                            foundUsername = username;
                            foundEmail = email;

                            textBoxAnswer.Enabled = true;
                            buttonRecover.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Користувача з такими даними не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // ======== ВІДНОВЛЕННЯ ПАРОЛЯ ========
        private void buttonRecover_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAnswer.Text))
            {
                MessageBox.Show("Введіть відповідь на контрольне запитання.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBoxAnswer.Text.Trim().ToLower() != correctAnswer.ToLower())
            {
                MessageBox.Show("Неправильна відповідь!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Якщо відповідь правильна — відкриваємо форму зміни пароля
            ResetPasswordForm resetForm = new ResetPasswordForm(foundUsername, foundEmail);
            DialogResult result = resetForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("Пароль успішно змінено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
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