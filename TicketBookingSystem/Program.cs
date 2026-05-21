using System;
using System.Windows.Forms;
using TicketBookingSystem.Forms;

namespace TicketBookingSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm()); //  LoginForm 
        }
    }
}
