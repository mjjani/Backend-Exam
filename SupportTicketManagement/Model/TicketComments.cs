using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTicketManagement.Model
{
    public class TicketComments
    {
        [Key]
        public int CommentID {  get; set; }

        [Required]
        [ForeignKey(nameof(Tickets))]
        public int TicketID { get; set; }
        public Tickets? Ticket { get; set; }

        [Required]
        [ForeignKey(nameof(Users))]
        public int UserID { get; set; }
        public Users? User { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
