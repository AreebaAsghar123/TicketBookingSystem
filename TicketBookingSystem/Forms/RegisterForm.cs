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
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirm.Text.Trim();

            if (string.IsNullOrEmpty(name))
            { lblError.Text = "⚠ Naam bharein!"; lblError.Visible = true; return; }

            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            { lblError.Text = "⚠ Valid email bharein!"; lblError.Visible = true; return; }

            if (string.IsNullOrEmpty(phone) || phone.Length < 10)
            { lblError.Text = "⚠ Valid phone number bharein!"; lblError.Visible = true; return; }

            if (password.Length < 6)
            { lblError.Text = "⚠ Password 6 characters ka hona chahiye!"; lblError.Visible = true; return; }

            if (password != confirm)
            { lblError.Text = "⚠ Passwords match nahi kar rahe!"; lblError.Visible = true; return; }

            bool success = DatabaseHelper.RegisterUser(name, email, phone, password);
            if (success)
            {
                MessageBox.Show("Account ban gaya! 🎉 Ab login karein.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string pwd = txtPassword.Text;
            if (pwd.Length == 0)
            { lblStrength.Visible = false; return; }
            else if (pwd.Length < 6)
            { lblStrength.Text = "● Weak"; lblStrength.ForeColor = System.Drawing.Color.Red; }
            else if (Regex.IsMatch(pwd, "[A-Z]") && Regex.IsMatch(pwd, "[0-9]"))
            { lblStrength.Text = "● Strong"; lblStrength.ForeColor = System.Drawing.Color.Green; }
            else
            { lblStrength.Text = "● Medium"; lblStrength.ForeColor = System.Drawing.Color.Orange; }
            lblStrength.Visible = true;
        }
    }
}
