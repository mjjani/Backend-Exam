using SupportTicketManagement.Model;

namespace SupportTicketManagement.DTOs.Login
{
    public class LoginResponseDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public Roles Role { get; set; }
    }
}
