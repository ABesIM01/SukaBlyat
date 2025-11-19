using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Forms
{
    public static class TelegramHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task SendMessageAsync(string botToken, string chatId, string message)
        {
            try
            {
                string url = $"https://api.telegram.org/bot{botToken}/sendMessage?chat_id={chatId}&text={Uri.EscapeDataString(message)}";
                await client.GetAsync(url);
            }
            catch
            {
                // ТИХИЙ режим — ніяких MessageBox
                // Можна записати лог у файл, якщо треба
                // File.AppendAllText("tg_errors.log", ex.ToString());
            }
        }
    }
}