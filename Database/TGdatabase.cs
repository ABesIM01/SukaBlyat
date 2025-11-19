using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace DatabaseClass
{
    public static class TGdatabase
    {
        private static readonly string connectionString = "Data Source=orders.db";

        // Ініціалізація бази
        public static void Init()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Orders (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL,
                        ProductList TEXT NOT NULL,
                        OrderDate TEXT NOT NULL
                    );";

                using (var command = new SqliteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Додавання замовлення
        public static void AddOrder(string userName, string productList)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = @"
                    INSERT INTO Orders (UserName, ProductList, OrderDate)
                    VALUES (@UserName, @ProductList, @OrderDate);";

                using (var command = new SqliteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@ProductList", productList);
                    command.Parameters.AddWithValue("@OrderDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();
                }
            }
        }

        // Отримання всіх замовлень
        public static DataTable GetOrders()
        {
            var table = new DataTable();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string selectQuery = @"
                    SELECT 
                        Id AS 'ID',
                        UserName AS 'Користувач',
                        ProductList AS 'Послуги',
                        OrderDate AS 'Дата замовлення'
                    FROM Orders
                    ORDER BY Id DESC;";

                using (var command = new SqliteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            return table;
        }

        // Видалення окремого замовлення
        public static void DeleteOrder(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Orders WHERE Id = @Id;";
                using (var command = new SqliteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Очистити всі замовлення
        public static void ClearAllOrders()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string clearQuery = "DELETE FROM Orders;";
                using (var command = new SqliteCommand(clearQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
