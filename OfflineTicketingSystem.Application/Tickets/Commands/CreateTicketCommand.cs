using MediatR;
using OfflineTicketingSystem.Application.Tickets.DTOs;

namespace OfflineTicketingSystem.Application.Tickets.Commands
{
    public record CreateTicketCommand(
        CreateTicketDto Dto,
        Guid UserId
    ) : IRequest<Guid>;
}
