using System;
using System.Data.SQLite;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    public partial class ForgotPasswordForm : Form
    {
        private string connectionString = "Data Source=app.db;Version=3;";
        private string currentEmail = "";
        private string currentOTP = "";
        private DateTime otpExpiration;

        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        // ====== SEND OTP ======
        private void buttonSendOTP_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Будь ласка, введіть пошту.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT username FROM Users WHERE email=@Email";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        currentEmail = email;

                        // Генеруємо OTP
                        currentOTP = GenerateOTP();
                        otpExpiration = DateTime.Now.AddMinutes(5);

                        if (SendOTPEmail(email, currentOTP))
                        {
                            MessageBox.Show($"OTP-код надіслано на {email}. Перевірте пошту.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBoxOTP.Enabled = true;
                            textBoxNewPassword.Enabled = true;
                            buttonChangePassword.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Помилка відправки OTP. Спробуйте пізніше.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Користувача з такою поштою не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ====== CHANGE PASSWORD ======
        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            string enteredOTP = textBoxOTP.Text.Trim();
            string newPassword = textBoxNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(enteredOTP) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Введіть OTP та новий пароль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DateTime.Now > otpExpiration)
            {
                MessageBox.Show("Термін дії OTP закінчився.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (enteredOTP != currentOTP)
            {
                MessageBox.Show("Невірний OTP.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ===== Виклик методу з Database =====
            bool success = DatabaseLibrary.Database.UpdatePasswordByEmail(currentEmail, newPassword);

            if (success)
            {
                MessageBox.Show("Пароль успішно змінено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Помилка оновлення пароля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ====== OTP GENERATOR ======
        private string GenerateOTP()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[4];
                rng.GetBytes(bytes);
                int otpInt = BitConverter.ToInt32(bytes, 0);
                otpInt = Math.Abs(otpInt % 1000000);
                return otpInt.ToString("D6");
            }
        }

        // ====== SEND OTP EMAIL ======
        private bool SendOTPEmail(string toEmail, string otp)
        {
            try
            {
                var fromAddress = new MailAddress("mon24ukraine@gmail.com", "Escort Agency");
                var toAddress = new MailAddress(toEmail);
                const string fromPassword = "auep oqyt iein wumu";
                string subject = "Ваш OTP для відновлення пароля";
                string body = $"Ваш код для відновлення пароля: {otp}\nДійсний 5 хвилин.";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        // ====== HASH PASSWORD ======
        private string HashPassword(string password, string salt)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                StringBuilder sb = new StringBuilder();
                foreach (var b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // ====== GENERATE SALT ======
        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
    }
}
