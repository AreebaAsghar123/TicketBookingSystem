using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Form fields se input lo aur trim karo
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirm.Text.Trim();

            // Naam validation — khali nahi hona chahiye
            if (string.IsNullOrEmpty(name))
            { lblError.Text = "⚠ Naam bharein!"; lblError.Visible = true; return; }

            // Email validation — valid format hona chahiye
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            { lblError.Text = "⚠ Valid email bharein!"; lblError.Visible = true; return; }

            // Phone validation — kam se kam 10 digits hone chahiye
            if (string.IsNullOrEmpty(phone) || phone.Length < 10)
            { lblError.Text = "⚠ Valid phone number bharein!"; lblError.Visible = true; return; }

            // Password validation — minimum 6 characters
            if (password.Length < 6)
            { lblError.Text = "⚠ Password 6 characters ka hona chahiye!"; lblError.Visible = true; return; }

            // Confirm password check — dono passwords match hone chahiye
            if (password != confirm)
            { lblError.Text = "⚠ Passwords match nahi kar rahe!"; lblError.Visible = true; return; }

            // Saari validations pass — database mein user register karo
            bool success = DatabaseHelper.RegisterUser(name, email, phone, password);
            if (success)
            {
                // Registration successful — user ko notify karo aur form band karo
                MessageBox.Show("Account ban gaya! 🎉 Ab login karein.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Registration cancel — form band karo
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string pwd = txtPassword.Text;

            // Password khali ho to strength label hide karo
            if (pwd.Length == 0)
            { lblStrength.Visible = false; return; }

            // Password strength check karo aur label update karo
            else if (pwd.Length < 6)
            {
                // 6 se kam characters — Weak
                lblStrength.Text = "● Weak";
                lblStrength.ForeColor = System.Drawing.Color.Red;
            }
            else if (Regex.IsMatch(pwd, "[A-Z]") && Regex.IsMatch(pwd, "[0-9]"))
            {
                // Capital letter aur number dono hain — Strong
                lblStrength.Text = "● Strong";
                lblStrength.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                // 6+ characters lekin capital ya number missing — Medium
                lblStrength.Text = "● Medium";
                lblStrength.ForeColor = System.Drawing.Color.Orange;
            }

            lblStrength.Visible = true;
        }
    }
}
