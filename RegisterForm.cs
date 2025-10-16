using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WinFormsApp2
{
    public partial class RegisterForm : Form
    {
        private LoginForm loginForm;

        public RegisterForm(LoginForm loginForm)
        {
            InitializeComponent();
            Database.Init();
            this.loginForm = loginForm;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text;

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

            string hashedPassword = Database.HashPassword(password);
            Database.AddUser(username, email, hashedPassword);

            MessageBox.Show("Реєстрація успішна!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OpenAdminForm();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }

        private void OpenAdminForm()
        {
            var adminForm = new AdminForm();
            adminForm.FormClosed += (s, args) => loginForm.Close(); // закриваємо LoginForm після AdminForm
            adminForm.Show();
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
