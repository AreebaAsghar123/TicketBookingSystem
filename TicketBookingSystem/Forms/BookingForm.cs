using System;
using System.Data.SQLite;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    public partial class BookingForm : Form
    {
        // Ticket details jo SearchForm se aayengi
        public int TicketID { get; set; }
        public string Route { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Company { get; set; }
        public double Fare { get; set; }
        public int AvailableSeats { get; set; } // ← Naya add hua

        private double totalFare;

        public BookingForm()
        {
            InitializeComponent();
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {
            // Ticket info dikhao
            lblRoute.Text = "Route: " + Route;
            lblDate.Text = "Date: " + Date + " | " + Time;
            lblFare.Text = "Fare: Rs. " + Fare;
            lblCompany.Text = "Company: " + Company;
            lblSeats.Text = "Available Seats: " + AvailableSeats; // ← Naya add hua

            totalFare = Fare;
            lblTotalAmount.Text = "Rs. " + totalFare;

            // Passenger name auto fill
            if (Session.CurrentUser != null)
                txtPassengerName.Text = Session.CurrentUser.FullName;
        }

        // ── Promo Code Apply ─────────────────────────────────────────
        private void btnApplyPromo_Click(object sender, EventArgs e)
        {
            string code = txtPromo.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(code))
            {
                ShowError("Promo code bharein!");
                return;
            }

            // Simple promo codes
            if (code == "SAVE10")
            {
                totalFare = Fare * 0.90;
                lblTotalAmount.Text = "Rs. " + totalFare + " (10% off!)";
                lblError.Visible = false;
            }
            else if (code == "SAVE20")
            {
                totalFare = Fare * 0.80;
                lblTotalAmount.Text = "Rs. " + totalFare + " (20% off!)";
                lblError.Visible = false;
            }
            else
            {
                ShowError("Invalid promo code!");
                totalFare = Fare;
                lblTotalAmount.Text = "Rs. " + totalFare;
            }
        }

        // ── Confirm Booking ───────────────────────────────────────────
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string name = txtPassengerName.Text.Trim();
            string seat = txtSeat.Text.Trim().ToUpper();
            string payment = cmbPayment.SelectedItem?.ToString();

            // Validation
            if (string.IsNullOrEmpty(name))
            { ShowError("Passenger name bharein!"); return; }

            if (string.IsNullOrEmpty(seat))
            { ShowError("Seat number bharein! (e.g. A1)"); return; }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    // Booking save karo
                    string insertBooking = @"
                        INSERT INTO Bookings
                            (UserID, TicketID, SeatNumber, PassengerName,
                             BookingDate, Status, TotalFare)
                        VALUES
                            (@uid, @tid, @seat, @name, @date, 'Active', @fare)";

                    int bookingID;

                    using (var cmd = new SQLiteCommand(insertBooking, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", Session.CurrentUser.UserID);
                        cmd.Parameters.AddWithValue("@tid", TicketID);
                        cmd.Parameters.AddWithValue("@seat", seat);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@date",
                            DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@fare", totalFare);
                        cmd.ExecuteNonQuery();
                        bookingID = (int)conn.LastInsertRowId;
                    }

                    // Payment save karo
                    string insertPayment = @"
                        INSERT INTO Payments
                            (BookingID, Amount, PaymentMethod, PaymentDate, Status)
                        VALUES
                            (@bid, @amount, @method, @date, 'Completed')";

                    using (var cmd = new SQLiteCommand(insertPayment, conn))
                    {
                        cmd.Parameters.AddWithValue("@bid", bookingID);
                        cmd.Parameters.AddWithValue("@amount", totalFare);
                        cmd.Parameters.AddWithValue("@method", payment);
                        cmd.Parameters.AddWithValue("@date",
                            DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();
                    }

                    // Available seats update karo
                    string updateSeats = @"
                        UPDATE Tickets SET AvailableSeats = AvailableSeats - 1
                        WHERE TicketID = @tid";

                    using (var cmd = new SQLiteCommand(updateSeats, conn))
                    {
                        cmd.Parameters.AddWithValue("@tid", TicketID);
                        cmd.ExecuteNonQuery();
                    }
                }

                // E-Ticket dikhao
                MessageBox.Show(
                    $"Booking Confirmed!\n\n" +
                    $"Passenger: {name}\n" +
                    $"Route: {Route}\n" +
                    $"Date: {Date} | {Time}\n" +
                    $"Seat: {seat}\n" +
                    $"Company: {Company}\n" +
                    $"Amount Paid: Rs. {totalFare}\n" +
                    $"Payment: {payment}\n\n" +
                    $"Have a safe journey!",
                    "Booking Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                ShowError("Error: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowError(string msg)
        {
            lblError.Text = "⚠ " + msg;
            lblError.Visible = true;
        }

        private void lblFare_Click(object sender, EventArgs e)
        {

        }
    }
}