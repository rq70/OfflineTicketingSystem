using MediatR;
using OfflineTicketingSystem.Application.Tickets.DTOs;

namespace OfflineTicketingSystem.Application.Tickets.Commands
{
    public record UpdateTicketCommand(
        Guid Id,
        UpdateTicketDto Dto
    ) : IRequest;
}
