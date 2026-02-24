using System.ComponentModel.DataAnnotations;

namespace SupportTicketManagement.Model
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }
        [Required]
        public string RoleName { get; set; }

        public ICollection<Users> Users { get; set; } = new List<Users>();
    }
}
