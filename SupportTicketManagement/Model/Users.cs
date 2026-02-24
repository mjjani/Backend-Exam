using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SupportTicketManagement.Model
{
    [Index(nameof(Email), IsUnique = true)]
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [ForeignKey(nameof(Role))]
        public int RoleID { get; set; }
        public Roles? Role {  get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Tickets> Tickets { get; set; } = new List<Tickets>();
        public ICollection<TicketStatusLogs> TicketStatusLogs { get; set; } = new List<TicketStatusLogs>();
        public ICollection<TicketComments> TicketComments { get; set; } = new List<TicketComments>();


    }
}
