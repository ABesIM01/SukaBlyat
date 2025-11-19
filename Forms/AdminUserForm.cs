using System;
using System.Data;
using System.Windows.Forms;
using DatabaseLibrary;

namespace Forms
{
    public partial class AdminUsersForm : Form
    {
        public AdminUsersForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        // Завантажити користувачів
        private void LoadUsers()
        {
            DataTable dt = Database.GetAllUsers(); // Додамо цей метод у Database.cs
            dataGridViewUsers.DataSource = dt;
        }

        private void dataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0) return;

            var row = dataGridViewUsers.SelectedRows[0];

            textBoxUsername.Text = row.Cells["username"].Value.ToString();
            textBoxEmail.Text = row.Cells["email"].Value.ToString();
            comboRole.Text = row.Cells["role"].Value.ToString();
            textBoxPassword.Clear();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "" || textBoxEmail.Text == "")
            {
                MessageBox.Show("Логін та email обов’язкові!");
                return;
            }

            string pass = textBoxPassword.Text == "" ? "12345" : textBoxPassword.Text;

            Database.AddUser(
                textBoxUsername.Text,
                textBoxEmail.Text,
                pass,
                comboRole.Text
            );

            LoadUsers();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0) return;

            string newPassword = textBoxPassword.Text.Trim();
            string role = comboRole.Text;

            Database.UpdateUser(
                dataGridViewUsers.SelectedRows[0].Cells["ID"].Value.ToString(),
                textBoxUsername.Text,
                textBoxEmail.Text,
                newPassword,
                role
            );

            LoadUsers();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть користувача для видалення.");
                return;
            }

            var row = dataGridViewUsers.SelectedRows[0];

            string id = row.Cells["ID"].Value.ToString();
            string role = row.Cells["role"].Value.ToString();

            // ❗ Заборона видаляти адміна
            if (role == "admin")
            {
                MessageBox.Show("Неможливо видалити адміністратора!", "Заборонено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Підтвердження
            var confirm = MessageBox.Show("Ви впевнені, що хочете видалити цього користувача?",
                "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Database.DeleteUser(id);
                LoadUsers();
            }
        }


        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }
    }
}
