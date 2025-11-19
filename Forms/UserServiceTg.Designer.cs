using System;
using System.Windows.Forms;

namespace Forms
{
    partial class UseServiceTg
    {
        private System.ComponentModel.IContainer components = null;

        private Panel topPanel;
        private Button btnTabOrder;
        private Button btnTabView;
        private Button btnTabSettings;

        private Panel contentPanel;

        private Panel panelOrder;
        private Label lblOrderHeader;
        private Panel servicesWrap;
        private Panel tileTaxi;
        private Label labelTaxi;
        private Panel tileEscort;
        private Label labelEscort;
        private Panel tileSecurity;
        private Label labelSecurity;
        private Panel tileDelivery;
        private Label labelDelivery;

        private TextBox txtUserName;
        private Button btnMakeOrder;
        private Label lblHints;

        private Panel panelView;
        private DataGridView dataGridViewOrders;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnClearAll;
        private Button btnExportPdf;

        private Panel panelSettings;
        private CheckBox chkDarkMode;
        private Button btnSaveSettings;
        private Label lblSettingsHeader;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ==== FORM ====
            this.Text = "CRM — Telegram Services";
            this.ClientSize = new System.Drawing.Size(900, 620);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // ===============================
            // TOP PANEL
            // ===============================
            this.topPanel = new Panel();
            this.topPanel.Dock = DockStyle.Top;
            this.topPanel.Height = 64;
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            this.topPanel.Padding = new Padding(18);

            this.btnTabOrder = new Button();
            this.btnTabOrder.Text = "Замовлення";
            this.btnTabOrder.Size = new System.Drawing.Size(160, 36);
            this.btnTabOrder.Location = new System.Drawing.Point(18, 16);
            this.btnTabOrder.FlatStyle = FlatStyle.Flat;
            this.btnTabOrder.FlatAppearance.BorderSize = 0;
            this.btnTabOrder.ForeColor = System.Drawing.Color.White;
            this.btnTabOrder.Click += new EventHandler(this.btnTabOrder_Click);

            this.btnTabView = new Button();
            this.btnTabView.Text = "Перегляд";
            this.btnTabView.Size = new System.Drawing.Size(120, 36);
            this.btnTabView.Location = new System.Drawing.Point(190, 16);
            this.btnTabView.FlatStyle = FlatStyle.Flat;
            this.btnTabView.FlatAppearance.BorderSize = 0;
            this.btnTabView.ForeColor = System.Drawing.Color.White;
            this.btnTabView.Click += new EventHandler(this.btnTabView_Click);

            this.btnTabSettings = new Button();
            this.btnTabSettings.Text = "Налаштування";
            this.btnTabSettings.Size = new System.Drawing.Size(140, 36);
            this.btnTabSettings.Location = new System.Drawing.Point(320, 16);
            this.btnTabSettings.FlatStyle = FlatStyle.Flat;
            this.btnTabSettings.FlatAppearance.BorderSize = 0;
            this.btnTabSettings.ForeColor = System.Drawing.Color.White;
            this.btnTabSettings.Click += new EventHandler(this.btnTabSettings_Click);

            this.topPanel.Controls.Add(this.btnTabOrder);
            this.topPanel.Controls.Add(this.btnTabView);
            this.topPanel.Controls.Add(this.btnTabSettings);

            // ===============================
            // CONTENT PANEL
            // ===============================
            this.contentPanel = new Panel();
            this.contentPanel.Dock = DockStyle.Fill;
            this.contentPanel.Padding = new Padding(18);
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);

