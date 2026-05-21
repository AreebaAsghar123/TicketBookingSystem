using System;
using System.Data.SQLite;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    public partial class AdminPanelForm : Form
    {
        // Stores the currently selected user's ID for update/delete operations
        private int selectedUserID = 0;

        public AdminPanelForm()
        {
            InitializeComponent();
        }

        // Fires when form loads — loads all data into grids
        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            LoadRoutes();
            LoadAllBookings();
            LoadAllUsers();
        }

        // ── Load all routes into the routes grid ──────────────────────
        private void LoadRoutes()
        {
            dgvRoutes.Columns.Clear();
            dgvRoutes.Columns.Add("RouteID", "ID");
            dgvRoutes.Columns.Add("Source", "Source");
            dgvRoutes.Columns.Add("Destination", "Destination");
            dgvRoutes.Columns.Add("Distance", "Distance (km)");
            dgvRoutes.Columns.Add("Duration", "Duration");
            dgvRoutes.Columns.Add("Category", "Category");

            // Hide ID column — used internally for delete
            dgvRoutes.Columns["RouteID"].Visible = false;
            dgvRoutes.Rows.Clear();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    string sql = @"SELECT RouteID, Source, Destination, 
                                  Distance, Duration, Category FROM Routes";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            dgvRoutes.Rows.Add(
                                reader[0], reader[1], reader[2],
                                reader[3], reader[4], reader[5]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading routes: " + ex.Message);
            }
        }

        // ── Load all bookings into the bookings grid ──────────────────
        private void LoadAllBookings()
        {
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
                    // Join Bookings with Tickets and Routes to get full info
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
                MessageBox.Show("Error loading bookings: " + ex.Message);
            }
        }

        // ── Load all users into the users grid ────────────────────────
        private void LoadAllUsers()
        {
            dgvUsers.Columns.Clear();
            dgvUsers.Columns.Add("UserID", "ID");
            dgvUsers.Columns.Add("FullName", "Full Name");
            dgvUsers.Columns.Add("Email", "Email");
            dgvUsers.Columns.Add("Phone", "Phone");
            dgvUsers.Columns.Add("Role", "Role");
            dgvUsers.Columns.Add("CreatedDate", "Joined Date");

            // Hide ID column — used internally for update/delete
            dgvUsers.Columns["UserID"].Visible = false;
            dgvUsers.Rows.Clear();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    string sql = @"SELECT UserID, FullName, Email, 
                                  Phone, Role, CreatedDate 
                                  FROM Users ORDER BY UserID DESC";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            dgvUsers.Rows.Add(
                                reader[0], reader[1], reader[2],
                                reader[3], reader[4], reader[5]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }

            // Clear edit fields after reload
            ClearEditFields();
        }

        // ── Fires when user selects a row in the users grid ──────────
        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;

            var row = dgvUsers.SelectedRows[0];

            // Store selected user ID for update/delete
            selectedUserID = Convert.ToInt32(row.Cells["UserID"].Value);

            // Populate edit fields with selected user data
            txtEditName.Text = row.Cells["FullName"].Value.ToString();
            txtEditPhone.Text = row.Cells["Phone"].Value.ToString();
            cmbEditRole.SelectedItem = row.Cells["Role"].Value.ToString();
        }

        // ── Update selected user's info in database ───────────────────
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            // Check if a user is selected
            if (selectedUserID == 0)
            {
                MessageBox.Show("Please select a user to update!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtEditName.Text.Trim();
            string phone = txtEditPhone.Text.Trim();
            string role = cmbEditRole.SelectedItem?.ToString();

            // Validate input fields
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Name and Phone cannot be empty!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    // Update user record in database
                    string sql = @"UPDATE Users 
                                  SET FullName=@name, Phone=@phone, Role=@role
                                  WHERE UserID=@id";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@id", selectedUserID);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("User updated successfully! ✅", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload grid to reflect changes
                LoadAllUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message);
            }
        }

        // ── Delete selected user from database ────────────────────────
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prevent admin account from being deleted
            string role = dgvUsers.SelectedRows[0]
                .Cells["Role"].Value.ToString();
            if (role == "Admin")
            {
                MessageBox.Show("Admin user cannot be deleted!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show confirmation dialog before deleting
            var result = MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int userID = Convert.ToInt32(
                    dgvUsers.SelectedRows[0].Cells["UserID"].Value);

                try
                {
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        string sql = "DELETE FROM Users WHERE UserID = @id";
                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", userID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("User deleted successfully! ✅", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload grid after deletion
                    LoadAllUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message);
                }
            }
        }

        // ── Refresh users grid manually ───────────────────────────────
        private void btnRefreshUsers_Click(object sender, EventArgs e)
        {
            LoadAllUsers();
        }

        // ── Clear all edit input fields ───────────────────────────────
        private void ClearEditFields()
        {
            selectedUserID = 0;
            txtEditName.Text = "";
            txtEditPhone.Text = "";
            cmbEditRole.SelectedIndex = -1;
        }

        // ── Add a new route to the database ──────────────────────────
        private void btnAddRoute_Click(object sender, EventArgs e)
        {
            string source = txtSource.Text.Trim();
            string dest = txtDestination.Text.Trim();
            string distance = txtDistance.Text.Trim();
            string duration = txtDuration.Text.Trim();
            string category = cmbRouteCategory.SelectedItem?.ToString();

            // Source and destination are required fields
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(dest))
            {
                MessageBox.Show("Source and Destination are required!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    // Insert new route using parameterized query
                    string sql = @"INSERT INTO Routes
                        (Source, Destination, Distance, Duration, Category)
                        VALUES (@src, @dst, @dist, @dur, @cat)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@src", source);
                        cmd.Parameters.AddWithValue("@dst", dest);
                        cmd.Parameters.AddWithValue("@dist", distance);
                        cmd.Parameters.AddWithValue("@dur", duration);
                        cmd.Parameters.AddWithValue("@cat", category);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Route added successfully! ✅", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear input fields and refresh grid
                txtSource.Clear();
                txtDestination.Clear();
                txtDistance.Clear();
                txtDuration.Text = "e.g. 2h 30min";
                LoadRoutes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding route: " + ex.Message);
            }
        }

        // ── Delete selected route from database ───────────────────────
        private void btnDeleteRoute_Click(object sender, EventArgs e)
        {
            if (dgvRoutes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a route to delete!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm before deleting
            var result = MessageBox.Show(
                "Are you sure you want to delete this route?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int routeID = Convert.ToInt32(
                    dgvRoutes.SelectedRows[0].Cells["RouteID"].Value);

                try
                {
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        string sql = "DELETE FROM Routes WHERE RouteID = @id";
                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", routeID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Route deleted successfully! ✅", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh grid after deletion
                    LoadRoutes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting route: " + ex.Message);
                }
            }
        }

        // ── Close admin panel and return to dashboard ─────────────────
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ── Placeholder for future route cell click handling ──────────
        private void dgvRoutes_CellContentClick(object sender,
            DataGridViewCellEventArgs e)
        { }
    }
}