namespace SupportTicketManagement.DTOs.TicketDTOs
{
    public class TicketAddDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }//('OPEN','IN_PROGRESS','RESOLVED','CLOSED')

        public string Priority { get; set; }//('LOW','MEDIUM','HIGH')

        public int CreatedBy { get; set; }

        public int AssignTo { get; set; }
    }
}
