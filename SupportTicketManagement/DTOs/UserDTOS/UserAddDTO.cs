namespace SupportTicketManagement.DTOs.UserDTOS
{
    public class UserAddDTO
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleID { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
