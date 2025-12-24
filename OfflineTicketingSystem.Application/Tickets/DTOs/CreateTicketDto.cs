using OfflineTicketingSystem.Domain.Enums;

namespace OfflineTicketingSystem.Application.Tickets.DTOs
{
    public class CreateTicketDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public TicketPriority priority { get; set; }
    }
}
