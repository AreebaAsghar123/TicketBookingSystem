using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace TicketBookingSystem.Database
{
    public class TicketDB : BaseRepository
    {
        // reterive all TICKETS 
        public List<object[]> GetAllTickets()
        {
            string sql = @"SELECT t.TicketID, r.Source, r.Destination,
                          t.DepartureDate, t.DepartureTime,
                          t.AvailableSeats, t.Fare, t.Company,
                          r.Category
                          FROM Tickets t
                          JOIN Routes r ON t.RouteID = r.RouteID";

            var list = new List<object[]>();
            using (var reader = ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    list.Add(new object[] {
                        reader[0], reader[1], reader[2],
                        reader[3], reader[4], reader[5],
                        reader[6], reader[7], reader[8]
                    });
                }
            }
            return list;
        }

        // SEARCH TICKETS
        public List<object[]> SearchTickets(string source,
            string destination, string date)
        {
            string sql = @"SELECT t.TicketID, r.Source, r.Destination,
                          t.DepartureDate, t.DepartureTime,
                          t.AvailableSeats, t.Fare, t.Company
                          FROM Tickets t
                          JOIN Routes r ON t.RouteID = r.RouteID
                          WHERE r.Source=@src 
                          AND r.Destination=@dest
                          AND t.DepartureDate=@date
                          AND t.AvailableSeats > 0";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@src", source),
                new SQLiteParameter("@dest", destination),
                new SQLiteParameter("@date", date)
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

        // UPDATE AVAILABLE SEATS  
        public bool UpdateAvailableSeats(int ticketId)
        {
            string sql = @"UPDATE Tickets 
                          SET AvailableSeats = AvailableSeats - 1
                          WHERE TicketID = @id 
                          AND AvailableSeats > 0";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@id", ticketId)
            };

            return ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}