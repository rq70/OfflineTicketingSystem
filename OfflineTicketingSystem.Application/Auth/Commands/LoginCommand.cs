using MediatR;
using OfflineTicketingSystem.Application.Auth.DTOs;

namespace OfflineTicketingSystem.Application.Auth.Commands
{
    public record LoginCommand
    (
        string Email,
        string Password
    ): IRequest<LoginResponseDto>;
}
