using OfflineTicketingSystem.Domain.Enums;

namespace OfflineTicketingSystem.Application.Tickets.DTOs
{
    public class TicketResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public TicketStatus status { get; set; }
        public TicketPriority priority { get; set; }
        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;
        public string? AssignedTo { get; set;}
    }
}
