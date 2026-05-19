using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    public partial class BookingHistoryForm : Form
    {
        public BookingHistoryForm()
        {
            InitializeComponent();
        }

        private void BookingHistoryForm_Load(object sender, EventArgs e)
        {
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

            dgvBookings.Columns["BookingID"].Visible = false;

            LoadBookings();
        }

        private void LoadBookings()
        {
            dgvBookings.Rows.Clear();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
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
                        cmd.Parameters.AddWithValue("@uid", Session.CurrentUser.UserID);

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

                                // Status color
                                string status = reader[7].ToString();
                                if (status == "Cancelled")
                                    dgvBookings.Rows[rowIndex].DefaultCellStyle.BackColor =
                                        Color.FromArgb(255, 220, 220);
                                else
                                    dgvBookings.Rows[rowIndex].DefaultCellStyle.BackColor =
                                        Color.FromArgb(220, 255, 220);

                                count++;
                            }
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

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pehle koi booking select karein!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string status = dgvBookings.SelectedRows[0].Cells["Status"].Value.ToString();
            if (status == "Cancelled")
            {
                MessageBox.Show("Yeh booking pehle se cancel ho chuki hai!",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                "Kya aap yeh booking cancel karna chahte hain?",
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
                        // Status update karo
                        string update = "UPDATE Bookings SET Status='Cancelled' WHERE BookingID=@id";
                        using (var cmd = new SQLiteCommand(update, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", bookingID);
                            cmd.ExecuteNonQuery();
                        }

                        // Seat wapas available karo
                        string getTicket = "SELECT TicketID FROM Bookings WHERE BookingID=@id";
                        int ticketID;
                        using (var cmd = new SQLiteCommand(getTicket, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", bookingID);
                            ticketID = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        string updateSeats = @"UPDATE Tickets 
                            SET AvailableSeats = AvailableSeats + 1 
                            WHERE TicketID = @tid";
                        using (var cmd = new SQLiteCommand(updateSeats, conn))
                        {
                            cmd.Parameters.AddWithValue("@tid", ticketID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Booking cancel ho gayi! Refund process ho raha hai.",
                        "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadBookings();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
