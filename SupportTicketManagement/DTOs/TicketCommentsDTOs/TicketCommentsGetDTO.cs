using SupportTicketManagement.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTicketManagement.DTOs.TicketCommentsDTOs
{
    public class TicketCommentsGetDTO
    {

        public int CommentID { get; set; }

        public int TicketID { get; set; }

        public int UserID { get; set; }
        public string? User { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } 
    }
}
