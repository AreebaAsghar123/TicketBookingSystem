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
            DatabaseHelper.InitializeDatabase();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "⚠ Email aur Password dono bharein!";
                lblError.Visible = true;
                return;
            }

            User user = DatabaseHelper.LoginUser(email, password);

            if (user != null)
            {
                Session.CurrentUser = user;
                lblError.Visible = false;
                MainDashboard dashboard = new MainDashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                lblError.Text = "⚠ Email or Password is not valid!";
                lblError.Visible = true;
                txtPassword.Clear();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm reg = new RegisterForm();
            reg.ShowDialog();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
