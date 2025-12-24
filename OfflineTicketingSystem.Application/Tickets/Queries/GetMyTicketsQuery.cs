using MediatR;
using OfflineTicketingSystem.Application.Tickets.DTOs;

namespace OfflineTicketingSystem.Application.Tickets.Queries
{
    public record GetMyTicketsQuery(Guid UserId) : IRequest<List<TicketResponseDto>>;
}
