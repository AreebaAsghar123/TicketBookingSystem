using System;
using System.Data.SQLite;

namespace TicketBookingSystem.Database
{
    public class BaseRepository
    {
        // INSERT, UPDATE, DELETE ke liye
        protected int ExecuteNonQuery(string sql,
            SQLiteParameter[] parameters = null)
        {
            using (var conn = DbConnection.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        // Single value ke liye — jaise COUNT(*)
        protected object ExecuteScalar(string sql,
            SQLiteParameter[] parameters = null)
        {
            using (var conn = DbConnection.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }

        // Multiple rows ke liye
        protected SQLiteDataReader ExecuteReader(string sql,
            SQLiteParameter[] parameters = null)
        {
            var conn = DbConnection.GetConnection();
            var cmd = new SQLiteCommand(sql, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteReader(
                System.Data.CommandBehavior.CloseConnection);
        }
    }
}