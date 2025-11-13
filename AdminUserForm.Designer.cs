namespace WinFormsApp2
{
    partial class AdminUsersForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.ComboBox comboRole;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRefresh;

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
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.comboRole = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();

            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewUsers.MultiSelect = false;
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new System.Drawing.Size(560, 300);

            this.dataGridViewUsers.SelectionChanged += new System.EventHandler(this.dataGridViewUsers_SelectionChanged);

            // 
            // labelUsername
            // 
            this.labelUsername.Text = "Логін:";
            this.labelUsername.Location = new System.Drawing.Point(590, 20);
            this.labelUsername.AutoSize = true;

            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(590, 40);
            this.textBoxUsername.Size = new System.Drawing.Size(200, 27);

            // 
            // labelEmail
            // 
            this.labelEmail.Text = "Email:";
            this.labelEmail.Location = new System.Drawing.Point(590, 80);
            this.labelEmail.AutoSize = true;

            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(590, 100);
            this.textBoxEmail.Size = new System.Drawing.Size(200, 27);

            // 
            // labelPassword
            // 
            this.labelPassword.Text = "Новий пароль:";
            this.labelPassword.Location = new System.Drawing.Point(590, 140);
            this.labelPassword.AutoSize = true;

            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(590, 160);
            this.textBoxPassword.Size = new System.Drawing.Size(200, 27);

            // 
            // labelRole
            // 
            this.labelRole.Text = "Роль:";
            this.labelRole.Location = new System.Drawing.Point(590, 200);
            this.labelRole.AutoSize = true;

            // 
            // comboRole
            // 
            this.comboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRole.Items.AddRange(new object[] {
                "admin",
                "user"
            });
            this.comboRole.Location = new System.Drawing.Point(590, 220);
            this.comboRole.Size = new System.Drawing.Size(200, 28);

            // 
            // buttonAdd
            // 
            this.buttonAdd.Text = "Додати";
            this.buttonAdd.Location = new System.Drawing.Point(590, 270);
            this.buttonAdd.Size = new System.Drawing.Size(90, 35);
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);

            // 
            // buttonEdit
            // 
            this.buttonEdit.Text = "Редагувати";
            this.buttonEdit.Location = new System.Drawing.Point(700, 270);
            this.buttonEdit.Size = new System.Drawing.Size(110, 35);
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);

            // 
            // buttonDelete
            // 
            this.buttonDelete.Text = "Видалити";
            this.buttonDelete.Location = new System.Drawing.Point(590, 315);
            this.buttonDelete.Size = new System.Drawing.Size(90, 35);
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);

            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Text = "Оновити";
            this.buttonRefresh.Location = new System.Drawing.Point(700, 315);
            this.buttonRefresh.Size = new System.Drawing.Size(110, 35);
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);

            // 
            // AdminUsersForm
            // 
            this.ClientSize = new System.Drawing.Size(820, 360);
            this.Controls.Add(this.dataGridViewUsers);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.comboRole);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonRefresh);
            this.Name = "AdminUsersForm";
            this.Text = "Управління користувачами";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
