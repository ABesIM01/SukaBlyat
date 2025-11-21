using System.Drawing;
using System.Windows.Forms;

namespace Forms
{
    partial class StartAdminPanelForm
    {
        private Label labelTitle;
        private Button btnServices;
        private Button btnUsers;
        private Button btnTelephonia;

        private void InitializeComponent()
        {
            this.BackColor = Color.FromArgb(20, 20, 20);
            this.ClientSize = new Size(600, 420);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Адмін-панель";
            this.Font = new Font("Segoe UI", 11F);

            // ===== TITLE =====
            labelTitle = new Label
            {
                Text = "Панель адміністратора",
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 20F),
                AutoSize = true,
                Location = new Point(130, 30)
            };
            this.Controls.Add(labelTitle);

            // ===== BUTTON: SERVICES =====
            btnServices = new Button
            {
                Text = "🛠 Керування послугами",
                Location = new Point(100, 100),
                Size = new Size(400, 60),
                BackColor = Color.FromArgb(35, 35, 35),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 12F),
            };
            btnServices.FlatAppearance.BorderSize = 0;

            btnServices.MouseEnter += (s, e) => btnServices.BackColor = Color.FromArgb(55, 55, 55);
            btnServices.MouseLeave += (s, e) => btnServices.BackColor = Color.FromArgb(35, 35, 35);

            // >>> ADD CLICK EVENT <<<
            btnServices.Click += btnServices_Click;


            // ===== BUTTON: USERS =====
            btnUsers = new Button
            {
                Text = "👤 Керування користувачами",
                Location = new Point(100, 180),
                Size = new Size(400, 60),
                BackColor = Color.FromArgb(35, 35, 35),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 12F),
            };
            btnUsers.FlatAppearance.BorderSize = 0;

            btnUsers.MouseEnter += (s, e) => btnUsers.BackColor = Color.FromArgb(55, 55, 55);
            btnUsers.MouseLeave += (s, e) => btnUsers.BackColor = Color.FromArgb(35, 35, 35);

            // >>> ADD CLICK EVENT <<<
            btnUsers.Click += btnUsers_Click;


            // ===== BUTTON: TELEPHONIA =====
            btnTelephonia = new Button
            {
                Text = "📞 Менеджер дзвінків",
                Location = new Point(100, 260),
                Size = new Size(400, 60),
                BackColor = Color.FromArgb(35, 35, 35),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 12F),
            };
            btnTelephonia.FlatAppearance.BorderSize = 0;

            btnTelephonia.MouseEnter += (s, e) => btnTelephonia.BackColor = Color.FromArgb(55, 55, 55);
            btnTelephonia.MouseLeave += (s, e) => btnTelephonia.BackColor = Color.FromArgb(35, 35, 35);

            // >>> ADD CLICK EVENT <<<
            btnTelephonia.Click += btnTelephonia_Click;


            // Add controls
            this.Controls.Add(btnServices);
            this.Controls.Add(btnUsers);
            this.Controls.Add(btnTelephonia);
        }
    }
}