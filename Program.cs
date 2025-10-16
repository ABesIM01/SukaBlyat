using System;
using System.Windows.Forms;
using WinFormsApp2;

namespace WinFormsApp2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // ������������ ������� ����������� ��� Windows 10/11
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ����������� ���� �����
            Database.Init();

            // ������ ����� �����
            Application.Run(new LoginForm());
        }
    }
}

