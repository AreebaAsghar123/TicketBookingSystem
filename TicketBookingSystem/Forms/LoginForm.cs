using System;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    /// <summary>
    /// LoginForm — Entry point of the application
    /// Handles user authentication and redirects to dashboard on success
    /// </summary>
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // Initialize database when application starts for the first time
            DatabaseHelper.InitializeDatabase();
        }

        /// <summary>
        /// Validates credentials and logs in the user
        /// Sets session and opens MainDashboard on successful login
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Ensure email and password fields are not empty
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "⚠ Enter your email and password!";
                lblError.Visible = true;
                return;
            }

            // Authenticate user credentials against the database
            User user = DatabaseHelper.LoginUser(email, password);

            if (user != null)
            {
                // Login successful — store user in session and open dashboard
                Session.CurrentUser = user;
                lblError.Visible = false;

                MainDashboard dashboard = new MainDashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                // Invalid credentials — show error and clear password field
                lblError.Text = "⚠ Email or Password is not valid!";
                lblError.Visible = true;
                txtPassword.Clear();
            }
        }

        /// <summary>
        /// Opens the RegisterForm as a modal dialog
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm reg = new RegisterForm();
            reg.ShowDialog();
        }

        /// <summary>
        /// Toggles password visibility based on checkbox state
        /// </summary>
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Show plain text when checked, hide when unchecked
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        /// <summary>
        /// Exits the entire application when login form is closed
        /// </summary>
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}