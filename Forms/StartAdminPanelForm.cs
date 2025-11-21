using System;
using System.Windows.Forms;

namespace Forms
{
    public partial class StartAdminPanelForm : Form
    {
        public StartAdminPanelForm()
        {
            InitializeComponent();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            new AdminServiceForm().Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            new AdminUsersForm().Show();
        }

        private void btnTelephonia_Click(object sender, EventArgs e)
        {
            new Telephonia().Show();
        }
    }
}