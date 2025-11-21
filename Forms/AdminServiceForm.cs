using System;
using System.Data;
using System.Windows.Forms;
using DatabaseLibrary;

namespace Forms
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

        private Label CreateLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                ForeColor = Color.FromArgb(200, 200, 200),
                Font = new Font("Segoe UI", 10F),
                Location = new Point(x, y),
                AutoSize = true
            };
        }

        private TextBox CreateInput(int x, int y, int w = 250, int h = 35, bool multiline = false)
        {
            return new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(w, h),
                Multiline = multiline,
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10F)
            };
        }

        private Button CreateButton(string text, int x, int y, EventHandler click, bool accent = false, int width = 150)
        {
            Color bg = accent ? Color.FromArgb(55, 110, 255) : Color.FromArgb(45, 45, 45);

            var btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, 45),
                BackColor = bg,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10F)
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = accent
                ? Color.FromArgb(70, 130, 255)
                : Color.FromArgb(60, 60, 60);

            btn.Click += click;
            return btn;
        }

        // =============================
        //      ДОДАТИ
        // =============================
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string price = textBoxPrice.Text.Trim();

            if (name == "" || price == "")
            {
                MessageBox.Show("Назва та ціна обов'язкові!", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Database.AddService(name, price);
            LoadServices();
            ClearInputs();
        }

        // =============================
        //      РЕДАГУВАТИ
        // =============================
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть послугу для редагування.", "Увага",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridViewServices.SelectedRows[0].Cells["ID"].Value);
            string name = textBoxName.Text.Trim();
            string price = textBoxPrice.Text.Trim();

            if (name == "" || price == "")
            {
                MessageBox.Show("Назва та ціна обов'язкові!", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Database.UpdateService(id, name, price);
            LoadServices();
            ClearInputs();
        }

        // =============================
        //      ВИДАЛИТИ
        // =============================
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть послугу для видалення.", "Увага",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // =============================
        //     ЗАПОВНЕННЯ ПОЛІВ
        // =============================
        private void dataGridViewServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                textBoxName.Text = dataGridViewServices.SelectedRows[0].Cells["name"].Value?.ToString();
                textBoxPrice.Text = dataGridViewServices.SelectedRows[0].Cells["price"].Value?.ToString();
            }
        }

        // =============================
        //     ІНШІ КНОПКИ
        // =============================
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

        // =============================
        //     ОЧИСТКА ПОЛІВ
        // =============================
        private void ClearInputs()
        {
            textBoxName.Clear();
            textBoxPrice.Clear();
        }
    }
}