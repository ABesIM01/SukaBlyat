using System;
using System.Collections.Generic;
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

        // ������ Log In
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "admin" && textBoxPassword.Text == "1234")
            {
                MessageBox.Show("Login successful!");
                this.Hide();
                AdminForm adminForm = new AdminForm();
                adminForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        // ������ Cancel
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ������� Show Password
        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = checkBoxShowPassword.Checked ? '\0' : '*';
        }

        private void labelUsername_Click(object sender, EventArgs e)
        {
            // �������� ��� Label ���� Click �� �������, ����� ��������
        }

        private void labelUsername_Click_1(object sender, EventArgs e)
        {

        }

    }
}
