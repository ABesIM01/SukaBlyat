using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Forms
{
    public partial class OrdersViewForm : Form
    {
        private readonly string connectionString = "Data Source=orders.db";

        public OrdersViewForm()
        {
            InitializeComponent();
            LoadOrders();
            StyleDataGrid();
        }

        private void LoadOrders()
        {
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Користувач", typeof(string));
            dt.Columns.Add("Послуги", typeof(string));
            dt.Columns.Add("Дата замовлення", typeof(string));

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqliteCommand("SELECT Id, UserName, ProductList, OrderDate FROM Orders ORDER BY Id DESC", connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dt.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    }
                }
            }

            dataGridView1.DataSource = dt;

            // додаємо кнопку "Видалити", якщо її ще немає
            if (!dataGridView1.Columns.Contains("Delete"))
            {
                var deleteColumn = new DataGridViewButtonColumn();
                deleteColumn.HeaderText = "";
                deleteColumn.Text = "🗑️ Видалити";
                deleteColumn.UseColumnTextForButtonValue = true;
                deleteColumn.FlatStyle = FlatStyle.Flat;
                dataGridView1.Columns.Add(deleteColumn);
            }
        }


        private void StyleDataGrid()
        {
            dataGridView1.BackgroundColor = Color.FromArgb(30, 30, 30);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 25, 25);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowTemplate.Height = 40;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Якщо натиснуто "Видалити"
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                DeleteOrder(id);
                LoadOrders();
            }
        }

        private void DeleteOrder(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqliteCommand("DELETE FROM orders WHERE id = @id", connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Очистити всі замовлення?", "Підтвердження",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    var cmd = new SqliteCommand("DELETE FROM orders", connection);
                    cmd.ExecuteNonQuery();
                }
                LoadOrders();
            }
        }
    }
}
