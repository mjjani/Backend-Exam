using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTicketManagement.Model
{
    public class TicketStatusLogs
    {
        [Key]
        public int StatusLogID { get; set; }

        [ForeignKey(nameof(Tickets))]
        public int TicketID { get; set; }
        public Tickets? Ticket { get; set; }

        [Required]
        public string OldStatus {  get; set; }

        [Required]
        public string NewStatus { get; set; }

        [ForeignKey(nameof(Users))]
        public int ChangedBy { get; set; }
        public Users? User { get; set; }

        [Required]
        public DateTime ChangedAt { get; set; } = DateTime.Now;

    }
}
