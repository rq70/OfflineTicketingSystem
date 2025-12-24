using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OfflineTicketingSystem.Application.Interfaces;
using OfflineTicketingSystem.Application.Tickets.Commands;
using OfflineTicketingSystem.Domain.Entities;
using OfflineTicketingSystem.Domain.Enums;

namespace OfflineTicketingSystem.Application.Tickets.Handlers
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTicketCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t=>t.Id == request.Id, cancellationToken);
            if (ticket == null) throw new Exception("Ticket Not Found");
            ticket.Status = request.Dto.status;
            ticket.Priority = request.Dto.priority;
            ticket.Description = request.Dto.Description;
            ticket.UpdatedAt = DateTime.UtcNow;

            // چک کردن AssignedToUserId
            if (request.Dto.AssignedToUserId.HasValue)
            {
                var userExists = await _context.Users.AnyAsync(u => u.Id == request.Dto.AssignedToUserId.Value, cancellationToken);
                if (!userExists)
                    throw new Exception("Assigned user does not exist.");

                ticket.AssignedToUserId = request.Dto.AssignedToUserId.Value;
            }
            else
            {
                ticket.AssignedToUserId = null; // اگر ستون nullable باشد
            }

            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
