using System;
using System.Windows.Forms;
using TicketBookingSystem.Database;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            // Application start hone par database initialize karo
            DatabaseHelper.InitializeDatabase();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validate karo ke email aur password khali nahi hain
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "⚠ Email aur Password dono bharein!";
                lblError.Visible = true;
                return;
            }

            // Database se user authenticate karo
            User user = DatabaseHelper.LoginUser(email, password);

            if (user != null)
            {
                // Successful login — session set karo aur dashboard open karo
                Session.CurrentUser = user;
                lblError.Visible = false;
                MainDashboard dashboard = new MainDashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                // Invalid credentials — error dikhao aur password clear karo
                lblError.Text = "⚠ Email or Password is not valid!";
                lblError.Visible = true;
                txtPassword.Clear();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Registration form ko modal dialog ke tor par open karo
            RegisterForm reg = new RegisterForm();
            reg.ShowDialog();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Checkbox ki state ke mutabiq password show/hide karo
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Login form band hone par poori application exit karo
            Application.Exit();
        }
    }
}
