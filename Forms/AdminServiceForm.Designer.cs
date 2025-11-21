using System;
using System.Drawing;
using System.Windows.Forms;

namespace Forms
{
    partial class AdminServiceForm
    {
        private DataGridView dataGridViewServices;
        private Label labelName;
        private Label labelPrice;
        private TextBox textBoxName;
        private TextBox textBoxPrice;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonRefresh;
        private Button buttonUsers;
        private Button buttonTelephonia;

        private Panel cardPanel;

        private void InitializeComponent()
        {
            this.BackColor = Color.FromArgb(20, 20, 20);
            this.ClientSize = new Size(1100, 540);
            this.Text = "Адмін-панель — Послуги";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10F);

            // =========== GRID ===========
            dataGridViewServices = new DataGridView
            {
                Location = new Point(20, 20),
                Size = new Size(650, 480),
                ReadOnly = true,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.FromArgb(32, 32, 32),
                BorderStyle = BorderStyle.None,
                GridColor = Color.FromArgb(70, 70, 70),
                EnableHeadersVisualStyles = false
            };

            dataGridViewServices.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dataGridViewServices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewServices.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11F);

            dataGridViewServices.RowTemplate.Height = 36;
            dataGridViewServices.DefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            dataGridViewServices.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewServices.DefaultCellStyle.SelectionBackColor = Color.FromArgb(55, 110, 255);
            dataGridViewServices.DefaultCellStyle.SelectionForeColor = Color.White;

            this.Controls.Add(dataGridViewServices);

            // =========== CARD PANEL ===========
            cardPanel = new Panel
            {
                Location = new Point(700, 20),
                Size = new Size(360, 480),
                BackColor = Color.FromArgb(30, 30, 30),
                Padding = new Padding(20)
            };

            cardPanel.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(55, 55, 55), 1))
                    e.Graphics.DrawRectangle(pen, 0, 0, cardPanel.Width - 1, cardPanel.Height - 1);
            };

            this.Controls.Add(cardPanel);

            // ===== Заголовок панелі =====
            Label title = new Label
            {
                Text = "Редагування послуги",
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 13F),
                Location = new Point(10, 5),
                AutoSize = true
            };
            cardPanel.Controls.Add(title);

            int Y = 50;

            // ===== Name =====
            labelName = CreateLabel("Назва", 10, Y);
            textBoxName = CreateInput(10, Y + 28, 320);
            Y += 80;

            // ===== Price =====
            labelPrice = CreateLabel("Ціна", 10, Y);
            textBoxPrice = CreateInput(10, Y + 28, 320);
            Y += 80;

            // ===== BUTTONS =====
            buttonAdd = CreateButton("➕ Додати", 10, Y, buttonAdd_Click, true);
            buttonEdit = CreateButton("✏ Редагувати", 185, Y, buttonEdit_Click);
            Y += 60;

            buttonDelete = CreateButton("🗑 Видалити", 10, Y, buttonDelete_Click);
            buttonRefresh = CreateButton("🔄 Оновити", 185, Y, buttonRefresh_Click);
            Y += 70;

            buttonUsers = CreateButton("👤 Користувачі", 10, Y, buttonUsers_Click, false, 330);
            Y += 55;

            buttonTelephonia = CreateButton("📞 Менеджер дзвінків", 10, Y, buttonTelephonia_Click, false, 330);

            // Додаємо до панелі
            cardPanel.Controls.Add(labelName);
            cardPanel.Controls.Add(textBoxName);

            cardPanel.Controls.Add(labelPrice);
            cardPanel.Controls.Add(textBoxPrice);

            cardPanel.Controls.Add(buttonAdd);
            cardPanel.Controls.Add(buttonEdit);
            cardPanel.Controls.Add(buttonDelete);
            cardPanel.Controls.Add(buttonRefresh);
            cardPanel.Controls.Add(buttonUsers);
            cardPanel.Controls.Add(buttonTelephonia);
        }
    }
}