using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public static class Database
    {
        private static readonly string dbFile = "app.db";
        private static readonly string connectionString = $"Data Source={dbFile};Version=3;";

        // === Ініціалізація бази ===
        public static void Init()
        {
            try
            {
                bool createDb = !File.Exists(dbFile);
                if (createDb)
                    SQLiteConnection.CreateFile(dbFile);

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // === Таблиця користувачів ===
                    string createUsers = @"CREATE TABLE IF NOT EXISTS Users (
                                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                            username TEXT NOT NULL UNIQUE,
                                            email TEXT NOT NULL UNIQUE,
                                            password TEXT NOT NULL,
                                            salt TEXT,
                                            role TEXT DEFAULT 'user'
                                         );";
                    new SQLiteCommand(createUsers, conn).ExecuteNonQuery();

                    // === Таблиця послуг ===
                    string createServices = @"CREATE TABLE IF NOT EXISTS Services (
                                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                name TEXT NOT NULL,
                                                description TEXT,
                                                price TEXT
                                            );";
                    new SQLiteCommand(createServices, conn).ExecuteNonQuery();

                    // === Якщо адмін ще не створений, додаємо ===
                    string checkAdmin = "SELECT COUNT(*) FROM Users WHERE role='admin'";
                    using (var cmd = new SQLiteCommand(checkAdmin, conn))
                    {
                        long count = (long)cmd.ExecuteScalar();
                        if (count == 0)
                        {
                            string salt = GenerateSalt();
                            string hash = HashPassword("admin123", salt);
                            string insertAdmin = "INSERT INTO Users (username, email, password, salt, role) VALUES ('admin', 'admin@local', @p, @s, 'admin')";
                            using (var add = new SQLiteCommand(insertAdmin, conn))
                            {
                                add.Parameters.AddWithValue("@p", hash);
                                add.Parameters.AddWithValue("@s", salt);
                                add.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка ініціалізації бази даних:\n" + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === Перевірка, чи існує користувач ===
        public static bool UserExists(string email)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Users WHERE email=@Email";
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
        // === Перевірка, чи існує користувач за username ===
        public static bool UsernameExists(string username)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    const string sql = "SELECT COUNT(1) FROM Users WHERE username=@Username";
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
                MessageBox.Show("Помилка перевірки username:\n" + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // === Додавання користувача ===
        public static bool AddUser(string username, string email, string passwordOrProvider, string role = "user")
        {
            try
            {
                if (UserExists(email))
                    return false;

                string salt = GenerateSalt();
                string hashedPassword = HashPassword(passwordOrProvider ?? Guid.NewGuid().ToString("N"), salt);

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"INSERT INTO Users (username, email, password, salt, role)
                                   VALUES (@u, @e, @p, @s, @r)";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@e", email);
                        cmd.Parameters.AddWithValue("@p", hashedPassword);
                        cmd.Parameters.AddWithValue("@s", salt);
                        cmd.Parameters.AddWithValue("@r", role);
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка додавання користувача:\n" + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // === Перевірка логіну ===
        public static bool ValidateUser(string email, string password, out string role)
        {
            role = "";
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT password, salt, role FROM Users WHERE email=@Email";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read()) return false;

                            string storedHash = reader.GetString(0);
                            string salt = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            role = reader.IsDBNull(2) ? "user" : reader.GetString(2);

                            string enteredHash = HashPassword(password, salt);
                            return storedHash == enteredHash;
                        }
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

        // === Отримання всіх послуг ===
        public static DataTable GetAllServices()
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (var adapter = new SQLiteDataAdapter("SELECT * FROM Services", conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка отримання послуг:\n" + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // === Додавання послуги ===
        public static void AddService(string name, string description, string price)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO Services (name, description, price) VALUES (@n, @d, @p)";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@d", description);
                        cmd.Parameters.AddWithValue("@p", price);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка додавання послуги:\n" + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === Оновлення послуги ===
        public static void UpdateService(int id, string name, string description, string price)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "UPDATE Services SET name=@n, description=@d, price=@p WHERE ID=@id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@d", description);
                        cmd.Parameters.AddWithValue("@p", price);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка оновлення послуги:\n" + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === Видалення послуги ===
        public static void DeleteService(int id)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Services WHERE ID=@id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка видалення послуги:\n" + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === Хешування паролів із сіллю ===
        public static string HashPassword(string password, string salt)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                StringBuilder sb = new StringBuilder();
                foreach (var b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // === Генерація солі ===
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
