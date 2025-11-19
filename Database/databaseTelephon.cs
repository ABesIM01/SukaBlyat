using System;
using System.Data;
using System.Data.SQLite;

namespace DatabaseClass
{
    public static class TelephoniaDatabase
    {
        private static string dbFile = "telephonia.db";
        private static string connectionString = $"Data Source={dbFile};Version=3;";

        public static void Init()
        {
            if (!System.IO.File.Exists(dbFile))
                SQLiteConnection.CreateFile(dbFile);

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                CREATE TABLE IF NOT EXISTS Telephonia (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FullName TEXT,
                    PhoneNumber TEXT,
                    Location TEXT,
                    Sub_Location TEXT,
                    Notes TEXT,
                    Answered TEXT,
                    CallDate DATE
                );
            ";
                new SQLiteCommand(sql, conn).ExecuteNonQuery();
            }
        }

        public static DataTable GetAll()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Telephonia", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void Update(int id, string notes, string answered, DateTime callDate)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    UPDATE Telephonia
                    SET Notes = @n,
                        Answered = @a,
                        CallDate = @d
                    WHERE Id = @id
                ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@n", notes);
                    cmd.Parameters.AddWithValue("@a", answered);
                    cmd.Parameters.AddWithValue("@d", callDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔥 МЕТОД ЯКОГО НЕ ВИСТАЧАЛО — Ось він!
        public static DataTable FilterAnswered(string city, DateTime start, DateTime end)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT *
                        FROM Telephonia
                        WHERE Answered = 'Yes'
                          AND CallDate >= @start
                          AND CallDate <= @end
                          AND (@city = '' OR Location = @city)
                    ";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@start", start);
                        cmd.Parameters.AddWithValue("@end", end);
                        cmd.Parameters.AddWithValue("@city", city ?? "");

                        SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка фільтрування: " + ex.Message);
            }
        }
    }
}