using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    /// <summary>
    /// RegisterForm — Allows new users to create an account
    /// Includes input validation and password strength indicator
    /// </summary>
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Validates all input fields and registers the user in the database
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Retrieve and trim all input field values
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirm.Text.Trim();

            // Name field cannot be empty
            if (string.IsNullOrEmpty(name))
            {
                lblError.Text = "⚠ Please enter your name!";
                lblError.Visible = true;
                return;
            }

            // Email must be in valid format containing '@'
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                lblError.Text = "⚠ Please enter a valid email address!";
                lblError.Visible = true;
                return;
            }

            // Phone number must be at least 10 digits
            if (string.IsNullOrEmpty(phone) || phone.Length < 10)
            {
                lblError.Text = "⚠ Please enter a valid phone number!";
                lblError.Visible = true;
                return;
            }

            // Password must be at least 6 characters long
            if (password.Length < 6)
            {
                lblError.Text = "⚠ Password must be at least 6 characters!";
                lblError.Visible = true;
                return;
            }

            // Confirm password must match the original password
            if (password != confirm)
            {
                lblError.Text = "⚠ Passwords do not match!";
                lblError.Visible = true;
                return;
            }

            // All validations passed — register user in the database
            bool success = DatabaseHelper.RegisterUser(
                name, email, phone, password);

            if (success)
            {
                // Registration successful — notify user and close form
                MessageBox.Show(
                    "Account created successfully! 🎉 Please login.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
        }

        /// <summary>
        /// Closes the registration form without saving
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Checks password strength in real-time as user types
        /// Weak: less than 6 chars | Medium: 6+ chars | Strong: has uppercase and number
        /// </summary>
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string pwd = txtPassword.Text;

            // Hide strength label when password field is empty
            if (pwd.Length == 0)
            {
                lblStrength.Visible = false;
                return;
            }
            else if (pwd.Length < 6)
            {
                // Less than 6 characters — Weak password
                lblStrength.Text = "● Weak";
                lblStrength.ForeColor = System.Drawing.Color.Red;
            }
            else if (Regex.IsMatch(pwd, "[A-Z]") &&
                     Regex.IsMatch(pwd, "[0-9]"))
            {
                // Contains uppercase letter and number — Strong password
                lblStrength.Text = "● Strong";
                lblStrength.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                // 6+ characters but missing uppercase or number — Medium
                lblStrength.Text = "● Medium";
                lblStrength.ForeColor = System.Drawing.Color.Orange;
            }

            lblStrength.Visible = true;
        }
    }
}