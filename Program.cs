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
            // Встановлюємо сучасне відображення для Windows 10/11
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ініціалізація бази даних
            Database.Init();

            // Запуск форми входу
            Application.Run(new LoginForm());
        }
    }
}

