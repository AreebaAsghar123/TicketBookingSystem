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
            if (Session.CurrentUser != null)
                lblWelcome.Text = $"Welcome, {Session.CurrentUser.FullName}! 👋";
        }

        private void btnSearch_Click(object sender, EventArgs e)

        {
            SearchTicketsForm search = new SearchTicketsForm();
            search.Show();
     
        }
        private void btnFeedback_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser.IsAdmin)
            {
                AdminPanelForm admin = new AdminPanelForm();
                admin.Show();
            }
            else
            {
                MessageBox.Show("Feedback — Coming Soon! ⭐",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnMyBookings_Click(object sender, EventArgs e)
        {
            BookingHistoryForm history = new BookingHistoryForm();
            history.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Logout karna chahte hain?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Session.Clear();
                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
        }

        private void MainDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
