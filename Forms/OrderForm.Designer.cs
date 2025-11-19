namespace Forms
{
    partial class OrderForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelTaxi;
        private System.Windows.Forms.Panel panelEscort;
        private System.Windows.Forms.Panel panelSecurity;
        private System.Windows.Forms.Panel panelDelivery;
        private System.Windows.Forms.Label labelTaxi;
        private System.Windows.Forms.Label labelEscort;
        private System.Windows.Forms.Label labelSecurity;
        private System.Windows.Forms.Label labelDelivery;
        private System.Windows.Forms.Button buttonOrder;
        private System.Windows.Forms.Button buttonShowOrders;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            panelTaxi = new Panel();
            labelTaxi = new Label();
            panelEscort = new Panel();
            labelEscort = new Label();
            panelSecurity = new Panel();
            labelSecurity = new Label();
            panelDelivery = new Panel();
            labelDelivery = new Label();
            buttonOrder = new Button();
            buttonShowOrders = new Button();
            flowLayoutPanel1.SuspendLayout();
            panelTaxi.SuspendLayout();
            panelEscort.SuspendLayout();
            panelSecurity.SuspendLayout();
            panelDelivery.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(30, 30, 30);
            flowLayoutPanel1.Controls.Add(panelTaxi);
            flowLayoutPanel1.Controls.Add(panelEscort);
            flowLayoutPanel1.Controls.Add(panelSecurity);
            flowLayoutPanel1.Controls.Add(panelDelivery);
            flowLayoutPanel1.Location = new Point(30, 30);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(440, 200);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panelTaxi
            // 
            panelTaxi.BackColor = Color.FromArgb(37, 37, 38);
            panelTaxi.Controls.Add(labelTaxi);
            panelTaxi.Location = new Point(10, 10);
            panelTaxi.Margin = new Padding(10);
            panelTaxi.Name = "panelTaxi";
            panelTaxi.Size = new Size(200, 80);
            panelTaxi.TabIndex = 0;
            // 
            // labelTaxi
            // 
            labelTaxi.Dock = DockStyle.Fill;
            labelTaxi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelTaxi.ForeColor = Color.White;
            labelTaxi.Location = new Point(0, 0);
            labelTaxi.Name = "labelTaxi";
            labelTaxi.Size = new Size(200, 80);
            labelTaxi.TabIndex = 0;
            labelTaxi.Text = "🚕 Таксі";
            labelTaxi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelEscort
            // 
            panelEscort.BackColor = Color.FromArgb(37, 37, 38);
            panelEscort.Controls.Add(labelEscort);
            panelEscort.Location = new Point(230, 10);
            panelEscort.Margin = new Padding(10);
            panelEscort.Name = "panelEscort";
            panelEscort.Size = new Size(200, 80);
            panelEscort.TabIndex = 1;
            // 
            // labelEscort
            // 
            labelEscort.Dock = DockStyle.Fill;
            labelEscort.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelEscort.ForeColor = Color.White;
            labelEscort.Location = new Point(0, 0);
            labelEscort.Name = "labelEscort";
            labelEscort.Size = new Size(200, 80);
            labelEscort.TabIndex = 0;
            labelEscort.Text = "💃 Ескорт";
            labelEscort.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelSecurity
            // 
            panelSecurity.BackColor = Color.FromArgb(37, 37, 38);
            panelSecurity.Controls.Add(labelSecurity);
            panelSecurity.Location = new Point(10, 110);
            panelSecurity.Margin = new Padding(10);
            panelSecurity.Name = "panelSecurity";
            panelSecurity.Size = new Size(200, 80);
            panelSecurity.TabIndex = 2;
            // 
            // labelSecurity
            // 
            labelSecurity.Dock = DockStyle.Fill;
            labelSecurity.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelSecurity.ForeColor = Color.White;
            labelSecurity.Location = new Point(0, 0);
            labelSecurity.Name = "labelSecurity";
            labelSecurity.Size = new Size(200, 80);
            labelSecurity.TabIndex = 0;
            labelSecurity.Text = "🛡️ Охорона";
            labelSecurity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelDelivery
            // 
            panelDelivery.BackColor = Color.FromArgb(37, 37, 38);
            panelDelivery.Controls.Add(labelDelivery);
            panelDelivery.Location = new Point(230, 110);
            panelDelivery.Margin = new Padding(10);
            panelDelivery.Name = "panelDelivery";
            panelDelivery.Size = new Size(200, 80);
            panelDelivery.TabIndex = 3;
            // 
            // labelDelivery
            // 
            labelDelivery.Dock = DockStyle.Fill;
            labelDelivery.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelDelivery.ForeColor = Color.White;
            labelDelivery.Location = new Point(0, 0);
            labelDelivery.Name = "labelDelivery";
            labelDelivery.Size = new Size(200, 80);
            labelDelivery.TabIndex = 0;
            labelDelivery.Text = "📦 Доставка";
            labelDelivery.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonOrder
            // 
            buttonOrder.BackColor = Color.FromArgb(0, 122, 204);
            buttonOrder.FlatAppearance.BorderSize = 0;
            buttonOrder.FlatStyle = FlatStyle.Flat;
            buttonOrder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonOrder.ForeColor = Color.White;
            buttonOrder.Location = new Point(30, 250);
            buttonOrder.Name = "buttonOrder";
            buttonOrder.Size = new Size(200, 40);
            buttonOrder.TabIndex = 1;
            buttonOrder.Text = "Замовити";
            buttonOrder.UseVisualStyleBackColor = false;
            buttonOrder.Click += buttonOrder_Click;
            // 
            // buttonShowOrders
            // 
            buttonShowOrders.BackColor = Color.FromArgb(37, 37, 38);
            buttonShowOrders.FlatAppearance.BorderSize = 0;
            buttonShowOrders.FlatStyle = FlatStyle.Flat;
            buttonShowOrders.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonShowOrders.ForeColor = Color.White;
            buttonShowOrders.Location = new Point(250, 250);
            buttonShowOrders.Name = "buttonShowOrders";
            buttonShowOrders.Size = new Size(220, 40);
            buttonShowOrders.TabIndex = 2;
            buttonShowOrders.Text = "Переглянути замовлення";
            buttonShowOrders.UseVisualStyleBackColor = false;
            buttonShowOrders.Click += buttonShowOrders_Click;
            // 
            // OrderForm
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(517, 318);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(buttonOrder);
            Controls.Add(buttonShowOrders);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "OrderForm";
            Text = "Замовлення послуг";
            flowLayoutPanel1.ResumeLayout(false);
            panelTaxi.ResumeLayout(false);
            panelEscort.ResumeLayout(false);
            panelSecurity.ResumeLayout(false);
            panelDelivery.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
