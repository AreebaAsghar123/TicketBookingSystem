namespace TicketBookingSystem.Models
{
    /// <summary>
    /// User model — logged-in user ki info yahan store hogi
    /// </summary>
    public class User
    {
        public int    UserID   { get; set; }
        public string FullName { get; set; }
        public string Email    { get; set; }
        public string Phone    { get; set; }
        public string Role     { get; set; } // "Passenger" or "Admin"

        // Ye property check karta hai ke user Admin hai ya nahi
        public bool IsAdmin => Role == "Admin";
    }

    // ── Session — logged-in user ko poore app mein accessible rakhta hai ──
  
}
