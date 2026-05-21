using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace TicketBookingSystem.Database
{
    /// <summary>
    /// DbConnection Class — Manages the database connection
    /// Provides a single source of connection throughout the application
    /// </summary>
    public static class DbConnection
    {
        /// Database file path — TicketDB.db located in the application folder
        private static string dbPath = Path.Combine(
            Application.StartupPath, "TicketDB.db");

        /// <summary>
        /// SQLite connection string — contains the path of the database file
        /// </summary>
        public static string ConnectionString =>
            $"Data Source={dbPath};Version=3;";

        /// <summary>
        /// Returns the complete path of the database file
        /// </summary>
        public static string DbPath => dbPath;

        /// <summary>
        /// Opens and returns a new SQLite connection
        /// This is called before every database operation
        /// </summary>
        public static SQLiteConnection GetConnection()
        {
            // Create and open a new connection
            var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}