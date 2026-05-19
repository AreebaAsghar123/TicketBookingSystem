using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Database
{
    /// <summary>
    /// Handles all database operations — connection, creation, queries
    /// </summary>
    public static class DatabaseHelper
    {
        // Database file ka path — exe ke saath same folder mein
        private static string dbPath = Path.Combine(
            Application.StartupPath, "TicketDB.db");

        private static string ConnectionString =>
            $"Data Source={dbPath};Version=3;";

        // ─────────────────────────────────────────────────────────────
        // DATABASE INITIALIZE KARO — app start hone par call hoti hai
        // ─────────────────────────────────────────────────────────────
        public static void InitializeDatabase()
        {
            try
            {
                // Agar db file nahi hai to banao
                if (!File.Exists(dbPath))
                    SQLiteConnection.CreateFile(dbPath);

                using (var conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();
                    CreateTables(conn);
                    InsertDefaultAdmin(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // TABLES BANAO
        // ─────────────────────────────────────────────────────────────
        private static void CreateTables(SQLiteConnection conn)
        {
            string createUsers = @"
                CREATE TABLE IF NOT EXISTS Users (
                    UserID      INTEGER PRIMARY KEY AUTOINCREMENT,
                    FullName    TEXT NOT NULL,
                    Email       TEXT NOT NULL UNIQUE,
                    Phone       TEXT NOT NULL,
                    Password    TEXT NOT NULL,
                    Role        TEXT NOT NULL DEFAULT 'Passenger',
                    CreatedDate TEXT NOT NULL
                );";

            string createRoutes = @"
                CREATE TABLE IF NOT EXISTS Routes (
                    RouteID     INTEGER PRIMARY KEY AUTOINCREMENT,
                    Source      TEXT NOT NULL,
                    Destination TEXT NOT NULL,
                    Distance    REAL,
                    Duration    TEXT,
                    Category    TEXT NOT NULL
                );";

            string createTickets = @"
                CREATE TABLE IF NOT EXISTS Tickets (
                    TicketID        INTEGER PRIMARY KEY AUTOINCREMENT,
                    RouteID         INTEGER NOT NULL,
                    DepartureDate   TEXT NOT NULL,
                    DepartureTime   TEXT NOT NULL,
                    TotalSeats      INTEGER NOT NULL,
                    AvailableSeats  INTEGER NOT NULL,
                    Fare            REAL NOT NULL,
                    Company         TEXT NOT NULL,
                    FOREIGN KEY (RouteID) REFERENCES Routes(RouteID)
                );";

            string createBookings = @"
                CREATE TABLE IF NOT EXISTS Bookings (
                    BookingID       INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserID          INTEGER NOT NULL,
                    TicketID        INTEGER NOT NULL,
                    SeatNumber      TEXT NOT NULL,
                    PassengerName   TEXT NOT NULL,
                    BookingDate     TEXT NOT NULL,
                    Status          TEXT NOT NULL DEFAULT 'Active',
                    TotalFare       REAL NOT NULL,
                    FOREIGN KEY (UserID) REFERENCES Users(UserID),
                    FOREIGN KEY (TicketID) REFERENCES Tickets(TicketID)
                );";

            string createPayments = @"
                CREATE TABLE IF NOT EXISTS Payments (
                    PaymentID       INTEGER PRIMARY KEY AUTOINCREMENT,
                    BookingID       INTEGER NOT NULL,
                    Amount          REAL NOT NULL,
                    PaymentMethod   TEXT NOT NULL,
                    PaymentDate     TEXT NOT NULL,
                    Status          TEXT NOT NULL DEFAULT 'Completed',
                    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID)
                );";

            string createFeedback = @"
                CREATE TABLE IF NOT EXISTS Feedback (
                    FeedbackID      INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserID          INTEGER NOT NULL,
                    BookingID       INTEGER NOT NULL,
                    Rating          INTEGER NOT NULL,
                    Comments        TEXT,
                    SubmittedDate   TEXT NOT NULL
                );";

            // Execute all CREATE TABLE statements
            foreach (string sql in new[] {
                createUsers, createRoutes, createTickets,
                createBookings, createPayments, createFeedback })
            {
                using (var cmd = new SQLiteCommand(sql, conn))
                    cmd.ExecuteNonQuery();
            }
        }

        // ─────────────────────────────────────────────────────────────
        // DEFAULT ADMIN INSERT KARO (sirf ek baar)
        // ─────────────────────────────────────────────────────────────
        private static void InsertDefaultAdmin(SQLiteConnection conn)
        {
            string check = "SELECT COUNT(*) FROM Users WHERE Role='Admin'";
            using (var cmd = new SQLiteCommand(check, conn))
            {
                long count = (long)cmd.ExecuteScalar();
                if (count == 0)
                {
                    string insert = @"
                        INSERT INTO Users (FullName, Email, Phone, Password, Role, CreatedDate)
                        VALUES ('Admin', 'admin@ticketsystem.com', '0300-0000000',
                                'Admin@123', 'Admin', @date)";
                    using (var cmd2 = new SQLiteCommand(insert, conn))
                    {
                        cmd2.Parameters.AddWithValue("@date",
                            DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd2.ExecuteNonQuery();
                    }

                    // Sample routes bhi add karo
                    InsertSampleData(conn);
                }
            }
        }

        // ─────────────────────────────────────────────────────────────
        // SAMPLE DATA
        // ─────────────────────────────────────────────────────────────
        private static void InsertSampleData(SQLiteConnection conn)
        {
            // Routes
            string[] routes = {
                "INSERT INTO Routes VALUES (NULL,'Faisalabad','Lahore',180,'2h 30min','Bus')",
                "INSERT INTO Routes VALUES (NULL,'Faisalabad','Islamabad',320,'4h 00min','Bus')",
                "INSERT INTO Routes VALUES (NULL,'Lahore','Karachi',1200,'14h 00min','Train')",
                "INSERT INTO Routes VALUES (NULL,'Faisalabad','Multan',280,'3h 30min','Bus')",
                "INSERT INTO Routes VALUES (NULL,'Lahore','Islamabad',380,'4h 30min','Train')",
            };

            // Tickets
            string[] tickets = {
                "INSERT INTO Tickets VALUES (NULL,1,'2026-05-15','08:00 AM',40,40,800,'Daewoo Express')",
                "INSERT INTO Tickets VALUES (NULL,1,'2026-05-15','02:00 PM',40,35,800,'Daewoo Express')",
                "INSERT INTO Tickets VALUES (NULL,2,'2026-05-16','07:00 AM',44,44,1200,'Faisal Movers')",
                "INSERT INTO Tickets VALUES (NULL,3,'2026-05-17','06:00 PM',200,180,2500,'Pakistan Railways')",
                "INSERT INTO Tickets VALUES (NULL,4,'2026-05-18','09:00 AM',40,40,900,'Bilal Travels')",
                "INSERT INTO Tickets VALUES (NULL,5,'2026-05-19','05:30 PM',200,150,1800,'Pakistan Railways')",
            };

            foreach (string sql in routes)
                using (var cmd = new SQLiteCommand(sql, conn))
                    cmd.ExecuteNonQuery();

            foreach (string sql in tickets)
                using (var cmd = new SQLiteCommand(sql, conn))
                    cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────────────────────
        // CONNECTION RETURN KARO (baaki classes use karengi)
        // ─────────────────────────────────────────────────────────────
        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        // ─────────────────────────────────────────────────────────────
        // USER REGISTER KARO
        // ─────────────────────────────────────────────────────────────
        public static bool RegisterUser(string name, string email,
            string phone, string password)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    // Check duplicate email
                    string check = "SELECT COUNT(*) FROM Users WHERE Email=@email";
                    using (var cmd = new SQLiteCommand(check, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        long exists = (long)cmd.ExecuteScalar();
                        if (exists > 0)
                        {
                            MessageBox.Show(
                                "Yeh email already registered hai!",
                                "Duplicate Email",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    // Insert user
                    string insert = @"
                        INSERT INTO Users
                            (FullName, Email, Phone, Password, Role, CreatedDate)
                        VALUES
                            (@name, @email, @phone, @pass, 'Passenger', @date)";

                    using (var cmd = new SQLiteCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@pass", password);
                        cmd.Parameters.AddWithValue("@date",
                            DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ─────────────────────────────────────────────────────────────
        // USER LOGIN VERIFY KARO
        // ─────────────────────────────────────────────────────────────
        public static User LoginUser(string email, string password)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    string sql = @"
                        SELECT UserID, FullName, Email, Phone, Role
                        FROM Users
                        WHERE Email=@email AND Password=@pass";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@pass", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    UserID   = reader.GetInt32(0),
                                    FullName = reader.GetString(1),
                                    Email    = reader.GetString(2),
                                    Phone    = reader.GetString(3),
                                    Role     = reader.GetString(4)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null; // login fail
        }
    }
}
