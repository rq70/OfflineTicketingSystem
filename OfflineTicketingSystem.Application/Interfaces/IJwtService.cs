using OfflineTicketingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
