// UseServiceTg.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseClass;      // тут лежить TGdatabase

namespace Forms
{
    public partial class UseServiceTg : Form
    {
        // Colors
        private readonly Color BackDark = Color.FromArgb(22, 22, 22);
        private readonly Color PanelDark = Color.FromArgb(36, 36, 36);
        private readonly Color Accent = Color.FromArgb(0, 120, 215);
        private readonly Color TextPrimary = Color.FromArgb(235, 235, 235);
        private readonly Color TextSecondary = Color.FromArgb(180, 180, 180);
        private readonly Color TileHover = Color.FromArgb(58, 58, 58);

        // Service tiles dictionary
        private readonly Dictionary<Panel, string> serviceTiles = new Dictionary<Panel, string>();

        public UseServiceTg()
        {
            InitializeComponent();

            // 1) Ініціалізація БД для телеграм-замовлень
            TGdatabase.Init();

            // 2) Прив’язуємо панелі-плитки до назв послуг
            serviceTiles.Add(tileTaxi, "Таксі");
            serviceTiles.Add(tileEscort, "Ескорт");
            serviceTiles.Add(tileSecurity, "Охорона");
            serviceTiles.Add(tileDelivery, "Доставка");

            // 3) Вішаємо обробники на плитки
            foreach (var kv in serviceTiles)
            {
                var p = kv.Key;
                p.Click += ServiceTile_Click;
                p.MouseEnter += Tile_MouseEnter;
                p.MouseLeave += Tile_MouseLeave;

                // клік по тексту всередині плитки теж має працювати
                foreach (Control c in p.Controls)
                    c.Click += (s, e) => ServiceTile_Click(p, EventArgs.Empty);
            }

            // 4) Стилізація DataGridView
            dataGridViewOrders.RowTemplate.Height = 42;
            dataGridViewOrders.DefaultCellStyle.SelectionBackColor = Color.FromArgb(50, 50, 50);
            dataGridViewOrders.DefaultCellStyle.SelectionForeColor = TextPrimary;
            dataGridViewOrders.DefaultCellStyle.BackColor = PanelDark;
            dataGridViewOrders.DefaultCellStyle.ForeColor = TextPrimary;
            dataGridViewOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            dataGridViewOrders.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
            dataGridViewOrders.GridColor = Color.FromArgb(45, 45, 45);
            dataGridViewOrders.BackgroundColor = BackDark;

            this.Load += Form1_Load;
            this.Shown += Form1_Shown;
        }

        // ----- Form events -----

        private void Form1_Shown(object? sender, EventArgs e)
        {
            // заокруглення кутів плиток
            RoundControl(tileTaxi, 8);
            RoundControl(tileEscort, 8);
            RoundControl(tileSecurity, 8);
            RoundControl(tileDelivery, 8);

            // активна вкладка за замовчуванням
            ActivateTab(btnTabOrder);
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            ApplyTheme(true);  // темна тема за замовчуванням
            LoadOrdersIntoGrid();
        }

        // ----- Перемикання вкладок -----

        private void ActivateTab(Button active)
        {
            var tabs = new[] { btnTabOrder, btnTabView, btnTabSettings };

            foreach (var t in tabs)
            {
                t.BackColor = Color.FromArgb(28, 28, 28);
                t.ForeColor = TextSecondary;
            }

            active.BackColor = BackDark;
            active.ForeColor = TextPrimary;

            panelOrder.Visible = active == btnTabOrder;
            panelView.Visible = active == btnTabView;
            panelSettings.Visible = active == btnTabSettings;

            if (active == btnTabView)
                LoadOrdersIntoGrid();
        }

        private void btnTabOrder_Click(object? sender, EventArgs e) => ActivateTab(btnTabOrder);
        private void btnTabView_Click(object? sender, EventArgs e) => ActivateTab(btnTabView);
        private void btnTabSettings_Click(object? sender, EventArgs e) => ActivateTab(btnTabSettings);

        // ----- Плитки послуг -----

