using System;
using System.Data.SQLite;
using System.IO;

namespace WinFormsApp2
{
    public static class DatabaseHelper
    {
        private static readonly string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.db");
        private static readonly string connectionString = $"Data Source={dbPath};Version=3;";

        static DatabaseHelper()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"CREATE TABLE users (
                                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    username TEXT UNIQUE,
                                    password TEXT
                                   );";
                    new SQLiteCommand(sql, conn).ExecuteNonQuery();
                }
            }
        }

        public static bool RegisterUser(string username, string password)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO users (username, password) VALUES (@u, @p)";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch
            {
                return false; // логін вже існує
            }
        }

        public static bool ValidateUser(string username, string password)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM users WHERE username=@u AND password=@p";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
