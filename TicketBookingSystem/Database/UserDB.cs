using System;
using System.Data.SQLite;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Database
{
    /// <summary>
    /// User related database operations — Login aur Register
    /// </summary>
    public class UserDB : BaseRepository
    {
        /// <summary>
        /// User ko email aur password se login karta hai
        /// </summary>
        public User LoginUser(string email, string password)
        {
            string sql = @"SELECT UserID, FullName, Email, Phone, Role
                          FROM Users
                          WHERE Email=@email AND Password=@pass";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@email", email),
                new SQLiteParameter("@pass", password)
            };

            using (var reader = ExecuteReader(sql, parameters))
            {
                if (reader.Read())
                {
                    return new User
                    {
                        UserID = reader.GetInt32(0),
                        FullName = reader.GetString(1),
                        Email = reader.GetString(2),
                        Phone = reader.GetString(3),
                        Role = reader.GetString(4)
                    };
                }
            }
            return null;
        }

        /// <summary>
        /// Naya user register karta hai — duplicate email check karta hai
        /// </summary>
        public bool RegisterUser(string name, string email,
            string phone, string password)
        {
            // Pehle check karo email duplicate to nahi
            string check = "SELECT COUNT(*) FROM Users WHERE Email=@email";
            SQLiteParameter[] checkParams = {
                new SQLiteParameter("@email", email)
            };

            long exists = (long)ExecuteScalar(check, checkParams);
            if (exists > 0) return false;

            // Naya user insert karo
            string sql = @"INSERT INTO Users 
                          (FullName, Email, Phone, Password, Role, CreatedDate)
                          VALUES
                          (@name, @email, @phone, @pass, 'Passenger', @date)";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@name", name),
                new SQLiteParameter("@email", email),
                new SQLiteParameter("@phone", phone),
                new SQLiteParameter("@pass", password),
                new SQLiteParameter("@date",
                    DateTime.Now.ToString("yyyy-MM-dd"))
            };

            return ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}