            // ===============================
            // PANEL ORDER
            // ===============================
            this.panelOrder = new Panel();
            this.panelOrder.Dock = DockStyle.Fill;
            this.panelOrder.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);

            // Заголовок
            this.lblOrderHeader = new Label();
            this.lblOrderHeader.Text = "Створити замовлення";
            this.lblOrderHeader.ForeColor = System.Drawing.Color.White;
            this.lblOrderHeader.AutoSize = true;
            this.lblOrderHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblOrderHeader.Location = new System.Drawing.Point(10, 6);

            // Обгортка плиток
            this.servicesWrap = new Panel();
            this.servicesWrap.Size = new System.Drawing.Size(560, 180);
            this.servicesWrap.Location = new System.Drawing.Point(14, 56);

            // ---- Taxi tile ----
            this.tileTaxi = new Panel();
            this.tileTaxi.Size = new System.Drawing.Size(260, 84);
            this.tileTaxi.Location = new System.Drawing.Point(0, 0);
            this.tileTaxi.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);

            this.labelTaxi = new Label();
            this.labelTaxi.Text = "🚕 Таксі";
            this.labelTaxi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTaxi.Dock = DockStyle.Fill;
            this.labelTaxi.ForeColor = System.Drawing.Color.White;
            this.labelTaxi.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.tileTaxi.Controls.Add(this.labelTaxi);

            // ---- Escort tile ----
            this.tileEscort = new Panel();
            this.tileEscort.Size = new System.Drawing.Size(260, 84);
            this.tileEscort.Location = new System.Drawing.Point(280, 0);
            this.tileEscort.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);

            this.labelEscort = new Label();
            this.labelEscort.Text = "💃 Ескорт";
            this.labelEscort.Dock = DockStyle.Fill;
            this.labelEscort.ForeColor = System.Drawing.Color.White;
            this.labelEscort.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.tileEscort.Controls.Add(this.labelEscort);

            // ---- Security tile ----
            this.tileSecurity = new Panel();
            this.tileSecurity.Size = new System.Drawing.Size(260, 84);
            this.tileSecurity.Location = new System.Drawing.Point(0, 96);
            this.tileSecurity.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);

            this.labelSecurity = new Label();
            this.labelSecurity.Text = "🛡️ Охорона";
            this.labelSecurity.Dock = DockStyle.Fill;
            this.labelSecurity.ForeColor = System.Drawing.Color.White;
            this.labelSecurity.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.tileSecurity.Controls.Add(this.labelSecurity);

            // ---- Delivery tile ----
            this.tileDelivery = new Panel();
            this.tileDelivery.Size = new System.Drawing.Size(260, 84);
            this.tileDelivery.Location = new System.Drawing.Point(280, 96);
            this.tileDelivery.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);

            this.labelDelivery = new Label();
            this.labelDelivery.Text = "📦 Доставка";
            this.labelDelivery.Dock = DockStyle.Fill;
            this.labelDelivery.ForeColor = System.Drawing.Color.White;
            this.labelDelivery.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.tileDelivery.Controls.Add(this.labelDelivery);

            // Додаємо плитки
            this.servicesWrap.Controls.Add(this.tileTaxi);
            this.servicesWrap.Controls.Add(this.tileEscort);
            this.servicesWrap.Controls.Add(this.tileSecurity);
            this.servicesWrap.Controls.Add(this.tileDelivery);

            this.lblHints = new Label();
            this.lblHints.Text = "Оберіть послугу та введіть ім'я";
            this.lblHints.AutoSize = true;
            this.lblHints.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.lblHints.Location = new System.Drawing.Point(600, 56);

            this.txtUserName = new TextBox();
            this.txtUserName.Location = new System.Drawing.Point(600, 80);
            this.txtUserName.Size = new System.Drawing.Size(260, 30);

            this.btnMakeOrder = new Button();
            this.btnMakeOrder.Text = "Замовити";
            this.btnMakeOrder.Size = new System.Drawing.Size(140, 42);
            this.btnMakeOrder.Location = new System.Drawing.Point(600, 130);
            this.btnMakeOrder.FlatStyle = FlatStyle.Flat;
            this.btnMakeOrder.Click += new EventHandler(this.btnMakeOrder_Click);

            this.panelOrder.Controls.Add(this.lblOrderHeader);
            this.panelOrder.Controls.Add(this.servicesWrap);
            this.panelOrder.Controls.Add(this.lblHints);
            this.panelOrder.Controls.Add(this.txtUserName);
            this.panelOrder.Controls.Add(this.btnMakeOrder);

            // ===============================
            // PANEL VIEW
            // ===============================
            this.panelView = new Panel();
            this.panelView.Dock = DockStyle.Fill;
            this.panelView.Visible = false;

            this.lblSearch = new Label();
            this.lblSearch.Text = "Пошук:";
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(24, 18);
            this.lblSearch.ForeColor = System.Drawing.Color.White;

            this.txtSearch = new TextBox();
            this.txtSearch.Location = new System.Drawing.Point(84, 14);
            this.txtSearch.Size = new System.Drawing.Size(280, 28);
            this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);

            this.btnClearAll = new Button();
            this.btnClearAll.Text = "Очистити все";
            this.btnClearAll.Location = new System.Drawing.Point(760, 12);
            this.btnClearAll.Size = new System.Drawing.Size(110, 32);
            this.btnClearAll.Click += new EventHandler(this.btnClearAll_Click);

            this.dataGridViewOrders = new DataGridView();
            this.dataGridViewOrders.Location = new System.Drawing.Point(24, 56);
            this.dataGridViewOrders.Size = new System.Drawing.Size(846, 480);
            this.dataGridViewOrders.ReadOnly = true;
            this.dataGridViewOrders.CellClick += new DataGridViewCellEventHandler(this.dataGridViewOrders_CellClick);

            this.btnExportPdf = new Button();
            this.btnExportPdf.Text = "Експорт PDF";
            this.btnExportPdf.Location = new System.Drawing.Point(360, 14);
            this.btnExportPdf.Size = new System.Drawing.Size(110, 30);
            this.btnExportPdf.Click += new EventHandler(this.btnExportPdf_Click);

            this.panelView.Controls.Add(this.lblSearch);
            this.panelView.Controls.Add(this.txtSearch);
            this.panelView.Controls.Add(this.btnClearAll);
            this.panelView.Controls.Add(this.dataGridViewOrders);
            this.panelView.Controls.Add(this.btnExportPdf);

            // ===============================
            // PANEL SETTINGS
            // ===============================
            this.panelSettings = new Panel();
            this.panelSettings.Dock = DockStyle.Fill;
            this.panelSettings.Visible = false;

            this.lblSettingsHeader = new Label();
            this.lblSettingsHeader.Text = "Налаштування";
            this.lblSettingsHeader.AutoSize = true;
            this.lblSettingsHeader.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblSettingsHeader.Location = new System.Drawing.Point(18, 10);

            this.chkDarkMode = new CheckBox();
            this.chkDarkMode.Text = "Темна тема";
            this.chkDarkMode.AutoSize = true;
            this.chkDarkMode.Location = new System.Drawing.Point(22, 56);

            this.btnSaveSettings = new Button();
            this.btnSaveSettings.Text = "Застосувати";
            this.btnSaveSettings.Size = new System.Drawing.Size(120, 36);
            this.btnSaveSettings.Location = new System.Drawing.Point(22, 92);
            this.btnSaveSettings.Click += new EventHandler(this.btnSaveSettings_Click);

            this.panelSettings.Controls.Add(this.lblSettingsHeader);
            this.panelSettings.Controls.Add(this.chkDarkMode);
            this.panelSettings.Controls.Add(this.btnSaveSettings);

            // ===============================
            // ADD PANELS TO FORM
            // ===============================
            this.contentPanel.Controls.Add(this.panelOrder);
            this.contentPanel.Controls.Add(this.panelView);
            this.contentPanel.Controls.Add(this.panelSettings);

            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.topPanel);

            this.ResumeLayout(false);
        }
    }
}
