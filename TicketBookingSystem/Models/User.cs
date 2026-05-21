namespace TicketBookingSystem.Models
{
    /// <summary>
    /// User model — stores information of the logged-in user
    /// Used throughout the application via Session class
    /// </summary>
    public class User
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Role defines access level — "Passenger" or "Admin"
        public string Role { get; set; }

        // Returns true if the user has Admin role
        public bool IsAdmin => Role == "Admin";
    }
}