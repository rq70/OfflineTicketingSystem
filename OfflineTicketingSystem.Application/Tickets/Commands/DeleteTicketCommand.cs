using MediatR;
using OfflineTicketingSystem.Application.Tickets.DTOs;

namespace OfflineTicketingSystem.Application.Tickets.Commands
{
    public record DeleteTicketCommand(Guid Id) : IRequest<String>;
}
