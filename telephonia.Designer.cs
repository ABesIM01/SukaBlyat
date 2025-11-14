namespace Forms
{
    partial class Telephonia
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPhones = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.dtpCallDate = new System.Windows.Forms.DateTimePicker();
            this.btnUpdateNote = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoYes = new System.Windows.Forms.RadioButton();
            this.rdoNo = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CityCom = new System.Windows.Forms.ComboBox();
            this.btnFilterr = new System.Windows.Forms.Button();
            this.dtpEndDatee = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDatee = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhones)).BeginInit();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPhones
            // 
            this.dgvPhones.AllowUserToAddRows = false;
            this.dgvPhones.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPhones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhones.ColumnHeadersHeight = 29;
            this.dgvPhones.EnableHeadersVisualStyles = false;
            this.dgvPhones.GridColor = System.Drawing.Color.LightGray;
            this.dgvPhones.Location = new System.Drawing.Point(12, 58);
            this.dgvPhones.Name = "dgvPhones";
            this.dgvPhones.RowHeadersWidth = 51;
            this.dgvPhones.RowTemplate.Height = 40;
            this.dgvPhones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhones.Size = new System.Drawing.Size(1030, 564);
            this.dgvPhones.TabIndex = 0;
            this.dgvPhones.SelectionChanged += new System.EventHandler(this.dgvPhones_SelectionChanged);
            this.dgvPhones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhones_CellContentClick);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(402, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(180, 40);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Phone Numbers";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNotes.Location = new System.Drawing.Point(37, 267);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(260, 30);
            this.txtNotes.TabIndex = 2;
            // 
            // dtpCallDate
            // 
            this.dtpCallDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpCallDate.Location = new System.Drawing.Point(37, 427);
            this.dtpCallDate.Name = "dtpCallDate";
            this.dtpCallDate.Size = new System.Drawing.Size(260, 30);
            this.dtpCallDate.TabIndex = 4;
            this.dtpCallDate.ValueChanged += new System.EventHandler(this.dtpCallDate_ValueChanged);
            // 
            // btnUpdateNote
            // 
            this.btnUpdateNote.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnUpdateNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateNote.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdateNote.ForeColor = System.Drawing.Color.White;
            this.btnUpdateNote.Location = new System.Drawing.Point(78, 499);
            this.btnUpdateNote.Name = "btnUpdateNote";
            this.btnUpdateNote.Size = new System.Drawing.Size(200, 50);
            this.btnUpdateNote.TabIndex = 5;
            this.btnUpdateNote.Text = "Update";
            this.btnUpdateNote.UseVisualStyleBackColor = false;
            this.btnUpdateNote.Click += new System.EventHandler(this.btnUpdateNote_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(37, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Note:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(37, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Set Reminder:";
            // 
            // rdoYes
            // 
            this.rdoYes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdoYes.Location = new System.Drawing.Point(37, 347);
            this.rdoYes.Name = "rdoYes";
            this.rdoYes.Size = new System.Drawing.Size(55, 24);
            this.rdoYes.TabIndex = 4;
            this.rdoYes.TabStop = true;
            this.rdoYes.Text = "Yes";
            this.rdoYes.UseVisualStyleBackColor = true;
            // 
            // rdoNo
            // 
            this.rdoNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdoNo.Location = new System.Drawing.Point(117, 347);
            this.rdoNo.Name = "rdoNo";
            this.rdoNo.Size = new System.Drawing.Size(104, 24);
            this.rdoNo.TabIndex = 5;
            this.rdoNo.TabStop = true;
            this.rdoNo.Text = "No";
            this.rdoNo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(37, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Answered?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(37, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(324, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Select a row to edit its information:";
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rightPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightPanel.Controls.Add(this.label7);
            this.rightPanel.Controls.Add(this.label6);
            this.rightPanel.Controls.Add(this.label2);
            this.rightPanel.Controls.Add(this.CityCom);
            this.rightPanel.Controls.Add(this.btnFilterr);
            this.rightPanel.Controls.Add(this.dtpEndDatee);
            this.rightPanel.Controls.Add(this.dtpStartDatee);
            this.rightPanel.Controls.Add(this.label5);
            this.rightPanel.Controls.Add(this.label1);
            this.rightPanel.Controls.Add(this.txtNotes);
            this.rightPanel.Controls.Add(this.label4);
            this.rightPanel.Controls.Add(this.rdoYes);
            this.rightPanel.Controls.Add(this.rdoNo);
            this.rightPanel.Controls.Add(this.label3);
            this.rightPanel.Controls.Add(this.dtpCallDate);
            this.rightPanel.Controls.Add(this.btnUpdateNote);
            this.rightPanel.Location = new System.Drawing.Point(1059, 58);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(409, 564);
            this.rightPanel.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Gainsboro;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(12, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "select date to :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gainsboro;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(6, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "select date From :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(77, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Chose City :";
            // 
            // CityCom
            // 
            this.CityCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CityCom.FormattingEnabled = true;
            this.CityCom.Items.AddRange(new object[] {
            "Amman",
            "Zarqa",
            "Irbid",
            "Salt",
            "Aqaba",
            "Mafraq",
            "al-Balqa",
            "Jerash",
            "Ma'an",
            "Karak",
            "Ajloun",
            "Tafilah"});
            this.CityCom.Location = new System.Drawing.Point(177, 81);
            this.CityCom.Name = "CityCom";
            this.CityCom.Size = new System.Drawing.Size(120, 24);
            this.CityCom.TabIndex = 3;
            this.CityCom.SelectedIndexChanged += new System.EventHandler(this.CityCom_SelectedIndexChanged);
            // 
            // btnFilterr
            // 
            this.btnFilterr.Location = new System.Drawing.Point(117, 131);
            this.btnFilterr.Name = "btnFilterr";
            this.btnFilterr.Size = new System.Drawing.Size(126, 41);
            this.btnFilterr.TabIndex = 9;
            this.btnFilterr.Text = "Filter Answered";
            this.btnFilterr.UseVisualStyleBackColor = true;
            this.btnFilterr.Click += new System.EventHandler(this.btnFilterr_Click);
            // 
            // dtpEndDatee
            // 
            this.dtpEndDatee.Location = new System.Drawing.Point(142, 31);
            this.dtpEndDatee.Name = "dtpEndDatee";
            this.dtpEndDatee.Size = new System.Drawing.Size(256, 22);
            this.dtpEndDatee.TabIndex = 8;
            // 
            // dtpStartDatee
            // 
            this.dtpStartDatee.Location = new System.Drawing.Point(139, 3);
            this.dtpStartDatee.Name = "dtpStartDatee";
            this.dtpStartDatee.Size = new System.Drawing.Size(255, 22);
            this.dtpStartDatee.TabIndex = 7;
            // 
            // Telephonia
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1619, 738);
            this.Controls.Add(this.dgvPhones);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.rightPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Telephonia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phone Call Manager";
            this.Load += new System.EventHandler(this.Telephonia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhones)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhones;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.DateTimePicker dtpCallDate;
        private System.Windows.Forms.Button btnUpdateNote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdoYes;
        private System.Windows.Forms.RadioButton rdoNo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.DateTimePicker dtpEndDatee;
        private System.Windows.Forms.DateTimePicker dtpStartDatee;
        private System.Windows.Forms.Button btnFilterr;
        private System.Windows.Forms.ComboBox CityCom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}
