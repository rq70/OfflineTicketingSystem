using OfflineTicketingSystem.Domain.Enums;

namespace OfflineTicketingSystem.Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null;
        public string Description { get; set; } = null;
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; } = null;
        public Guid? AssignedToUserId { get; set; }
        public User? AssignedToUser { get; set; }
    }
}
