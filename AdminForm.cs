using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class AdminForm : Form
    {
        private string connectionString = "Data Source=services.db";

        public AdminForm()
        {
            InitializeComponent();
            SQLitePCL.Batteries.Init(); // <- обов'язково
            InitializeDatabase();
            LoadServices();
        }

        private void InitializeDatabase()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS Services (
                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                ServiceName TEXT NOT NULL,
                                Price REAL NOT NULL
                               );";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadServices()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ServiceName", typeof(string));
            dt.Columns.Add("Price", typeof(double));

            using (var conn = new Microsoft.Data.Sqlite.SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Services";
                using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dt.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2));
                    }
                }
            }

            dataGridViewServices.DataSource = dt;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = "New Service";
            double price = 100;

            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Services (ServiceName, Price) VALUES (@name, @price)";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadServices();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewServices.SelectedRows[0].Cells["ID"].Value);
                string newName = "Edited Service";
                double newPrice = 200;

                using (var conn = new SqliteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "UPDATE Services SET ServiceName=@name, Price=@price WHERE ID=@id";
                    using (var cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", newName);
                        cmd.Parameters.AddWithValue("@price", newPrice);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadServices();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewServices.SelectedRows[0].Cells["ID"].Value);

                using (var conn = new SqliteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Services WHERE ID=@id";
                    using (var cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadServices();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadServices();
        }
    }
}