using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace WinFormsApp2.PayLogic
{
    public class OrderCalculator
    {
        private Dictionary<string, decimal> servicePrices;

        public OrderCalculator()
        {
            LoadPricesFromDatabase();
        }

        // ===============================
        //  ЗАВАНТАЖЕННЯ ДАНИХ З SQLite
        // ===============================
        private void LoadPricesFromDatabase()
        {
            servicePrices = new Dictionary<string, decimal>();

            try
            {
                using (var conn = new SQLiteConnection("Data Source=app.db;Version=3;"))
                {
                    conn.Open();

                    string sql = "SELECT name, price FROM Services";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["name"]?.ToString() ?? "";
                            string priceStr = reader["price"]?.ToString() ?? "0";

                            if (decimal.TryParse(priceStr, out decimal price))
                                servicePrices[name] = price;
                            else
                                servicePrices[name] = 0m;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Не вдалося завантажити ціни: " + ex.Message);
            }
        }

        // ===============================
        //  ОТРИМАТИ ЦІНУ ПОСЛУГИ
        // ===============================
        public decimal GetPrice(string serviceName)
        {
            if (servicePrices.TryGetValue(serviceName, out decimal price))
                return price;

            return 0m;
        }

        // ===============================
        //  ПІДРАХУНОК ЗАГАЛЬНОЇ СУМИ
        // ===============================
        public decimal CalculateTotal(IEnumerable<string> selectedServices)
        {
            if (selectedServices == null)
                return 0m;

            return selectedServices.Sum(s => GetPrice(s));
        }

        // ===============================
        //  ОТРИМАТИ ВСІ ПОСЛУГИ
        // ===============================
        public IReadOnlyDictionary<string, decimal> GetAllServices()
        {
            return servicePrices;
        }
    }
}