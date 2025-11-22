using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DatabaseLibrary
{
    public static class Database
    {
        // DB file next to executable to avoid unexpected working directory issues
        private static readonly string dbFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.db");
        private static readonly string connectionString = $"Data Source={dbFile};Version=3;";

        // === Ініціалізація бази ===
        public static void Init()
        {
            try
            {
                bool createDb = !File.Exists(dbFile);
                if (createDb)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(dbFile) ?? AppDomain.CurrentDomain.BaseDirectory);
                    SQLiteConnection.CreateFile(dbFile);
                }

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    EnableForeignKeys(conn);

                    // Users table
                    const string createUsers = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            username TEXT NOT NULL UNIQUE,
                            email TEXT NOT NULL UNIQUE,
                            password TEXT NOT NULL,
                            salt TEXT,
                            role TEXT DEFAULT 'user'
                        );";
                    ExecuteNonQuery(conn, createUsers);

                    // Services table: create if not exists (price as REAL)
                    if (!TableExists(conn, "Services"))
                    {
                        const string createServices = @"
                            CREATE TABLE IF NOT EXISTS Services (
                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                name TEXT NOT NULL,
                                price REAL
                            );";
                        ExecuteNonQuery(conn, createServices);
                    }

                    // Ensure admin exists
                    const string checkAdmin = "SELECT COUNT(*) FROM Users WHERE role='admin';";
                    using (var cmd = new SQLiteCommand(checkAdmin, conn))
                    {
                        long count = (long)cmd.ExecuteScalar();
                        if (count == 0)
                        {
                            string salt = GenerateSalt();
                            string hash = HashPassword("admin123", salt);

                            const string insertAdmin = @"
                                INSERT INTO Users (username, email, password, salt, role)
                                VALUES ('admin', 'admin@local', @p, @s, 'admin');";
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
                // keep full info for logs/debug
                throw new Exception("Помилка ініціалізації БД: " + ex.ToString());
            }
        }

        // === HELPERS ===

        private static void EnableForeignKeys(SQLiteConnection conn)
        {
            using var cmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", conn);
            cmd.ExecuteNonQuery();
        }

        private static void ExecuteNonQuery(SQLiteConnection conn, string sql)
        {
            using var cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        private static bool TableExists(SQLiteConnection conn, string tableName)
        {
            const string sql = "SELECT name FROM sqlite_master WHERE type='table' AND name=@name;";
            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", tableName);
            var res = cmd.ExecuteScalar();
            return res != null && res != DBNull.Value;
        }

        // === USERS ===

        public static bool UserExists(string email)
        {
            try
            {
                using var conn = new SQLiteConnection(connectionString);
                conn.Open();
                const string sql = "SELECT COUNT(*) FROM Users WHERE email=@Email;";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                return (long)cmd.ExecuteScalar() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка перевірки користувача: " + ex.ToString());
            }
        }

        public static bool UsernameExists(string username)
        {
            try
            {
                using var conn = new SQLiteConnection(connectionString);
                conn.Open();
                const string sql = "SELECT COUNT(1) FROM Users WHERE username=@Username;";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                return (long)cmd.ExecuteScalar() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка перевірки username: " + ex.ToString());
            }
        }

        public static bool AddUser(string username, string email, string passwordOrProvider, string role = "user")
        {
            try
            {
                if (UserExists(email) || UsernameExists(username))
                    return false;

                string salt = GenerateSalt();
                string hashedPassword = HashPassword(passwordOrProvider ?? Guid.NewGuid().ToString("N"), salt);

                using var conn = new SQLiteConnection(connectionString);
                conn.Open();
                const string sql = @"INSERT INTO Users (username, email, password, salt, role)
                                     VALUES (@u, @e, @p, @s, @r);";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@p", hashedPassword);
                cmd.Parameters.AddWithValue("@s", salt);
                cmd.Parameters.AddWithValue("@r", role);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка додавання користувача: " + ex.ToString());
            }
        }

        public static bool ValidateUser(string email, string password, out string role)
        {
            role = "";
            try
            {
                using var conn = new SQLiteConnection(connectionString);
                conn.Open();
                const string sql = "SELECT password, salt, role FROM Users WHERE email=@Email;";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return false;

                string storedHash = reader.IsDBNull(0) ? "" : reader.GetString(0);
                string salt = reader.IsDBNull(1) ? "" : reader.GetString(1);
                role = reader.IsDBNull(2) ? "user" : reader.GetString(2);

                string enteredHash = HashPassword(password, salt);
                return storedHash == enteredHash;
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка перевірки логіну: " + ex.ToString());
            }
        }

        public static DataTable GetAllUsers()
        {
            using var conn = new SQLiteConnection(connectionString);
            conn.Open();
            using var adapter = new SQLiteDataAdapter("SELECT ID, username, email, role FROM Users;", conn);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static void UpdateUser(string id, string username, string email, string password, string role)
        {
            try
            {
                if (!int.TryParse(id, out int parsedId))
                    throw new ArgumentException("Invalid ID format", nameof(id));

                using var conn = new SQLiteConnection(connectionString);
                conn.Open();

                if (string.IsNullOrWhiteSpace(password))
                {
                    const string sql = "UPDATE Users SET username=@u, email=@e, role=@r WHERE ID=@id;";
                    using var cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@e", email);
                    cmd.Parameters.AddWithValue("@r", role);
                    cmd.Parameters.AddWithValue("@id", parsedId);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string salt = GenerateSalt();
                    string hash = HashPassword(password, salt);
                    const string sql = "UPDATE Users SET username=@u, email=@e, password=@p, salt=@s, role=@r WHERE ID=@id;";
                    using var cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@e", email);
                    cmd.Parameters.AddWithValue("@p", hash);
                    cmd.Parameters.AddWithValue("@s", salt);
                    cmd.Parameters.AddWithValue("@r", role);
                    cmd.Parameters.AddWithValue("@id", parsedId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка оновлення користувача: " + ex.ToString());
            }
        }

        public static void DeleteUser(string id)
        {
            try
            {
                if (!int.TryParse(id, out int parsedId))
                    throw new ArgumentException("Invalid ID format", nameof(id));

                using var conn = new SQLiteConnection(connectionString);
                conn.Open();
                const string sql = "DELETE FROM Users WHERE ID=@id;";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", parsedId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка видалення користувача: " + ex.ToString());
            }
        }

        // === SERVICES ===

        public static DataTable GetAllServices()
        {
            try
            {
                using var conn = new SQLiteConnection(connectionString);
                conn.Open();
                using var adapter = new SQLiteDataAdapter("SELECT ID, name, price FROM Services;", conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка отримання списку послуг: " + ex.ToString());
            }
        }

        // Accept numeric price (recommended)
        public static void AddService(string name, decimal? price)
        {
            try
            {
                using var conn = new SQLiteConnection(connectionString);
                conn.Open();
                const string sql = "INSERT INTO Services (name, price) VALUES (@n, @p);";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@n", name);
                if (price.HasValue)
                    cmd.Parameters.AddWithValue("@p", price.Value);
                else
                    cmd.Parameters.AddWithValue("@p", DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка додавання послуги: " + ex.ToString());
            }
        }

        // Overload: accept UI string and try to parse (safe)
        public static void AddService(string name, string priceText)
        {
            decimal? price = ParseNullableDecimal(priceText);
            AddService(name, price);
        }

        public static void UpdateService(int id, string name, decimal? price)
        {
            try
            {
                using var conn = new SQLiteConnection(connectionString);
                conn.Open();
                const string sql = "UPDATE Services SET name=@n, price=@p WHERE ID=@id;";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@n", name);
                if (price.HasValue)
                    cmd.Parameters.AddWithValue("@p", price.Value);
                else
                    cmd.Parameters.AddWithValue("@p", DBNull.Value);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка оновлення послуги: " + ex.ToString());
            }
        }

        // Overload for UI string input
        public static void UpdateService(int id, string name, string priceText)
        {
            decimal? price = ParseNullableDecimal(priceText);
            UpdateService(id, name, price);
        }

        public static void DeleteService(int id)
        {
            try
            {
                using var conn = new SQLiteConnection(connectionString);
                conn.Open();
                const string sql = "DELETE FROM Services WHERE ID=@id;";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка видалення послуги: " + ex.ToString());
            }
        }

        private static decimal? ParseNullableDecimal(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return null;
            if (decimal.TryParse(text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out decimal v))
                return v;
            // fallback: try invariant culture
            if (decimal.TryParse(text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out v))
                return v;
            return null; // if cannot parse, treat as NULL
        }

        // === PASSWORD HELPERS ===

        public static string HashPassword(string password, string salt)
        {
            using var sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            var sb = new StringBuilder();
            foreach (var b in bytes) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        private static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        // === ОБНОВЛЕННЯ ПАРОЛЯ ПО EMAIL ===
        // Додаємо у DatabaseLibrary.Database
        public static bool UpdatePasswordByEmail(string email, string newPassword)
        {
            try
            {
                using var conn = new SQLiteConnection(connectionString);
                conn.Open();

                // Генеруємо нову сіль та хеш
                string salt = GenerateSalt();
                string hashedPassword = HashPassword(newPassword, salt);

                const string sql = "UPDATE Users SET password=@Password, salt=@Salt WHERE email=@Email;";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                cmd.Parameters.AddWithValue("@Salt", salt);
                cmd.Parameters.AddWithValue("@Email", email);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; // повертає true якщо оновлено хоча б один рядок
            }
            catch
            {
                return false; // у разі помилки повертаємо false
            }
        }


    }
}
