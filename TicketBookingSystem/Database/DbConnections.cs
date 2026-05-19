using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace TicketBookingSystem.Database
{
    public static class DbConnection
    {
        private static string dbPath = Path.Combine(
            Application.StartupPath, "TicketDB.db");

        public static string ConnectionString =>
            $"Data Source={dbPath};Version=3;";

        public static string DbPath => dbPath;

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}