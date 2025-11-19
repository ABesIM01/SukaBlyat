using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class OrderForm : Form
    {
        private readonly Dictionary<Panel, string> servicePanels = new Dictionary<Panel, string>();
        private readonly Color normalColor = Color.FromArgb(37, 37, 38);
        private readonly Color hoverColor = Color.FromArgb(50, 50, 52);
        private readonly Color selectedColor = Color.FromArgb(0, 122, 204);
        private readonly Color selectedTextColor = Color.White;
        private readonly Color normalTextColor = Color.White;

        public OrderForm()
        {
            InitializeComponent();
            InitializeServicePanels();
        }

        private void InitializeServicePanels()
        {
            servicePanels.Add(panelTaxi, "Таксі");
            servicePanels.Add(panelEscort, "Ескорт");
            servicePanels.Add(panelSecurity, "Охорона");
            servicePanels.Add(panelDelivery, "Доставка");

            foreach (var kvp in servicePanels)
            {
                var panel = kvp.Key;
                panel.BackColor = normalColor;
                panel.Cursor = Cursors.Hand;
                panel.Click += ServicePanel_Click;

                // 👉 виправлений код:
                foreach (Control c in panel.Controls)
                {
                    c.Click += (s, e) => ServicePanel_Click(panel, EventArgs.Empty);
                }

                panel.MouseEnter += (s, e) =>
                {
                    if (panel.Tag?.ToString() != "selected")
                        panel.BackColor = hoverColor;
                };
                panel.MouseLeave += (s, e) =>
                {
                    if (panel.Tag?.ToString() != "selected")
                        panel.BackColor = normalColor;
                };
            }

        }

        private void ServicePanel_Click(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            if (panel == null) return;

            bool isSelected = panel.Tag?.ToString() == "selected";
            panel.Tag = isSelected ? "" : "selected";
            panel.BackColor = isSelected ? normalColor : selectedColor;

            foreach (Control c in panel.Controls)
                c.ForeColor = isSelected ? normalTextColor : selectedTextColor;
        }

        private async void buttonOrder_Click(object sender, EventArgs e)
        {
            var selectedServices = new List<string>();
            foreach (var kvp in servicePanels)
            {
                if (kvp.Key.Tag?.ToString() == "selected")
                    selectedServices.Add(kvp.Value);
            }

            if (selectedServices.Count == 0)
            {
                MessageBox.Show("Будь ласка, оберіть хоча б одну послугу!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string userName = "Користувач";
            string orderDetails = string.Join(", ", selectedServices);
            string message = $"{userName} замовив: {orderDetails}";

            string botToken = "8276145573:AAGk5mlkvd5NChGwRz8s2s6JeiTZRIMRs_g";
            string chatId = "1822940984";

            buttonOrder.Enabled = false;
            buttonOrder.Text = "Відправлення...";

            try
            {
                await SendTelegramMessageAsync(botToken, chatId, message);
                ShowConfirmationModal(orderDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при відправленні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonOrder.Enabled = true;
                buttonOrder.Text = "Замовити";
            }
        }

        private void buttonShowOrders_Click(object sender, EventArgs e)
        {
            var viewForm = new OrdersViewForm();
            viewForm.ShowDialog();
        }

        private static async Task SendTelegramMessageAsync(string botToken, string chatId, string message)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://api.telegram.org/bot{botToken}/sendMessage";
                var data = new Dictionary<string, string>
                {
                    { "chat_id", chatId },
                    { "text", message }
                };
                var content = new FormUrlEncodedContent(data);
                await client.PostAsync(url, content);
            }
        }

        private void ShowConfirmationModal(string orderDetails)
        {
            Form modal = new Form
            {
                Size = new Size(300, 200),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.FromArgb(45, 45, 48),
                ShowInTaskbar = false
            };

            Label labelTitle = new Label
            {
                Text = "✅ Замовлення прийнято!",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };

            Label labelDetails = new Label
            {
                Text = $"Ви обрали:\n{orderDetails}",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            Button buttonOk = new Button
            {
                Text = "OK",
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Dock = DockStyle.Bottom,
                Height = 40
            };
            buttonOk.FlatAppearance.BorderSize = 0;
            buttonOk.Click += (s, e) => modal.Close();

            modal.Controls.Add(labelDetails);
            modal.Controls.Add(labelTitle);
            modal.Controls.Add(buttonOk);

            modal.ShowDialog();
        }
    }
}
