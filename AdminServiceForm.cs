using System;
using System.Data;
using System.Windows.Forms;
using DatabaseLibrary;

namespace WinFormsApp2
{
    public partial class AdminServiceForm : Form
    {
        public AdminServiceForm()
        {
            InitializeComponent();
            LoadServices();
        }

        private void LoadServices()
        {
            DataTable dt = Database.GetAllServices();
            if (dt != null)
                dataGridViewServices.DataSource = dt;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string desc = textBoxDescription.Text.Trim();
            string price = textBoxPrice.Text.Trim();

            if (name == "" || price == "")
            {
                MessageBox.Show("Назва та ціна обов'язкові!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Database.AddService(name, desc, price);
            LoadServices();
            ClearInputs();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть послугу для редагування.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridViewServices.SelectedRows[0].Cells["ID"].Value);
            string name = textBoxName.Text.Trim();
            string desc = textBoxDescription.Text.Trim();
            string price = textBoxPrice.Text.Trim();

            if (name == "" || price == "")
            {
                MessageBox.Show("Назва та ціна обов'язкові!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Database.UpdateService(id, name, desc, price);
            LoadServices();
            ClearInputs();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть послугу для видалення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridViewServices.SelectedRows[0].Cells["ID"].Value);
            var confirm = MessageBox.Show("Ви впевнені, що хочете видалити цю послугу?",
                "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Database.DeleteService(id);
                LoadServices();
                ClearInputs();
            }
        }

        private void dataGridViewServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                textBoxName.Text = dataGridViewServices.SelectedRows[0].Cells["name"].Value?.ToString();
                textBoxDescription.Text = dataGridViewServices.SelectedRows[0].Cells["description"].Value?.ToString();
                textBoxPrice.Text = dataGridViewServices.SelectedRows[0].Cells["price"].Value?.ToString();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            AdminUsersForm form = new AdminUsersForm();
            form.Show();
            this.Hide();
        }

        private void buttonTelephonia_Click(object sender, EventArgs e)
        {
            Telephonia phoneForm = new Telephonia();
            phoneForm.Show();
        }

        private void ClearInputs()
        {
            textBoxName.Clear();
            textBoxDescription.Clear();
            textBoxPrice.Clear();
        }
    }
}
