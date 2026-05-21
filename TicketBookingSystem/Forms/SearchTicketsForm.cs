using System;
using System.Data.SQLite;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    /// <summary>
    /// SearchTicketsForm — Allows users to search and filter available tickets
    /// Displays results in a DataGridView and opens BookingForm on selection
    /// </summary>
    public partial class SearchTicketsForm : Form
    {
        public SearchTicketsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets up grid columns and loads all available tickets on form load
        /// </summary>
        private void SearchTicketsForm_Load(object sender, EventArgs e)
        {
            // Define DataGridView column headers
            dgvTickets.Columns.Clear();
            dgvTickets.Columns.Add("TicketID", "ID");
            dgvTickets.Columns.Add("Route", "Route");
            dgvTickets.Columns.Add("Category", "Type");
            dgvTickets.Columns.Add("Date", "Date");
            dgvTickets.Columns.Add("Time", "Departure");
            dgvTickets.Columns.Add("Company", "Company");
            dgvTickets.Columns.Add("Fare", "Fare (Rs.)");
            dgvTickets.Columns.Add("Seats", "Available Seats");

            // Hide TicketID column — used internally for booking only
            dgvTickets.Columns["TicketID"].Visible = false;

            // Load all available tickets when form first opens
            LoadTickets("", "", "", "All");
        }

        /// <summary>
        /// Reads search filter values and loads matching tickets
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get selected filter values from dropdowns and date picker
            string from = cmbFrom.SelectedItem?.ToString() ?? "";
            string to = cmbTo.SelectedItem?.ToString() ?? "";
            string date = dtpDate.Value.ToString("yyyy-MM-dd");
            string category = cmbCategory.SelectedItem?.ToString() ?? "All";

            // Load tickets matching the selected filters
            LoadTickets(from, to, date, category);
        }

        /// <summary>
        /// Fetches tickets from database based on filter parameters
        /// Only shows tickets with available seats greater than zero
        /// </summary>
        private void LoadTickets(string from, string to,
            string date, string category)
        {
            dgvTickets.Rows.Clear();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    // Base query — only fetch tickets with available seats
                    string sql = @"
                        SELECT t.TicketID,
                               r.Source || ' → ' || r.Destination AS Route,
                               r.Category, t.DepartureDate,
                               t.DepartureTime, t.Company,
                               t.Fare, t.AvailableSeats
                        FROM Tickets t
                        JOIN Routes r ON t.RouteID = r.RouteID
                        WHERE t.AvailableSeats > 0";

                    // Dynamically append filter conditions based on user selection
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
                        // Add parameters safely to prevent SQL injection
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
                                // Add each ticket as a new row in the grid
                                dgvTickets.Rows.Add(
                                    reader[0], reader[1], reader[2],
                                    reader[3], reader[4], reader[5],
                                    "Rs. " + reader[6], reader[7]);
                                count++;
                            }

                            // Display total number of results found
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

        /// <summary>
        /// Opens BookingForm with selected ticket details
        /// Refreshes ticket list after booking is complete
        /// </summary>
        private void btnBook_Click(object sender, EventArgs e)
        {
            // Ensure a ticket row is selected before proceeding
            if (dgvTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a ticket first!",
                    "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Get the selected ticket row
            var row = dgvTickets.SelectedRows[0];

            // Pass selected ticket details to BookingForm
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

            // Refresh ticket list after booking to show updated seat counts
            LoadTickets("", "", "", "All");
        }

        /// <summary>
        /// Closes the form and returns to the dashboard
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}