using SupportTicketManagement.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTicketManagement.DTOs.TicketDTOs
{
    public class TicketGetDTO
    {
        public int TicketID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }//('OPEN','IN_PROGRESS','RESOLVED','CLOSED')

        public string Priority { get; set; }//('LOW','MEDIUM','HIGH')

        public int CreatedBy { get; set; }

        public int AssignTo { get; set; }

        public DateTime CreatedAt { get; set; } 
    }
}
