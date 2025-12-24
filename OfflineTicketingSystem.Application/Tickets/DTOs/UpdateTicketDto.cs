using OfflineTicketingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Tickets.DTOs
{
    public class UpdateTicketDto
    {
        public TicketStatus status { get; set; }
        public TicketPriority priority { get; set; }
        public String Description { get; set; }
        public Guid? AssignedToUserId { get; set; }
    }
}
