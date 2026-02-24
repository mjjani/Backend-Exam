using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SupportTicketManagement.Model
{
    public class Tickets
    {
        [Key]
        public int TicketID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Status { get; set; }//('OPEN','IN_PROGRESS','RESOLVED','CLOSED')
        [Required]    
        public string Priority { get; set; }//('LOW','MEDIUM','HIGH')

        [ForeignKey(nameof(CreatedBy))]
        public int CreatedBy { get; set; }

        [ForeignKey(nameof(AssignTo))]
        public int AssignTo { get; set; }
        public Users? User { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<TicketStatusLogs> TicketStatusLogs { get; set; } = new List<TicketStatusLogs>();
        public ICollection<TicketComments> TicketComments { get; set; } = new List<TicketComments>();


    }
}
