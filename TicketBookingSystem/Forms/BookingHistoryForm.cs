using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    /// <summary>
    /// BookingHistoryForm — User ki saari bookings yahan dikhti hain
    /// Active bookings green aur Cancelled bookings red color mein dikhti hain
    /// </summary>
    public partial class BookingHistoryForm : Form
    {
        public BookingHistoryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form load hone par columns set karta hai aur bookings load karta hai
        /// </summary>
        private void BookingHistoryForm_Load(object sender, EventArgs e)
        {
            // DataGridView columns define karo
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

            // BookingID hide karo — sirf internally use hoga cancel ke liye
            dgvBookings.Columns["BookingID"].Visible = false;

            LoadBookings();
        }

        /// <summary>
        /// Current logged in user ki saari bookings database se load karta hai
        /// Active = green color | Cancelled = red color
        /// </summary>
        private void LoadBookings()
        {
            dgvBookings.Rows.Clear();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    // Bookings, Tickets, Routes aur Payments JOIN kiye hain
                    // LEFT JOIN Payments — agar payment record na ho to bhi row aaye
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
                        // Sirf current user ki bookings laao
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

                                // Status ke hisaab se row ka color set karo
                                // Cancelled = light red | Active = light green
                                string status = reader[7].ToString();
                                if (status == "Cancelled")
                                    dgvBookings.Rows[rowIndex].DefaultCellStyle.BackColor =
                                        Color.FromArgb(255, 220, 220); // Light red
                                else
                                    dgvBookings.Rows[rowIndex].DefaultCellStyle.BackColor =
                                        Color.FromArgb(220, 255, 220); // Light green

                                count++;
                            }
                            // Total bookings count dikhao
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
        /// Selected booking cancel karta hai
        /// Booking status Cancelled set karta hai aur seat wapas available karta hai
        /// </summary>
        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            // Pehle check karo koi row select hai ya nahi
            if (dgvBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pehle koi booking select karein!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Already cancelled booking dobara cancel nahi ho sakti
            string status = dgvBookings.SelectedRows[0].Cells["Status"].Value.ToString();
            if (status == "Cancelled")
            {
                MessageBox.Show("Yeh booking pehle se cancel ho chuki hai!",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // User se confirm karo
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
                        // Step 1: Booking status Cancelled set karo
                        string update = "UPDATE Bookings SET Status='Cancelled' WHERE BookingID=@id";
                        using (var cmd = new SQLiteCommand(update, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", bookingID);
                            cmd.ExecuteNonQuery();
                        }

                        // Step 2: TicketID nikalo taake seat wapas de sakein
                        string getTicket = "SELECT TicketID FROM Bookings WHERE BookingID=@id";
                        int ticketID;
                        using (var cmd = new SQLiteCommand(getTicket, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", bookingID);
                            ticketID = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Step 3: Cancelled seat wapas available karo
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

                    // Grid refresh karo updated status dikhane ke liye
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
        /// Back button — form band karta hai
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}