using System;
using System.Data;
using System.Windows.Forms;
using Databases;


namespace WinFormsApp2
{
    public partial class UserService : Form
    {
        public UserService()
        {
            InitializeComponent();
            LoadServicesFromDB();   // ✅ завантажуємо сервіси з бази
        }

        // === Завантаження послуг із бази даних ===
        private void LoadServicesFromDB()
        {
            try
            {
                DataTable dt = Database.GetAllServices(); // отримаємо таблицю з БД
                comboBoxServices.Items.Clear();

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Немає доступних послуг у базі даних.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // ✅ додаємо всі назви послуг у ComboBox
                foreach (DataRow row in dt.Rows)
                {
                    comboBoxServices.Items.Add(new ServiceModel(
                        row["name"].ToString(),
                        row["description"].ToString(),
                        row["price"].ToString()
                    ));
                }

                comboBoxServices.DisplayMember = "Name"; // показує назву
                comboBoxServices.ValueMember = "Name";

                // обираємо першу послугу
                if (comboBoxServices.Items.Count > 0)
                    comboBoxServices.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні послуг:\n" + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === Обробник вибору послуги ===
        private void comboBoxServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxServices.SelectedItem is ServiceModel selectedService)
            {
                textBoxName.Text = selectedService.Name;
                textBoxDescription.Text = selectedService.Description;
                textBoxPrice.Text = selectedService.Price;
            }
        }

        // === Додати у кошик ===
        private void buttonAddToCart_Click(object sender, EventArgs e)
        {
            if (comboBoxServices.SelectedItem is ServiceModel service)
            {
                MessageBox.Show($"Послугу '{service.Name}' додано до кошика!",
                    "Додано", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // === Перейти до кошика ===
        private void buttonGoToCart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Відкрито кошик користувача!", "Кошик", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}