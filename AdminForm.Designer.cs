using System.Windows.Forms;

namespace WinFormsApp2
{
    partial class AdminForm
    {
        private DataGridView dataGridViewServices;
        private Label labelName;
        private Label labelDescription;
        private Label labelPrice;
        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private TextBox textBoxPrice;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonRefresh;

        private void InitializeComponent()
        {
            dataGridViewServices = new DataGridView();
            labelName = new Label();
            labelDescription = new Label();
            labelPrice = new Label();
            textBoxName = new TextBox();
            textBoxDescription = new TextBox();
            textBoxPrice = new TextBox();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewServices
            // 
            dataGridViewServices.AllowUserToAddRows = false;
            dataGridViewServices.ColumnHeadersHeight = 29;
            dataGridViewServices.Location = new Point(20, 20);
            dataGridViewServices.MultiSelect = false;
            dataGridViewServices.Name = "dataGridViewServices";
            dataGridViewServices.ReadOnly = true;
            dataGridViewServices.RowHeadersWidth = 51;
            dataGridViewServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewServices.Size = new Size(480, 250);
            dataGridViewServices.TabIndex = 0;
            dataGridViewServices.SelectionChanged += dataGridViewServices_SelectionChanged;
            // 
            // labelName
            // 
            labelName.Location = new Point(506, 20);
            labelName.Name = "labelName";
            labelName.Size = new Size(78, 23);
            labelName.TabIndex = 1;
            labelName.Text = "Назва:";
            // 
            // labelDescription
            // 
            labelDescription.Location = new Point(506, 70);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(64, 23);
            labelDescription.TabIndex = 3;
            labelDescription.Text = "Опис:";
            // 
            // labelPrice
            // 
            labelPrice.Location = new Point(506, 185);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(64, 23);
            labelPrice.TabIndex = 5;
            labelPrice.Text = "Ціна:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(590, 25);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(180, 27);
            textBoxName.TabIndex = 2;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(590, 70);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(180, 100);
            textBoxDescription.TabIndex = 4;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(590, 185);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(100, 27);
            textBoxPrice.TabIndex = 6;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(520, 230);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(80, 35);
            buttonAdd.TabIndex = 7;
            buttonAdd.Text = "➕ Додати";
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(610, 230);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(100, 35);
            buttonEdit.TabIndex = 8;
            buttonEdit.Text = "✏️ Редагувати";
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(720, 230);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(90, 35);
            buttonDelete.TabIndex = 9;
            buttonDelete.Text = "❌ Видалити";
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(20, 280);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(480, 35);
            buttonRefresh.TabIndex = 10;
            buttonRefresh.Text = "🔄 Оновити";
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // AdminForm
            // 
            ClientSize = new Size(830, 340);
            Controls.Add(dataGridViewServices);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            Controls.Add(labelDescription);
            Controls.Add(textBoxDescription);
            Controls.Add(labelPrice);
            Controls.Add(textBoxPrice);
            Controls.Add(buttonAdd);
            Controls.Add(buttonEdit);
            Controls.Add(buttonDelete);
            Controls.Add(buttonRefresh);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Панель адміністратора — Керування послугами";
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}