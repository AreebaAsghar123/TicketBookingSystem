using System;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            // Logged-in user ka naam welcome label mein dikhao
            if (Session.CurrentUser != null)
                lblWelcome.Text = $"Welcome, {Session.CurrentUser.FullName}! 👋";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Search Tickets form open karo
            SearchTicketsForm search = new SearchTicketsForm();
            search.Show();
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            // Role check karo — Admin ho to Admin Panel, warna Feedback
            if (Session.CurrentUser.IsAdmin)
            {
                // Admin user — Admin Panel open karo
                AdminPanelForm admin = new AdminPanelForm();
                admin.Show();
            }
            else
            {
                // Passenger user — Feedback coming soon
                MessageBox.Show("Feedback — Coming Soon! ⭐",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMyBookings_Click(object sender, EventArgs e)
        {
            // Booking history form open karo
            BookingHistoryForm history = new BookingHistoryForm();
            history.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Logout confirmation dialog dikhao
            var result = MessageBox.Show("Logout karna chahte hain?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Session clear karo aur login form wapas kholo
                Session.Clear();
                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
        }

        private void MainDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Dashboard band hone par poori application exit karo
            Application.Exit();
        }
    }
}
