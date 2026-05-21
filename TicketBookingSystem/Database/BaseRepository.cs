using System;
using System.Data.SQLite;

namespace TicketBookingSystem.Database
{
    public class BaseRepository
    {
        // for INSERT, UPDATE, DELETE 
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

        // for single value — like COUNT(*)
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

        // for multiple rows
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