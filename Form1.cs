using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вхід виконано успішно!");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Перехід до реєстрації.");
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Функція відновлення паролю наразі недоступна.");
        }
    }
}
