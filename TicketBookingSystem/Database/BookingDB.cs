using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace TicketBookingSystem.Database
{
    public class BookingDB : BaseRepository
    {
        // BOOKING KARO
        public bool AddBooking(int userId, int ticketId,
            string seatNumber, string passengerName, double fare)
        {
            string sql = @"INSERT INTO Bookings
                          (UserID, TicketID, SeatNumber, PassengerName,
                          BookingDate, Status, TotalFare)
                          VALUES
                          (@uid, @tid, @seat, @name, @date, 'Active', @fare)";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@uid", userId),
                new SQLiteParameter("@tid", ticketId),
                new SQLiteParameter("@seat", seatNumber),
                new SQLiteParameter("@name", passengerName),
                new SQLiteParameter("@date",
                    DateTime.Now.ToString("yyyy-MM-dd")),
                new SQLiteParameter("@fare", fare)
            };

            return ExecuteNonQuery(sql, parameters) > 0;
        }

        // USER KI SAARI BOOKINGS LAO
        public List<object[]> GetUserBookings(int userId)
        {
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

        // BOOKING CANCEL KARO
        public bool CancelBooking(int bookingId)
        {
            string sql = @"UPDATE Bookings 
                          SET Status = 'Cancelled'
                          WHERE BookingID = @id";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@id", bookingId)
            };

            return ExecuteNonQuery(sql, parameters) > 0;
        }

        // ADMIN — SAARI BOOKINGS LAO
        public List<object[]> GetAllBookings()
        {
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