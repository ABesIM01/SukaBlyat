using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace WinFormsApp2
{
    public partial class ForgotPasswordForm : Form
    {
        private string connectionString = "Data Source=users.db";

        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();

            if (username == "")
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT SecurityQuestion FROM Users WHERE Username=@user";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    var question = cmd.ExecuteScalar()?.ToString();
                    if (question != null)
                    {
                        labelQuestion.Text = question;
                        textBoxAnswer.Enabled = true;
                        buttonRecover.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("User not found.");
                    }
                }
            }
        }

        private void buttonRecover_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string answer = textBoxAnswer.Text.Trim();

            if (answer == "")
            {
                MessageBox.Show("Enter your security answer.");
                return;
            }

            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Password FROM Users WHERE Username=@user AND SecurityAnswer=@ans";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@ans", answer);
                    var password = cmd.ExecuteScalar()?.ToString();

                    if (password != null)
                    {
                        MessageBox.Show($"Your password is: {password}");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect answer.");
                    }
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
