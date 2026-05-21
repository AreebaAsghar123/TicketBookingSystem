using System;
using System.Data.SQLite;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    /// <summary>
    /// BookingForm — Allows user to confirm a ticket booking
    /// Receives ticket details from SearchTicketsForm
    /// </summary>
    public partial class BookingForm : Form
    {
        // Properties to receive ticket details from SearchTicketsForm
        public int TicketID { get; set; }
        public string Route { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Company { get; set; }
        public double Fare { get; set; }
        public int AvailableSeats { get; set; }

        // Stores final fare after promo code is applied
        private double totalFare;

        public BookingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Displays ticket details on form load
        /// Auto-fills passenger name from current session
        /// </summary>
        private void BookingForm_Load(object sender, EventArgs e)
        {
            // Display ticket information in labels
            lblRoute.Text = "Route: " + Route;
            lblDate.Text = "Date: " + Date + " | " + Time;
            lblFare.Text = "Fare: Rs. " + Fare;
            lblCompany.Text = "Company: " + Company;
            lblSeats.Text = "Available Seats: " + AvailableSeats;

            // Set initial total fare
            totalFare = Fare;
            lblTotalAmount.Text = "Rs. " + totalFare;

            // Auto-fill passenger name from logged-in user session
            if (Session.CurrentUser != null)
                txtPassengerName.Text = Session.CurrentUser.FullName;
        }

        /// <summary>
        /// Applies promo code discount to the total fare
        /// Supported codes: SAVE10 (10% off), SAVE20 (20% off)
        /// </summary>
        private void btnApplyPromo_Click(object sender, EventArgs e)
        {
            string code = txtPromo.Text.Trim().ToUpper();

            // Promo code field cannot be empty
            if (string.IsNullOrEmpty(code))
            {
                ShowError("Please enter a promo code!");
                return;
            }

            // Apply discount based on promo code
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
                // Invalid promo code — reset fare to original
                ShowError("Invalid promo code!");
                totalFare = Fare;
                lblTotalAmount.Text = "Rs. " + totalFare;
            }
        }

        /// <summary>
        /// Confirms the booking — saves booking and payment to database
        /// Also decrements available seats on the selected ticket
        /// </summary>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string name = txtPassengerName.Text.Trim();
            string seat = txtSeat.Text.Trim().ToUpper();
            string payment = cmbPayment.SelectedItem?.ToString();

            // Validate required input fields
            if (string.IsNullOrEmpty(name))
            { ShowError("Please enter passenger name!"); return; }

            if (string.IsNullOrEmpty(seat))
            { ShowError("Please enter seat number! (e.g. A1)"); return; }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    // Step 1: Insert booking record into Bookings table
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

                        // Get the auto-generated BookingID for payment record
                        bookingID = (int)conn.LastInsertRowId;
                    }

                    // Step 2: Insert payment record into Payments table
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

                    // Step 3: Reduce available seats by 1 after booking
                    string updateSeats = @"
                        UPDATE Tickets 
                        SET AvailableSeats = AvailableSeats - 1
                        WHERE TicketID = @tid";

                    using (var cmd = new SQLiteCommand(updateSeats, conn))
                    {
                        cmd.Parameters.AddWithValue("@tid", TicketID);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Show booking confirmation with e-ticket details
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

        /// <summary>
        /// Closes the booking form without saving
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Displays error message in the error label
        /// </summary>
        private void ShowError(string msg)
        {
            lblError.Text = "⚠ " + msg;
            lblError.Visible = true;
        }

        private void lblFare_Click(object sender, EventArgs e) { }
    }
}