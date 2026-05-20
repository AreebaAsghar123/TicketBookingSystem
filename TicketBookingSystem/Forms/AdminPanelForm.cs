using System;
using System.Data.SQLite;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    public partial class AdminPanelForm : Form
    {
        public AdminPanelForm()
        {
            InitializeComponent();
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            // Form load hone par routes aur bookings dono load karo
            LoadRoutes();
            LoadAllBookings();
        }

        private void LoadRoutes()
        {
            // Routes grid columns define karo
            dgvRoutes.Columns.Clear();
            dgvRoutes.Columns.Add("RouteID", "ID");
            dgvRoutes.Columns.Add("Source", "Source");
            dgvRoutes.Columns.Add("Destination", "Destination");
            dgvRoutes.Columns.Add("Distance", "Distance (km)");
            dgvRoutes.Columns.Add("Duration", "Duration");
            dgvRoutes.Columns.Add("Category", "Category");

            // RouteID hide karo — delete operation mein internally use hoga
            dgvRoutes.Columns["RouteID"].Visible = false;
            dgvRoutes.Rows.Clear();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    // Database se saari routes fetch karo
                    string sql = "SELECT RouteID, Source, Destination, Distance, Duration, Category FROM Routes";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            dgvRoutes.Rows.Add(reader[0], reader[1], reader[2],
                                               reader[3], reader[4], reader[5]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadAllBookings()
        {
            // All bookings grid columns define karo
            dgvAllBookings.Columns.Clear();
            dgvAllBookings.Columns.Add("BookingID", "ID");
            dgvAllBookings.Columns.Add("Passenger", "Passenger");
            dgvAllBookings.Columns.Add("Route", "Route");
            dgvAllBookings.Columns.Add("Date", "Date");
            dgvAllBookings.Columns.Add("Seat", "Seat");
            dgvAllBookings.Columns.Add("Amount", "Amount");
            dgvAllBookings.Columns.Add("Status", "Status");
            dgvAllBookings.Rows.Clear();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    // Saari bookings fetch karo — JOIN se route info bhi lo
                    // Latest bookings pehle dikhane ke liye DESC order use kiya
                    string sql = @"
                        SELECT b.BookingID, b.PassengerName,
                               r.Source || ' → ' || r.Destination,
                               t.DepartureDate, b.SeatNumber,
                               'Rs. ' || b.TotalFare, b.Status
                        FROM Bookings b
                        JOIN Tickets t ON b.TicketID = t.TicketID
                        JOIN Routes r ON t.RouteID = r.RouteID
                        ORDER BY b.BookingID DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            dgvAllBookings.Rows.Add(
                                reader[0], reader[1], reader[2],
                                reader[3], reader[4], reader[5], reader[6]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAddRoute_Click(object sender, EventArgs e)
        {
            // Form fields se input lo
            string source = txtSource.Text.Trim();
            string dest = txtDestination.Text.Trim();
            string distance = txtDistance.Text.Trim();
            string duration = txtDuration.Text.Trim();
            string category = cmbRouteCategory.SelectedItem.ToString();

            // Source aur destination mandatory fields hain
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(dest))
            {
                MessageBox.Show("Source aur Destination zaroor bharein!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    // Naya route database mein insert karo
                    string sql = @"INSERT INTO Routes
                        (Source, Destination, Distance, Duration, Category)
                        VALUES (@src, @dst, @dist, @dur, @cat)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        // Parameterized query — SQL injection se bachao
                        cmd.Parameters.AddWithValue("@src", source);
                        cmd.Parameters.AddWithValue("@dst", dest);
                        cmd.Parameters.AddWithValue("@dist", distance);
                        cmd.Parameters.AddWithValue("@dur", duration);
                        cmd.Parameters.AddWithValue("@cat", category);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Route add ho gaya! ✅", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Form fields clear karo aur grid refresh karo
                txtSource.Clear();
                txtDestination.Clear();
                txtDistance.Clear();
                txtDuration.Text = "e.g. 2h 30min";
                LoadRoutes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDeleteRoute_Click(object sender, EventArgs e)
        {
            // Pehle check karo ke koi route selected hai
            if (dgvRoutes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pehle koi route select karein!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Delete confirmation dialog dikhao
            var result = MessageBox.Show("Kya aap yeh route delete karna chahte hain?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Selected row se RouteID lo
                int routeID = Convert.ToInt32(
                    dgvRoutes.SelectedRows[0].Cells["RouteID"].Value);

                try
                {
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        // Route database se delete karo
                        string sql = "DELETE FROM Routes WHERE RouteID = @id";
                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", routeID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Route delete ho gaya! ✅", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Grid refresh karo — deleted route remove ho jaye
                    LoadRoutes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Admin panel band karo — dashboard par wapas jao
            this.Close();
        }

        private void dgvRoutes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Future use ke liye — route cell click event
        }
    }
}
