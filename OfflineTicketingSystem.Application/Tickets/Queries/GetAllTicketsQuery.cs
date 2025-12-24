using MediatR;
using OfflineTicketingSystem.Application.Tickets.DTOs;

namespace OfflineTicketingSystem.Application.Tickets.Queries
{
    public record GetAllTicketsQuery() : IRequest<List<TicketResponseDto>>;
}
