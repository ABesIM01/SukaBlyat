using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Forms
{
    public partial class ServiceConfigurationForm : Form
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Confirmed { get; private set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Quantity { get; private set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Notes { get; private set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OptionSelected { get; private set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ServiceName { get; private set; }


        public ServiceConfigurationForm(string serviceName)
        {
            ServiceName = serviceName;
            InitializeComponent();
            labelTitle.Text = serviceName;

            PopulateOptions(serviceName);

            buttonAddToCart.Click += ButtonAddToCart_Click;
            buttonCancel.Click += ButtonCancel_Click;
            this.Shown += ServiceConfigurationForm_Shown;
        }

        private void ServiceConfigurationForm_Shown(object sender, EventArgs e)
        {
            var fade = new System.Windows.Forms.Timer();
            fade.Interval = 15;
            fade.Tick += (s, ev) =>
            {
                if (this.Opacity < 1) this.Opacity += 0.05;
                else fade.Stop();
            };
            fade.Start();

        }

        private void PopulateOptions(string service)
        {
            comboOption.Items.Clear();
            switch (service)
            {
                case "Таксі":
                    comboOption.Items.AddRange(new string[] { "Економ", "Комфорт", "VIP" });
                    break;
                case "Ескорт":
                    comboOption.Items.AddRange(new string[] { "Стандарт", "Преміум" });
                    break;
                case "Доставка":
                    comboOption.Items.AddRange(new string[] { "Мала", "Середня", "Велика" });
                    break;
                case "Охорона":
                    comboOption.Items.AddRange(new string[] { "Один охоронець", "Два охоронці", "Повний патруль" });
                    break;
                default:
                    comboOption.Items.Add("Стандарт");
                    break;
            }
            if (comboOption.Items.Count > 0) comboOption.SelectedIndex = 0;
        }

        private void ButtonAddToCart_Click(object sender, EventArgs e)
        {
            Confirmed = true;
            Quantity = (int)numericQuantity.Value;
            Notes = textBoxNotes.Text.Trim();
            OptionSelected = comboOption.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Confirmed = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
