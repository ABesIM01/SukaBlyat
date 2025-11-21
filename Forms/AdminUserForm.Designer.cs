namespace Forms
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
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewUsers = new DataGridView();
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            labelRole = new Label();
            comboRole = new ComboBox();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.ColumnHeadersHeight = 29;
            dataGridViewUsers.Location = new Point(12, 12);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.Size = new Size(560, 500);
            dataGridViewUsers.TabIndex = 0;
            dataGridViewUsers.SelectionChanged += dataGridViewUsers_SelectionChanged;
            // 
            // labelUsername
            // 
            labelUsername.Location = new Point(590, 12);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(100, 23);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Логін:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(590, 40);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(220, 27);
            textBoxUsername.TabIndex = 2;
            // 
            // labelEmail
            // 
            labelEmail.Location = new Point(590, 70);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(100, 23);
            labelEmail.TabIndex = 3;
            labelEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(590, 100);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(220, 27);
            textBoxEmail.TabIndex = 4;
            // 
            // labelPassword
            // 
            labelPassword.Location = new Point(590, 130);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(100, 23);
            labelPassword.TabIndex = 5;
            labelPassword.Text = "Новий пароль:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(590, 160);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(220, 27);
            textBoxPassword.TabIndex = 6;
            // 
            // labelRole
            // 
            labelRole.Location = new Point(590, 190);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(100, 23);
            labelRole.TabIndex = 7;
            labelRole.Text = "Роль:";
            // 
            // comboRole
            // 
            comboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRole.Items.AddRange(new object[] { "admin", "user" });
            comboRole.Location = new Point(590, 220);
            comboRole.Name = "comboRole";
            comboRole.Size = new Size(220, 28);
            comboRole.TabIndex = 8;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(590, 270);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(90, 35);
            buttonAdd.TabIndex = 9;
            buttonAdd.Text = "Додати";
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(700, 270);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(110, 35);
            buttonEdit.TabIndex = 10;
            buttonEdit.Text = "Редагувати";
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(590, 315);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(90, 35);
            buttonDelete.TabIndex = 11;
            buttonDelete.Text = "Видалити";
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(700, 315);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(110, 35);
            buttonRefresh.TabIndex = 12;
            buttonRefresh.Text = "Оновити";
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // AdminUsersForm
            // 
            ClientSize = new Size(840, 540);
            Controls.Add(dataGridViewUsers);
            Controls.Add(labelUsername);
            Controls.Add(textBoxUsername);
            Controls.Add(labelEmail);
            Controls.Add(textBoxEmail);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(labelRole);
            Controls.Add(comboRole);
            Controls.Add(buttonAdd);
            Controls.Add(buttonEdit);
            Controls.Add(buttonDelete);
            Controls.Add(buttonRefresh);
            Name = "AdminUsersForm";
            Text = "Управління користувачами";
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