        private void Tile_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Panel p && p.Tag?.ToString() != "selected")
                p.BackColor = TileHover;
        }

        private void Tile_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Panel p && p.Tag?.ToString() != "selected")
                p.BackColor = PanelDark;
        }

        private void ServiceTile_Click(object? sender, EventArgs e)
        {
            if (sender is not Panel p) return;

            bool isSelected = p.Tag?.ToString() == "selected";

            if (!isSelected)
            {
                p.Tag = "selected";
                p.BackColor = Accent;
                foreach (Control c in p.Controls)
                    c.ForeColor = Color.White;
            }
            else
            {
                p.Tag = null;
                p.BackColor = PanelDark;
                foreach (Control c in p.Controls)
                    c.ForeColor = TextPrimary;
            }
        }

        // ----- Створення замовлення -----

        private async void btnMakeOrder_Click(object? sender, EventArgs e)
        {
            var selected = serviceTiles
                .Where(kv => kv.Key.Tag?.ToString() == "selected")
                .Select(kv => kv.Value)
                .ToList();

            if (!selected.Any())
            {
                MessageBox.Show("Оберіть принаймні одну послугу.", "Увага",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = string.IsNullOrWhiteSpace(txtUserName.Text)
                ? "Клієнт"
                : txtUserName.Text.Trim();

            string products = string.Join(", ", selected);

            try
            {
                // зберігаємо у окрему БД телеграм-замовлень
                TGdatabase.AddOrder(name, products);

                // відправляємо в телеграм
                string botToken = "8276145573:AAGk5mlkvd5NChGwRz8s2s6JeiTZRIMRs_g";
                string chatId = "1822940984";
                string message = $"{name} замовив: {products}";
                var sendTask = SendTelegramMessageAsync(botToken, chatId, message);

                ShowConfirmationModal(name, products);

                // скидаємо вибір
                foreach (var kv in serviceTiles)
                {
                    kv.Key.Tag = null;
                    kv.Key.BackColor = PanelDark;
                    foreach (Control c in kv.Key.Controls)
                        c.ForeColor = TextPrimary;
                }
                txtUserName.Clear();

                if (panelView.Visible)
                    LoadOrdersIntoGrid();

                await sendTask; // помилки телеграма ігноруємо
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не вдалося зберегти замовлення: " + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static async Task SendTelegramMessageAsync(string botToken, string chatId, string message)
        {
            try
            {
                using var client = new HttpClient();
                string url = $"https://api.telegram.org/bot{botToken}/sendMessage";

                var data = new Dictionary<string, string>
                {
                    { "chat_id", chatId },
                    { "text", message }
                };

                using var content = new FormUrlEncodedContent(data);
                var resp = await client.PostAsync(url, content);
                resp.EnsureSuccessStatusCode();
            }
            catch
            {
                // не критично — запис у БД вже є
            }
        }

        // ----- Модальне вікно підтвердження -----

        private void ShowConfirmationModal(string name, string products)
        {
            var modal = new Form
            {
                Size = new Size(420, 220),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.FromArgb(28, 28, 28),
                ShowInTaskbar = false
            };

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(36, 36, 36),
                Padding = new Padding(18)
            };
            modal.Controls.Add(panel);

            var lblTitle = new Label
            {
                Text = "✔ Замовлення прийнято",
                Font = new Font("Segoe UI Semibold", 14, FontStyle.Bold),
                ForeColor = TextPrimary,
                Dock = DockStyle.Top,
                Height = 36,
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(lblTitle);

            var lblDetail = new Label
            {
                Text = $"{name}\n{products}",
                Font = new Font("Segoe UI", 10),
                ForeColor = TextSecondary,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(lblDetail);

            var btnOk = new Button
            {
                Text = "OK",
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Accent,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10)
            };
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Click += (s, e) => modal.Close();
            panel.Controls.Add(btnOk);

            modal.ShowDialog(this);
        }

        // ----- Таблиця замовлень -----

        private void LoadOrdersIntoGrid()
        {
            try
            {
                DataTable dt = TGdatabase.GetOrders();
                dataGridViewOrders.DataSource = dt;

                if (dataGridViewOrders.Columns.Contains("ID"))
                    dataGridViewOrders.Columns["ID"].Visible = false;

                if (!dataGridViewOrders.Columns.Contains("Delete"))
                {
                    var del = new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        HeaderText = "",
                        Text = "🗑",
                        UseColumnTextForButtonValue = true,
                        Width = 48,
                        FlatStyle = FlatStyle.Flat
                    };
                    dataGridViewOrders.Columns.Add(del);
                }

                foreach (DataGridViewColumn col in dataGridViewOrders.Columns)
                    col.HeaderCell.Style.Font = new Font("Segoe UI Semibold", 9F);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не вдалося завантажити замовлення: " + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewOrders_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridViewOrders.Columns[e.ColumnIndex].Name != "Delete") return;

            var row = dataGridViewOrders.Rows[e.RowIndex];
            if (row.Cells["ID"].Value == null) return;

            int id = Convert.ToInt32(row.Cells["ID"].Value);
            var r = MessageBox.Show("Видалити замовлення?", "Підтвердження",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                TGdatabase.DeleteOrder(id);
                LoadOrdersIntoGrid();
            }
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            try
            {
                if (dataGridViewOrders.DataSource is DataTable dt)
                {
                    var dv = dt.DefaultView;
                    string f = txtSearch.Text.Replace("'", "''");
                    dv.RowFilter = $"[Користувач] LIKE '%{f}%' OR [Послуги] LIKE '%{f}%'";
                }
            }
            catch
            {
                // ігноруємо помилковий фільтр
            }
        }

        private void btnClearAll_Click(object? sender, EventArgs e)
        {
            var r = MessageBox.Show("Очистити всі замовлення? Це необоротно.",
                "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                TGdatabase.ClearAllOrders();
                LoadOrdersIntoGrid();
            }
        }

        private void btnExportPdf_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Експорт PDF поки не реалізований.",
                "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ----- Налаштування / тема -----

        private void btnSaveSettings_Click(object? sender, EventArgs e)
        {
            bool dark = chkDarkMode.Checked;
            ApplyTheme(dark);
        }

        private void ApplyTheme(bool dark)
        {
            Color bg = dark ? BackDark : Color.White;
            Color panelBg = dark ? PanelDark : Color.FromArgb(245, 245, 245);
            Color text = dark ? TextPrimary : Color.FromArgb(32, 32, 32);
            Color sub = dark ? TextSecondary : Color.FromArgb(100, 100, 100);

            BackColor = bg;
            topPanel.BackColor = dark ? Color.FromArgb(28, 28, 28) : Color.FromArgb(240, 240, 240);
            contentPanel.BackColor = bg;

            foreach (Control c in topPanel.Controls)
            {
                if (c is Button b)
                {
                    b.FlatStyle = FlatStyle.Flat;
                    b.BackColor = dark ? Color.FromArgb(28, 28, 28) : Color.FromArgb(240, 240, 240);
                    b.ForeColor = sub;
                }
            }

            panelOrder.BackColor = bg;
            panelView.BackColor = bg;
            panelSettings.BackColor = bg;

            foreach (var kv in serviceTiles)
            {
                var p = kv.Key;
                if (p.Tag?.ToString() == "selected")
                {
                    p.BackColor = Accent;
                    foreach (Control ch in p.Controls)
                        ch.ForeColor = Color.White;
                }
                else
                {
                    p.BackColor = panelBg;
                    foreach (Control ch in p.Controls)
                        ch.ForeColor = text;
                }
            }

            txtUserName.BackColor = dark ? Color.FromArgb(30, 30, 30) : Color.White;
            txtUserName.ForeColor = text;

            btnMakeOrder.BackColor = Accent;
            btnMakeOrder.ForeColor = Color.White;

            txtSearch.BackColor = dark ? Color.FromArgb(30, 30, 30) : Color.White;
            txtSearch.ForeColor = text;

            btnClearAll.BackColor = dark ? Color.FromArgb(64, 64, 64) : Color.FromArgb(220, 220, 220);
            btnClearAll.ForeColor = Color.White;

            chkDarkMode.ForeColor = text;
            btnSaveSettings.BackColor = dark ? Color.FromArgb(64, 64, 64) : Color.FromArgb(220, 220, 220);
            btnSaveSettings.ForeColor = Color.FromArgb(250, 250, 250);

            if (dark)
            {
                dataGridViewOrders.BackgroundColor = BackDark;
                dataGridViewOrders.DefaultCellStyle.BackColor = PanelDark;
                dataGridViewOrders.DefaultCellStyle.ForeColor = TextPrimary;
                dataGridViewOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
                dataGridViewOrders.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
            }
            else
            {
                dataGridViewOrders.BackgroundColor = Color.White;
                dataGridViewOrders.DefaultCellStyle.BackColor = Color.White;
                dataGridViewOrders.DefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
                dataGridViewOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                dataGridViewOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
            }
        }

        // ----- Допоміжне: заокруглення кутів -----

        private void RoundControl(Control ctrl, int radius)
        {
            var rect = new Rectangle(0, 0, ctrl.Width, ctrl.Height);
            using var gp = new GraphicsPath();
            gp.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            gp.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            gp.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            gp.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            gp.CloseFigure();
            ctrl.Region = new Region(gp);
        }
    }
}
