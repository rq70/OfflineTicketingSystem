using Microsoft.EntityFrameworkCore;
using OfflineTicketingSystem.Domain.Entities;

namespace OfflineTicketingSystem.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Ticket> Tickets { get; }
        DbSet<User> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
