using System;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public static class Database
    {
        private static readonly string dbFile = "users.db";
        private static readonly string connectionString = $"Data Source={dbFile};Version=3;";

        public static void Init()
        {
            try
            {
                bool createTable = !File.Exists(dbFile);

                if (createTable)
                    SQLiteConnection.CreateFile(dbFile);

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // === Створюємо таблицю, якщо її немає ===
                    string createSql = @"CREATE TABLE IF NOT EXISTS Users (
                                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                            username TEXT NOT NULL UNIQUE,
                                            email TEXT NOT NULL UNIQUE,
                                            password TEXT NOT NULL
                                        );";
                    using (var cmd = new SQLiteCommand(createSql, conn))
                        cmd.ExecuteNonQuery();

                    // === Перевіряємо, чи існує колонка 'salt' ===
                    bool saltExists = false;
                    using (var checkCmd = new SQLiteCommand("PRAGMA table_info(Users);", conn))
                    using (var reader = checkCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["name"].ToString().Equals("salt", StringComparison.OrdinalIgnoreCase))
                            {
                                saltExists = true;
                                break;
                            }
                        }
                    }

                    // === Якщо колонки 'salt' немає — додаємо ===
                    if (!saltExists)
                    {
                        using (var alterCmd = new SQLiteCommand("ALTER TABLE Users ADD COLUMN salt TEXT;", conn))
                            alterCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка ініціалізації бази даних:\n" + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool UserExists(string email)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(1) FROM Users WHERE email=@Email";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка перевірки користувача:\n" + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool UsernameExists(string username)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(1) FROM Users WHERE username=@Username";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка перевірки імені користувача:\n" + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool AddUser(string username, string email, string password)
        {
            try
            {
                if (UserExists(email) || UsernameExists(username))
                    return false;

                string salt = GenerateSalt();
                string hashedPassword = HashPassword(password, salt);

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO Users (username, email, password, salt) VALUES (@Username, @Email, @Password, @Salt)";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@Salt", salt);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка додавання користувача:\n" + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool ValidateUser(string email, string password)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT password, salt FROM Users WHERE email=@Email";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                return false;

                            string storedHash = reader.GetString(0);
                            string storedSalt = reader.IsDBNull(1) ? "" : reader.GetString(1);

                            string enteredHash = HashPassword(password, storedSalt);
                            return storedHash == enteredHash;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка перевірки пароля:\n" + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // === Хешування паролів із сіллю ===
        public static string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        // === Генерація випадкової солі ===
        private static string GenerateSalt()
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
