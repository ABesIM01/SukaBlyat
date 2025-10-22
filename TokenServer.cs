using System;
using System.IO;
using System.Net;

namespace WinFormsApp2
{
    public static class TokenServer
    {
        public static void Start(Action<string> onTokenReceived)
        {
            var listener = new HttpListener();
            listener.Prefixes.Add("http://127.0.0.1:7000/token/");
            listener.Start();

            Console.WriteLine("Waiting for token...");

            var context = listener.GetContext();
            using (var reader = new StreamReader(context.Request.InputStream))
            {
                var body = reader.ReadToEnd();
                onTokenReceived?.Invoke(body);
            }

            context.Response.StatusCode = 200;
            listener.Stop();
        }
    }
}
