using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    /// <summary>
    /// BookingHistoryForm — Displays all bookings of the logged-in user
    /// Active bookings shown in green, Cancelled bookings shown in red
    /// </summary>
    public partial class BookingHistoryForm : Form
    {
        public BookingHistoryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets up grid columns and loads bookings when form opens
        /// </summary>
        private void BookingHistoryForm_Load(object sender, EventArgs e)
        {
            // Define DataGridView columns
            dgvBookings.Columns.Clear();
            dgvBookings.Columns.Add("BookingID", "ID");
            dgvBookings.Columns.Add("Route", "Route");
            dgvBookings.Columns.Add("Date", "Travel Date");
            dgvBookings.Columns.Add("Seat", "Seat");
            dgvBookings.Columns.Add("Passenger", "Passenger");
            dgvBookings.Columns.Add("Amount", "Amount");
            dgvBookings.Columns.Add("Payment", "Payment");
            dgvBookings.Columns.Add("Status", "Status");
            dgvBookings.Columns.Add("BookDate", "Booked On");

            // Hide BookingID — used internally for cancel operation
            dgvBookings.Columns["BookingID"].Visible = false;

            LoadBookings();
        }

        /// <summary>
        /// Loads all bookings of the current logged-in user from database
        /// Active bookings = green | Cancelled bookings = red
        /// </summary>
        private void LoadBookings()
        {
            dgvBookings.Rows.Clear();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    // Join Bookings with Tickets, Routes and Payments
                    // LEFT JOIN Payments — shows row even if no payment record exists
                    string sql = @"
                        SELECT b.BookingID,
                               r.Source || ' → ' || r.Destination,
                               t.DepartureDate, b.SeatNumber,
                               b.PassengerName, b.TotalFare,
                               p.PaymentMethod, b.Status, b.BookingDate
                        FROM Bookings b
                        JOIN Tickets t ON b.TicketID = t.TicketID
                        JOIN Routes r ON t.RouteID = r.RouteID
                        LEFT JOIN Payments p ON p.BookingID = b.BookingID
                        WHERE b.UserID = @uid
                        ORDER BY b.BookingID DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        // Fetch only the current user's bookings
                        cmd.Parameters.AddWithValue("@uid",
                            Session.CurrentUser.UserID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            int count = 0;
                            while (reader.Read())
                            {
                                int rowIndex = dgvBookings.Rows.Add(
                                    reader[0], reader[1], reader[2],
                                    reader[3], reader[4],
                                    "Rs. " + reader[5],
                                    reader[6], reader[7], reader[8]);

                                // Color-code rows based on booking status
                                // Cancelled = light red | Active = light green
                                string status = reader[7].ToString();
                                if (status == "Cancelled")
                                    dgvBookings.Rows[rowIndex]
                                        .DefaultCellStyle.BackColor =
                                        Color.FromArgb(255, 220, 220);
                                else
                                    dgvBookings.Rows[rowIndex]
                                        .DefaultCellStyle.BackColor =
                                        Color.FromArgb(220, 255, 220);

                                count++;
                            }

                            // Display total booking count
                            lblCount.Text = $"Total Bookings: {count}";
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
        /// Cancels the selected booking
        /// Sets booking status to Cancelled and restores the seat as available
        /// </summary>
        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (dgvBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking to cancel!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prevent cancelling an already cancelled booking
            string status = dgvBookings.SelectedRows[0]
                .Cells["Status"].Value.ToString();
            if (status == "Cancelled")
            {
                MessageBox.Show("This booking is already cancelled!",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ask user to confirm before cancelling
            var result = MessageBox.Show(
                "Are you sure you want to cancel this booking?",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int bookingID = Convert.ToInt32(
                    dgvBookings.SelectedRows[0].Cells["BookingID"].Value);

                try
                {
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        // Step 1: Set booking status to Cancelled
                        string update = @"UPDATE Bookings 
                                         SET Status='Cancelled' 
                                         WHERE BookingID=@id";
                        using (var cmd = new SQLiteCommand(update, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", bookingID);
                            cmd.ExecuteNonQuery();
                        }

                        // Step 2: Get TicketID to restore the available seat
                        string getTicket = @"SELECT TicketID FROM Bookings 
                                            WHERE BookingID=@id";
                        int ticketID;
                        using (var cmd = new SQLiteCommand(getTicket, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", bookingID);
                            ticketID = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Step 3: Increment available seats back by 1
                        string updateSeats = @"UPDATE Tickets 
                                              SET AvailableSeats = AvailableSeats + 1 
                                              WHERE TicketID = @tid";
                        using (var cmd = new SQLiteCommand(updateSeats, conn))
                        {
                            cmd.Parameters.AddWithValue("@tid", ticketID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show(
                        "Booking cancelled successfully! Refund is being processed.",
                        "Cancelled",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Refresh grid to show updated status
                    LoadBookings();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Closes the form and returns to previous screen
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}