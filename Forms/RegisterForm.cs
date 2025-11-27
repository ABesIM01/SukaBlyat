using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Databases;

namespace Forms
{
    public partial class RegisterForm : Form
    {
        private readonly LoginForm loginForm;

        public RegisterForm(LoginForm loginForm)
        {
            InitializeComponent();
            Database.Init();
            this.loginForm = loginForm;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBoxUsername.Text.Trim();
                string email = textBoxEmail.Text.Trim();
                string password = textBoxPassword.Text;

                // Перевірки полів
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Заповніть усі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Введено некоректний email.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Database.UserExists(email))
                {
                    MessageBox.Show("Користувач з таким email вже існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Database.UsernameExists(username))
                {
                    MessageBox.Show("Користувач з таким іменем вже існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Тепер не хешуємо вручну — AddUser зробить це сам
                Database.AddUser(username, email, password);

                MessageBox.Show("Реєстрація успішна!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OpenAdminForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час реєстрації:\n{ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }

        private void OpenAdminForm()
        {
            var ServiceForm = new UseServiceTg();
            ServiceForm.FormClosed += (s, args) => loginForm.Close();
            ServiceForm.Show();
            this.Hide();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
