using System;
using System.Data.SQLite;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    public partial class SearchTicketsForm : Form
    {
        public SearchTicketsForm()
        {
            InitializeComponent();
        }

        private void SearchTicketsForm_Load(object sender, EventArgs e)
        {
            // DataGridView columns define karo
            dgvTickets.Columns.Clear();
            dgvTickets.Columns.Add("TicketID", "ID");
            dgvTickets.Columns.Add("Route", "Route");
            dgvTickets.Columns.Add("Category", "Type");
            dgvTickets.Columns.Add("Date", "Date");
            dgvTickets.Columns.Add("Time", "Departure");
            dgvTickets.Columns.Add("Company", "Company");
            dgvTickets.Columns.Add("Fare", "Fare (Rs.)");
            dgvTickets.Columns.Add("Seats", "Available Seats");

            // TicketID column hide karo — sirf internally use hoga
            dgvTickets.Columns["TicketID"].Visible = false;

            // Form load hone par saare available tickets dikhao
            LoadTickets("", "", "", "All");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Search filters ki values lo
            string from = cmbFrom.SelectedItem?.ToString() ?? "";
            string to = cmbTo.SelectedItem?.ToString() ?? "";
            string date = dtpDate.Value.ToString("yyyy-MM-dd");
            string category = cmbCategory.SelectedItem?.ToString() ?? "All";

            // Filter ke mutabiq tickets load karo
            LoadTickets(from, to, date, category);
        }

        private void LoadTickets(string from, string to,
            string date, string category)
        {
            dgvTickets.Rows.Clear();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    // Base query — sirf available seats wale tickets dikhao
                    string sql = @"
                        SELECT t.TicketID,
                               r.Source || ' → ' || r.Destination AS Route,
                               r.Category, t.DepartureDate,
                               t.DepartureTime, t.Company,
                               t.Fare, t.AvailableSeats
                        FROM Tickets t
                        JOIN Routes r ON t.RouteID = r.RouteID
                        WHERE t.AvailableSeats > 0";

                    // Dynamic filters add karo jo user ne select kiye hain
                    if (!string.IsNullOrEmpty(from))
                        sql += " AND r.Source = @from";
                    if (!string.IsNullOrEmpty(to))
                        sql += " AND r.Destination = @to";
                    if (!string.IsNullOrEmpty(date))
                        sql += " AND t.DepartureDate = @date";
                    if (category != "All")
                        sql += " AND r.Category = @category";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        // Parameters safely add karo — SQL injection se bachne ke liye
                        if (!string.IsNullOrEmpty(from))
                            cmd.Parameters.AddWithValue("@from", from);
                        if (!string.IsNullOrEmpty(to))
                            cmd.Parameters.AddWithValue("@to", to);
                        if (!string.IsNullOrEmpty(date))
                            cmd.Parameters.AddWithValue("@date", date);
                        if (category != "All")
                            cmd.Parameters.AddWithValue("@category", category);

                        using (var reader = cmd.ExecuteReader())
                        {
                            int count = 0;
                            while (reader.Read())
                            {
                                // Har ticket ko grid mein add karo
                                dgvTickets.Rows.Add(
                                    reader[0], reader[1], reader[2],
                                    reader[3], reader[4], reader[5],
                                    "Rs. " + reader[6], reader[7]);
                                count++;
                            }
                            // Total results dikhao
                            lblResults.Text =
                                $"Available Tickets: {count} found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            // Pehle check karo ke koi ticket selected hai
            if (dgvTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pehle koi ticket select karein!",
                    "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Selected row se ticket details lo
            var row = dgvTickets.SelectedRows[0];

            // BookingForm ko selected ticket ki details pass karo
            BookingForm booking = new BookingForm();
            booking.TicketID = Convert.ToInt32(
                row.Cells["TicketID"].Value);
            booking.Route = row.Cells["Route"].Value.ToString();
            booking.Date = row.Cells["Date"].Value.ToString();
            booking.Time = row.Cells["Time"].Value.ToString();
            booking.Company = row.Cells["Company"].Value.ToString();
            booking.Fare = Convert.ToDouble(
                row.Cells["Fare"].Value.ToString()
                .Replace("Rs. ", ""));
            booking.AvailableSeats = Convert.ToInt32(
                row.Cells["Seats"].Value);
            booking.ShowDialog();

            // Booking ke baad tickets refresh karo — updated seats dikhao
            LoadTickets("", "", "", "All");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Dashboard par wapas jao
            this.Close();
        }
    }
}