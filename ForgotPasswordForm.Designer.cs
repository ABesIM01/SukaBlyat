namespace WinFormsApp2
{
    partial class ForgotPasswordForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Button buttonRecover;
        private System.Windows.Forms.Button buttonCancel;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
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
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.buttonRecover = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // labelUsername
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(30, 30);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(70, 15);
            this.labelUsername.Text = "Username:";

            // textBoxUsername
            this.textBoxUsername.Location = new System.Drawing.Point(120, 27);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(180, 23);

            // buttonSearch
            this.buttonSearch.Location = new System.Drawing.Point(120, 60);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(180, 27);
            this.buttonSearch.Text = "Search";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);

            // labelQuestion
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Location = new System.Drawing.Point(30, 100);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(0, 15);

            // textBoxAnswer
            this.textBoxAnswer.Location = new System.Drawing.Point(30, 130);
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.Size = new System.Drawing.Size(270, 23);
            this.textBoxAnswer.Enabled = false;

            // buttonRecover
            this.buttonRecover.Location = new System.Drawing.Point(30, 170);
            this.buttonRecover.Name = "buttonRecover";
            this.buttonRecover.Size = new System.Drawing.Size(130, 27);
            this.buttonRecover.Text = "Recover Password";
            this.buttonRecover.Enabled = false;
            this.buttonRecover.Click += new System.EventHandler(this.buttonRecover_Click);

            // buttonCancel
            this.buttonCancel.Location = new System.Drawing.Point(170, 170);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(130, 27);
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);

            // ForgotPasswordForm
            this.ClientSize = new System.Drawing.Size(340, 230);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.textBoxAnswer);
            this.Controls.Add(this.buttonRecover);
            this.Controls.Add(this.buttonCancel);
            this.Name = "ForgotPasswordForm";
            this.Text = "Forgot Password";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

