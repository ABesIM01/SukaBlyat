namespace WinFormsApp2
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();

            // dataGridViewServices
            this.dataGridViewServices.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewServices.Size = new System.Drawing.Size(500, 250);
            this.dataGridViewServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewServices.MultiSelect = false;

            // buttonRefresh
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.Location = new System.Drawing.Point(540, 20);
            this.buttonRefresh.Size = new System.Drawing.Size(100, 30);
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);

            // buttonAdd
            this.buttonAdd.Text = "Add";
            this.buttonAdd.Location = new System.Drawing.Point(540, 60);
            this.buttonAdd.Size = new System.Drawing.Size(100, 30);
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);

            // buttonEdit
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.Location = new System.Drawing.Point(540, 100);
            this.buttonEdit.Size = new System.Drawing.Size(100, 30);
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);

            // buttonDelete
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.Location = new System.Drawing.Point(540, 140);
            this.buttonDelete.Size = new System.Drawing.Size(100, 30);
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);

            // AdminForm
            this.ClientSize = new System.Drawing.Size(660, 300);
            this.Controls.Add(this.dataGridViewServices);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Text = "Admin Panel - Services";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }
    }
}