using System.Data.SQLite;
using System.Data;
using System.Security.Cryptography;
using System.Text;


namespace DatabaseLibrary
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
                    string createServices = @"
    PRAGMA foreign_keys=off;

    BEGIN TRANSACTION;

    CREATE TABLE IF NOT EXISTS Services_new (
        ID INTEGER PRIMARY KEY AUTOINCREMENT,
        name TEXT NOT NULL,
        price TEXT
    );

    INSERT INTO Services_new (ID, name, price)
        SELECT ID, name, price FROM Services;

    DROP TABLE Services;

    ALTER TABLE Services_new RENAME TO Services;

    COMMIT;

    PRAGMA foreign_keys=on;
";
                    new SQLiteCommand(createServices, conn).ExecuteNonQuery();

                    // === Якщо адмін ще не створений — створюємо ===
                    string checkAdmin = "SELECT COUNT(*) FROM Users WHERE role='admin'";
                    using (var cmd = new SQLiteCommand(checkAdmin, conn))
                    {
                        long count = (long)cmd.ExecuteScalar();
                        if (count == 0)
                        {
                            string salt = GenerateSalt();
                            string hash = HashPassword("admin123", salt);

                            string insertAdmin = @"INSERT INTO Users 
                                (username, email, password, salt, role) 
                                VALUES ('admin', 'admin@local', @p, @s, 'admin')";

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
                throw new Exception("Помилка ініціалізації БД: " + ex.Message);
            }
        }

        // === Перевірка email ===
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
                throw new Exception("Помилка перевірки користувача: " + ex.Message);
            }
        }

        // === Перевірка username ===
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
                throw new Exception("Помилка перевірки username: " + ex.Message);
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
                throw new Exception("Помилка додавання користувача: " + ex.Message);
            }
        }

        // === Валідація користувача ===
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
                throw new Exception("Помилка перевірки логіну: " + ex.Message);
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
                throw new Exception("Помилка отримання списку послуг: " + ex.Message);
            }
        }

        // === Додавання послуги ===
        public static void AddService(string name, string price)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO Services (name, price) VALUES (@n, @p)";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@p", price);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка додавання послуги: " + ex.Message);
            }
        }

        // === Оновлення послуги ===
        public static void UpdateService(int id, string name, string price)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "UPDATE Services SET name=@n, price=@p WHERE ID=@id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@p", price);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка оновлення послуги: " + ex.Message);
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
                throw new Exception("Помилка видалення послуги: " + ex.Message);
            }
        }

        // === Отримати всіх користувачів ===
        public static DataTable GetAllUsers()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var adapter = new SQLiteDataAdapter("SELECT ID, username, email, role FROM Users", conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // === Оновити користувача ===
        public static void UpdateUser(string id, string username, string email, string password, string role)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql;

                // Якщо пароль не змінюється
                if (string.IsNullOrWhiteSpace(password))
                {
                    sql = "UPDATE Users SET username=@u, email=@e, role=@r WHERE ID=@id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@e", email);
                        cmd.Parameters.AddWithValue("@r", role);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Якщо змінюється пароль
                    string salt = GenerateSalt();
                    string hash = HashPassword(password, salt);

                    sql = "UPDATE Users SET username=@u, email=@e, password=@p, salt=@s, role=@r WHERE ID=@id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@e", email);
                        cmd.Parameters.AddWithValue("@p", hash);
                        cmd.Parameters.AddWithValue("@s", salt);
                        cmd.Parameters.AddWithValue("@r", role);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // === Видалити користувача ===
        public static void DeleteUser(string id)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Users WHERE ID=@id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // === Хешування пароля ===
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