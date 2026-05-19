namespace TicketBookingSystem.Models
{
    public static class Session
    {
        public static User CurrentUser { get; set; }

        public static void SetUser(User user)
        {
            CurrentUser = user;
        }

        public static void Clear()
        {
            CurrentUser = null;
        }

        public static bool IsAdmin =>
            CurrentUser?.Role == "Admin";
    }
}