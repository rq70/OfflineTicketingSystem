using System.ComponentModel.DataAnnotations.Schema;
using OfflineTicketingSystem.Domain.Enums;

namespace OfflineTicketingSystem.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public Role Role {  get; set; }

        [NotMapped]
        public ICollection<Ticket> CreatedTickets { get; set; } = new List<Ticket>();
        [NotMapped]
        public ICollection<Ticket> AssignedTickets { get; set; } = new List<Ticket>();
    }
}
