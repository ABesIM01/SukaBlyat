using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.PayLogic
{
    public class PaymentProcessor
    {
        private readonly string publicKey;
        private readonly string privateKey;

        public event EventHandler PaymentSuccess;
        public event EventHandler<string> PaymentFailure;

        public PaymentProcessor(string publicKey, string privateKey)
        {
            this.publicKey = publicKey;
            this.privateKey = privateKey;
        }

        public async Task<string> CreatePaymentAsync(decimal amount, string description)
        {
            try
            {
                string json = $"{{\"public_key\":\"{publicKey}\"," +
                              $"\"version\":\"3\"," +
                              $"\"action\":\"pay\"," +
                              $"\"amount\":\"{amount}\"," +
                              $"\"currency\":\"UAH\"," +
                              $"\"description\":\"{description}\"}}";

                string data = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
                string signature = CreateSignature(data);

                // валідний URL
                string payUrl = $"https://www.liqpay.ua/api/3/checkout?data={Uri.EscapeDataString(data)}&signature={Uri.EscapeDataString(signature)}";

                return payUrl;
            }
            catch (Exception ex)
            {
                PaymentFailure?.Invoke(this, ex.Message);
                throw;
            }
        }
        private string CreateSignature(string data)
        {
            // LiqPay підпис: SHA1(private_key + data + private_key) в Base64
            string toSign = privateKey + data + privateKey;

            using (var sha1 = SHA1.Create())
            {
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(toSign));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
