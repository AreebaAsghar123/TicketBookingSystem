using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace TicketBookingSystem.Database
{
    /// <summary>
    /// DbConnection Class — Database connection manage karta hai
    /// Poori application mein yahi ek jagah se connection milta hai
    /// </summary>
    public static class DbConnection
    {
        // Database file ka path — application folder mein TicketDB.db
        private static string dbPath = Path.Combine(
            Application.StartupPath, "TicketDB.db");

        /// <summary>
        /// SQLite connection string — database file ka path contain karta hai
        /// </summary>
        public static string ConnectionString =>
            $"Data Source={dbPath};Version=3;";

        /// <summary>
        /// Database file ka poora path return karta hai
        /// </summary>
        public static string DbPath => dbPath;

        /// <summary>
        /// Naya SQLite connection open karke return karta hai
        /// Har database operation se pehle yeh call hota hai
        /// </summary>
        public static SQLiteConnection GetConnection()
        {
            // Naya connection banao aur open karo
            var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}