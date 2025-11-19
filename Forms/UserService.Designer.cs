using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class UserService : Form
    {
        private ComboBox comboBoxServices;
        private Label labelName;
        private Label labelDescription;
        private Label labelPrice;
        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private TextBox textBoxPrice;
        private Button buttonAddToCart;
        private Button buttonGoToCart; // 🔹 нова кнопка

        private void InitializeComponent()
        {
            comboBoxServices = new ComboBox();
            labelName = new Label();
            labelDescription = new Label();
            labelPrice = new Label();
            textBoxName = new TextBox();
            textBoxDescription = new TextBox();
            textBoxPrice = new TextBox();
            buttonAddToCart = new Button();
            buttonGoToCart = new Button();
            SuspendLayout();
            // 
            // comboBoxServices
            // 
            comboBoxServices.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxServices.Location = new Point(20, 30);
            comboBoxServices.Name = "comboBoxServices";
            comboBoxServices.Size = new Size(250, 28);
            comboBoxServices.TabIndex = 0;
            comboBoxServices.SelectedIndexChanged += comboBoxServices_SelectedIndexChanged;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(300, 30);
            labelName.Name = "labelName";
            labelName.Size = new Size(54, 20);
            labelName.TabIndex = 1;
            labelName.Text = "Назва:";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(300, 70);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(48, 20);
            labelDescription.TabIndex = 3;
            labelDescription.Text = "Опис:";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(300, 170);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(44, 20);
            labelPrice.TabIndex = 5;
            labelPrice.Text = "Ціна:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(380, 30);
            textBoxName.Name = "textBoxName";
            textBoxName.ReadOnly = true;
            textBoxName.Size = new Size(200, 27);
            textBoxName.TabIndex = 2;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(380, 70);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.ReadOnly = true;
            textBoxDescription.Size = new Size(200, 80);
            textBoxDescription.TabIndex = 4;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(380, 170);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.ReadOnly = true;
            textBoxPrice.Size = new Size(100, 27);
            textBoxPrice.TabIndex = 6;
            // 
            // buttonAddToCart
            // 
            buttonAddToCart.Location = new Point(380, 210);
            buttonAddToCart.Name = "buttonAddToCart";
            buttonAddToCart.Size = new Size(200, 35);
            buttonAddToCart.TabIndex = 7;
            buttonAddToCart.Text = "\U0001f6d2 Додати в кошик";
            buttonAddToCart.Click += buttonAddToCart_Click;
            // 
            // buttonGoToCart
            // 
            buttonGoToCart.Location = new Point(380, 255);
            buttonGoToCart.Name = "buttonGoToCart";
            buttonGoToCart.Size = new Size(200, 35);
            buttonGoToCart.TabIndex = 8;
            buttonGoToCart.Text = "➡️ Перейти до кошика";
            buttonGoToCart.Click += buttonGoToCart_Click;
            // 
            // Form2
            // 
            ClientSize = new Size(620, 320);
            Controls.Add(comboBoxServices);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            Controls.Add(labelDescription);
            Controls.Add(textBoxDescription);
            Controls.Add(labelPrice);
            Controls.Add(textBoxPrice);
            Controls.Add(buttonAddToCart);
            Controls.Add(buttonGoToCart);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Адмін-панель — Сервіси";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
