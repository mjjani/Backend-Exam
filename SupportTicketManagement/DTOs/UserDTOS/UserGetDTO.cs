using SupportTicketManagement.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTicketManagement.DTOs.UserDTOS
{
    public class UserGetDTO
    {
        
        public int UserID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleID { get; set; }
        public String Role {  get; set; }
        

        public DateTime CreatedAt { get; set; } 
    }
}
