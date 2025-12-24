using OfflineTicketingSystem.Application.Tickets.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Interface
{
    public interface ITicketRepository
    {
        Task createAsync(CreateTicketDto dto, Guid userId);
    }
}
