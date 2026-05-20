using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace TicketBookingSystem.Database
{
    /// <summary>
    /// Booking related database operations — Add, Get, Cancel
    /// </summary>
    public class BookingDB : BaseRepository
    {
        /// <summary>
        /// Naya booking record database mein save karta hai
        /// </summary>
        public bool AddBooking(int userId, int ticketId,
            string seatNumber, string passengerName, double fare)
        {
            // Booking status default 'Active' set hoti hai
            string sql = @"INSERT INTO Bookings
                          (UserID, TicketID, SeatNumber, PassengerName,
                          BookingDate, Status, TotalFare)
                          VALUES
                          (@uid, @tid, @seat, @name, @date, 'Active', @fare)";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@uid",  userId),
                new SQLiteParameter("@tid",  ticketId),
                new SQLiteParameter("@seat", seatNumber),
                new SQLiteParameter("@name", passengerName),
                new SQLiteParameter("@date",
                    DateTime.Now.ToString("yyyy-MM-dd")),
                new SQLiteParameter("@fare", fare)
            };

            return ExecuteNonQuery(sql, parameters) > 0;
        }

        /// <summary>
        /// Specific user ki saari bookings laata hai
        /// Latest booking pehle dikhata hai
        /// </summary>
        public List<object[]> GetUserBookings(int userId)
        {
            // Tickets aur Routes se JOIN karke poori detail laata hai
            string sql = @"SELECT b.BookingID, r.Source, r.Destination,
                          t.DepartureDate, t.DepartureTime,
                          b.SeatNumber, b.TotalFare, b.Status
                          FROM Bookings b
                          JOIN Tickets t ON b.TicketID = t.TicketID
                          JOIN Routes r ON t.RouteID = r.RouteID
                          WHERE b.UserID = @uid
                          ORDER BY b.BookingDate DESC";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@uid", userId)
            };

            var list = new List<object[]>();
            using (var reader = ExecuteReader(sql, parameters))
            {
                while (reader.Read())
                {
                    list.Add(new object[] {
                        reader[0], reader[1], reader[2],
                        reader[3], reader[4], reader[5],
                        reader[6], reader[7]
                    });
                }
            }
            return list;
        }

        /// <summary>
        /// Booking cancel karta hai — Status 'Cancelled' set karta hai
        /// </summary>
        public bool CancelBooking(int bookingId)
        {
            // Booking delete nahi karte — sirf status update karte hain
            string sql = @"UPDATE Bookings 
                          SET Status = 'Cancelled'
                          WHERE BookingID = @id";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@id", bookingId)
            };

            return ExecuteNonQuery(sql, parameters) > 0;
        }

        /// <summary>
        /// Admin ke liye saari bookings laata hai — sabhi users ki
        /// </summary>
        public List<object[]> GetAllBookings()
        {
            // Users, Tickets aur Routes teeno se JOIN kiya hai
            string sql = @"SELECT b.BookingID, u.FullName,
                          r.Source, r.Destination,
                          t.DepartureDate, b.SeatNumber,
                          b.TotalFare, b.Status
                          FROM Bookings b
                          JOIN Users u ON b.UserID = u.UserID
                          JOIN Tickets t ON b.TicketID = t.TicketID
                          JOIN Routes r ON t.RouteID = r.RouteID
                          ORDER BY b.BookingDate DESC";

            var list = new List<object[]>();
            using (var reader = ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    list.Add(new object[] {
                        reader[0], reader[1], reader[2],
                        reader[3], reader[4], reader[5],
                        reader[6], reader[7]
                    });
                }
            }
            return list;
        }
    }
}