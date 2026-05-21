using System;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    /// <summary>
    /// MainDashboard — Central navigation hub after successful login
    /// Provides access to Search, Bookings, Admin Panel and Logout
    /// </summary>
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Displays welcome message with logged-in user's name
        /// </summary>
        private void MainDashboard_Load(object sender, EventArgs e)
        {
            // Show personalized welcome message from session
            if (Session.CurrentUser != null)
                lblWelcome.Text =
                    $"Welcome, {Session.CurrentUser.FullName}! 👋";
        }

        /// <summary>
        /// Opens the Search Tickets form
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchTicketsForm search = new SearchTicketsForm();
            search.Show();
        }

        /// <summary>
        /// Opens Admin Panel for admin users
        /// Shows feedback message for regular passengers
        /// </summary>
        private void btnFeedback_Click(object sender, EventArgs e)
        {
            // Check user role — Admin gets Admin Panel, Passenger gets Feedback
            if (Session.CurrentUser.IsAdmin)
            {
                // Admin user — open Admin Panel
                AdminPanelForm admin = new AdminPanelForm();
                admin.Show();
            }
            else
            {
                // Passenger user — Feedback feature coming soon
                MessageBox.Show("Feedback — Coming Soon! ⭐",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Opens the Booking History form for current user
        /// </summary>
        private void btnMyBookings_Click(object sender, EventArgs e)
        {
            BookingHistoryForm history = new BookingHistoryForm();
            history.Show();
        }

        /// <summary>
        /// Logs out the current user after confirmation
        /// Clears session and returns to Login form
        /// </summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Ask user to confirm before logging out
            var result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear session data and return to login screen
                Session.Clear();
                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
        }

        /// <summary>
        /// Exits the entire application when dashboard is closed
        /// </summary>
        private void MainDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}