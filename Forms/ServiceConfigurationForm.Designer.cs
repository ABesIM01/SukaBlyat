namespace Forms
{
    partial class ServiceConfigurationForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel topBorder;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelOption;
        private System.Windows.Forms.ComboBox comboOption;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.NumericUpDown numericQuantity;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Button buttonAddToCart;
        private System.Windows.Forms.Button buttonCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ----- Form -----
            this.Text = "Configure Service";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ClientSize = new System.Drawing.Size(450, 400);
            this.BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Opacity = 0;

            // ----- Top Border -----
            topBorder = new System.Windows.Forms.Panel
            {
                Height = 3,
                Dock = System.Windows.Forms.DockStyle.Top,
                BackColor = System.Drawing.Color.FromArgb(55, 125, 255)
            };
            this.Controls.Add(topBorder);

            // ----- TableLayoutPanel -----
            mainLayout = new System.Windows.Forms.TableLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Padding = new System.Windows.Forms.Padding(20),
                RowCount = 10,
                ColumnCount = 2
            };
            mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            for (int i = 0; i < mainLayout.RowCount; i++)
                mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));

            this.Controls.Add(mainLayout);

            // ----- Controls -----
            labelTitle = new System.Windows.Forms.Label
            {
                Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                Dock = System.Windows.Forms.DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            mainLayout.Controls.Add(labelTitle, 0, 0);
            mainLayout.SetColumnSpan(labelTitle, 2);

            labelOption = new System.Windows.Forms.Label
            {
                Text = "Варіант:",
                ForeColor = System.Drawing.Color.White,
                Dock = System.Windows.Forms.DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            mainLayout.Controls.Add(labelOption, 0, 1);

            comboOption = new System.Windows.Forms.ComboBox
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList,
                BackColor = System.Drawing.Color.FromArgb(36, 36, 36),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 10F)
            };
            mainLayout.Controls.Add(comboOption, 1, 1);

            labelQuantity = new System.Windows.Forms.Label
            {
                Text = "Кількість:",
                ForeColor = System.Drawing.Color.White,
                Dock = System.Windows.Forms.DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            mainLayout.Controls.Add(labelQuantity, 0, 2);

            numericQuantity = new System.Windows.Forms.NumericUpDown
            {
                Minimum = 1,
                Maximum = 999,
                Value = 1,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                BackColor = System.Drawing.Color.FromArgb(36, 36, 36),
                ForeColor = System.Drawing.Color.White
            };
            mainLayout.Controls.Add(numericQuantity, 1, 2);

            labelNotes = new System.Windows.Forms.Label
            {
                Text = "Додаткові нотатки:",
                ForeColor = System.Drawing.Color.White,
                Dock = System.Windows.Forms.DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            mainLayout.Controls.Add(labelNotes, 0, 3);
            mainLayout.SetColumnSpan(labelNotes, 2);

            textBoxNotes = new System.Windows.Forms.TextBox
            {
                Multiline = true,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Height = 80,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                BackColor = System.Drawing.Color.FromArgb(36, 36, 36),
                ForeColor = System.Drawing.Color.White
            };
            mainLayout.Controls.Add(textBoxNotes, 0, 4);
            mainLayout.SetColumnSpan(textBoxNotes, 2);

            buttonAddToCart = new System.Windows.Forms.Button
            {
                Text = "Додати в кошик",
                BackColor = System.Drawing.Color.FromArgb(55, 125, 255),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                Dock = System.Windows.Forms.DockStyle.Fill
            };
            buttonAddToCart.FlatAppearance.BorderSize = 0;
            mainLayout.Controls.Add(buttonAddToCart, 1, 9);

            buttonCancel = new System.Windows.Forms.Button
            {
                Text = "Скасувати",
                BackColor = System.Drawing.Color.FromArgb(80, 80, 80),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 11F),
                Dock = System.Windows.Forms.DockStyle.Fill
            };
            buttonCancel.FlatAppearance.BorderSize = 0;
            mainLayout.Controls.Add(buttonCancel, 0, 9);
        }
    }
}
