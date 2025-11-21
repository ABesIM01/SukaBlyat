namespace Forms
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTaxi;
        private System.Windows.Forms.Panel panelEscort;
        private System.Windows.Forms.Panel panelSecurity;
        private System.Windows.Forms.Panel panelDelivery;
        private System.Windows.Forms.Button buttonOrder;
        private System.Windows.Forms.Button buttonShowOrders;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTaxi = new System.Windows.Forms.Panel();
            this.panelEscort = new System.Windows.Forms.Panel();
            this.panelSecurity = new System.Windows.Forms.Panel();
            this.panelDelivery = new System.Windows.Forms.Panel();
            this.buttonOrder = new System.Windows.Forms.Button();
            this.buttonShowOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelTaxi
            // 
            this.panelTaxi.Location = new System.Drawing.Point(20, 20);
            this.panelTaxi.Size = new System.Drawing.Size(150, 50);
            this.panelTaxi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // panelEscort
            // 
            this.panelEscort.Location = new System.Drawing.Point(20, 80);
            this.panelEscort.Size = new System.Drawing.Size(150, 50);
            this.panelEscort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // panelSecurity
            // 
            this.panelSecurity.Location = new System.Drawing.Point(20, 140);
            this.panelSecurity.Size = new System.Drawing.Size(150, 50);
            this.panelSecurity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // panelDelivery
            // 
            this.panelDelivery.Location = new System.Drawing.Point(20, 200);
            this.panelDelivery.Size = new System.Drawing.Size(150, 50);
            this.panelDelivery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // buttonOrder
            // 
            this.buttonOrder.Location = new System.Drawing.Point(200, 20);
            this.buttonOrder.Size = new System.Drawing.Size(150, 50);
            this.buttonOrder.Text = "Замовити";
            this.buttonOrder.Click += new System.EventHandler(this.buttonOrder_Click);
            // 
            // buttonShowOrders
            // 
            this.buttonShowOrders.Location = new System.Drawing.Point(200, 80);
            this.buttonShowOrders.Size = new System.Drawing.Size(150, 50);
            this.buttonShowOrders.Text = "Переглянути замовлення";
            this.buttonShowOrders.Click += new System.EventHandler(this.buttonShowOrders_Click);
            // 
            // OrderForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.panelTaxi);
            this.Controls.Add(this.panelEscort);
            this.Controls.Add(this.panelSecurity);
            this.Controls.Add(this.panelDelivery);
            this.Controls.Add(this.buttonOrder);
            this.Controls.Add(this.buttonShowOrders);
            this.Text = "OrderForm";
            this.ResumeLayout(false);
        }
    }
}
