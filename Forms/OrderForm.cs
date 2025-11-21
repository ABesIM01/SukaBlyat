using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp2.PayLogic;

namespace Forms
{
    public partial class OrderForm : Form
    {
        private readonly Dictionary<Panel, string> servicePanels = new();
        private readonly Color normalColor = Color.FromArgb(37, 37, 38);
        private readonly Color hoverColor = Color.FromArgb(50, 50, 52);
        private readonly Color selectedColor = Color.FromArgb(0, 122, 204);
        private readonly Color selectedTextColor = Color.White;
        private readonly Color normalTextColor = Color.White;

        private PaymentProcessor payment;
        private Panel currentlySelectedPanel = null;

        public OrderForm()
        {
            InitializeComponent();
            InitializeServicePanels();

            payment = new PaymentProcessor(
                publicKey: "sandbox_i93755190408",
                privateKey: "sandbox_VWm5JcETlYD4Q8VhWEEIIsk7hqkxptatzapjoUml"
            );
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

                foreach (Control control in panel.Controls)
                {
                    control.Cursor = Cursors.Hand;
                    control.Click += (s, e) => ServicePanel_Click(panel, EventArgs.Empty);
                }

                panel.MouseEnter += (s, e) =>
                {
                    if (panel != currentlySelectedPanel)
                        panel.BackColor = hoverColor;
                };

                panel.MouseLeave += (s, e) =>
                {
                    if (panel != currentlySelectedPanel)
                        panel.BackColor = normalColor;
                };
            }
        }

        private void ServicePanel_Click(object sender, EventArgs e)
        {
            var clickedPanel = sender as Panel;
            if (clickedPanel == null) return;

            if (clickedPanel == currentlySelectedPanel)
            {
                DeselectPanel(clickedPanel);
                currentlySelectedPanel = null;
            }
            else
            {
                if (currentlySelectedPanel != null)
                    DeselectPanel(currentlySelectedPanel);

                SelectPanel(clickedPanel);
                currentlySelectedPanel = clickedPanel;
            }
        }

        private void SelectPanel(Panel panel)
        {
            panel.BackColor = selectedColor;
            foreach (Control control in panel.Controls)
                control.ForeColor = selectedTextColor;
        }

        private void DeselectPanel(Panel panel)
        {
            panel.BackColor = normalColor;
            foreach (Control control in panel.Controls)
                control.ForeColor = normalTextColor;
        }

        private async void buttonOrder_Click(object sender, EventArgs e)
        {
            if (currentlySelectedPanel == null)
            {
                MessageBox.Show("Будь ласка, оберіть хоча б одну послугу!", "Увага",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedService = servicePanels[currentlySelectedPanel];

            buttonOrder.Enabled = false;
            buttonOrder.Text = "Переадресація...";
            Cursor = Cursors.WaitCursor;

            try
            {
                // Створюємо платіжний URL LiqPay
                string payUrl = await payment.CreatePaymentAsync(199, selectedService);

                // Відкриваємо браузер користувача на сторінку оплати
                Process.Start(new ProcessStartInfo
                {
                    FileName = payUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonOrder.Enabled = true;
                buttonOrder.Text = "Замовити";
                Cursor = Cursors.Default;
            }
        }

        private void buttonShowOrders_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тут буде логіка перегляду замовлень", "Перегляд замовлень",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
