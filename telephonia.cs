using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Telephonia : Form
    {
        public Telephonia()
        {
            InitializeComponent();
            TelephoniaDatabase.Init();  // Ініціалізуємо БД телефонії
            LoadData();
        }

        private void Telephonia_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = TelephoniaDatabase.GetAll();
            dgvPhones.DataSource = dt;

            if (!dgvPhones.Columns.Contains("CallButton"))
            {
                AddCallButtonColumn();
                AddMessageColumns();
            }

            HighlightToday();
        }

        private void AddCallButtonColumn()
        {
            DataGridViewButtonColumn callCol = new DataGridViewButtonColumn();
            callCol.HeaderText = "Call";
            callCol.Name = "CallButton";
            callCol.Text = "Call";
            callCol.UseColumnTextForButtonValue = true;
            callCol.Width = 80;
            dgvPhones.Columns.Add(callCol);
        }

        private void AddMessageColumns()
        {
            DataGridViewButtonColumn msgCol = new DataGridViewButtonColumn();
            msgCol.HeaderText = "Message";
            msgCol.Name = "MessageButton";
            msgCol.Text = "Message";
            msgCol.UseColumnTextForButtonValue = true;
            msgCol.Width = 100;
            dgvPhones.Columns.Add(msgCol);
        }

        private void HighlightToday()
        {
            DateTime today = DateTime.Today;

            foreach (DataGridViewRow row in dgvPhones.Rows)
            {
                if (row.IsNewRow) continue;

                if (DateTime.TryParse(row.Cells["CallDate"].Value?.ToString(), out DateTime callDate))
                {
                    row.DefaultCellStyle.BackColor =
                        callDate.Date == today ? Color.Yellow : Color.White;
                }
            }
        }

        private void dgvPhones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhones.CurrentRow == null) return;

            txtNotes.Text = dgvPhones.CurrentRow.Cells["Notes"].Value?.ToString();

            string ans = dgvPhones.CurrentRow.Cells["Answered"].Value?.ToString();
            rdoYes.Checked = ans == "Yes";
            rdoNo.Checked = ans == "No";

            if (DateTime.TryParse(dgvPhones.CurrentRow.Cells["CallDate"].Value?.ToString(), out DateTime d))
                dtpCallDate.Value = d;
            else
                dtpCallDate.Value = DateTime.Today;
        }

        private void btnUpdateNote_Click(object sender, EventArgs e)
        {
            if (dgvPhones.CurrentRow == null)
            {
                MessageBox.Show("Select a row first.");
                return;
            }

            int id = Convert.ToInt32(dgvPhones.CurrentRow.Cells["Id"].Value);
            string notes = txtNotes.Text;
            string answered = rdoYes.Checked ? "Yes" : "No";
            DateTime date = dtpCallDate.Value;

            TelephoniaDatabase.Update(id, notes, answered, date);
            LoadData();

            MessageBox.Show("Updated.");
        }

        private void dgvPhones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string phone = dgvPhones.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();

            // ВИКЛИК ДОДЗВОНУ
            if (dgvPhones.Columns[e.ColumnIndex].Name == "CallButton")
            {
                try
                {
                    Process.Start("dialer.exe", $"/d {phone}");
                }
                catch
                {
                    MessageBox.Show("Cannot start dialer.exe");
                }
            }
            // ВІДКРИТИ WHATSAPP
            else if (dgvPhones.Columns[e.ColumnIndex].Name == "MessageButton")
            {
                if (phone.StartsWith("0"))
                    phone = "962" + phone.Substring(1);

                string url = $"https://wa.me/{phone}?text=";
                Process.Start(new ProcessStartInfo() { FileName = url, UseShellExecute = true });
            }
        }

        private void dtpCallDate_ValueChanged(object sender, EventArgs e)
        {
            // якщо треба — можна додати логіку
        }

        private void btnFilterr_Click(object sender, EventArgs e)
        {
            string city = CityCom.SelectedItem?.ToString();
            DateTime start = dtpStartDatee.Value.Date;
            DateTime end = dtpEndDatee.Value.Date;

            DataTable dt = TelephoniaDatabase.FilterAnswered(city, start, end);
            dgvPhones.DataSource = dt;

            HighlightToday();
        }

        private void CityCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Можна оновити список при зміні міста
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
