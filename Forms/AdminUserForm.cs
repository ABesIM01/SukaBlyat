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
            ApplyDarkTheme();
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(22, 22, 22);

            // === GRID ===
            dataGridViewUsers.BackgroundColor = Color.FromArgb(28, 28, 28);
            dataGridViewUsers.DefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            dataGridViewUsers.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 52, 52);
            dataGridViewUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 36);
            dataGridViewUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // === LABELS ===
            StyleLabel(labelUsername);
            StyleLabel(labelEmail);
            StyleLabel(labelPassword);
            StyleLabel(labelRole);

            // === TEXTBOXES ===
            StyleTextBox(textBoxUsername);
            StyleTextBox(textBoxEmail);
            StyleTextBox(textBoxPassword);

            // === COMBOBOX ===
            comboRole.BackColor = Color.FromArgb(36, 36, 36);
            comboRole.ForeColor = Color.White;

            // === BUTTONS ===
            StyleButton(buttonAdd);
            StyleButton(buttonEdit);
            StyleButton(buttonDelete);
            StyleButton(buttonRefresh);
        }

        private void StyleLabel(Label lbl)
        {
            lbl.ForeColor = Color.White;
            lbl.Font = new Font("Segoe UI", 10F);
        }

        private void StyleTextBox(TextBox tb)
        {
            tb.BackColor = Color.FromArgb(36, 36, 36);
            tb.ForeColor = Color.White;
            tb.BorderStyle = BorderStyle.FixedSingle;
        }

        private void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(36, 36, 36);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
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
