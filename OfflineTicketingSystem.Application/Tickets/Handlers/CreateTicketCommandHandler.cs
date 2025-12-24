using AutoMapper;
using MediatR;
using OfflineTicketingSystem.Application.Interfaces;
using OfflineTicketingSystem.Application.Tickets.Commands;
using OfflineTicketingSystem.Domain.Entities;
using OfflineTicketingSystem.Domain.Enums;

namespace OfflineTicketingSystem.Application.Tickets.Handlers
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateTicketCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = _mapper.Map<Ticket>(request.Dto);
            ticket.Id = Guid.NewGuid();
            ticket.Status = TicketStatus.Open;
            ticket.CreatedAt = DateTime.UtcNow;
            ticket.UpdatedAt = DateTime.UtcNow;
            ticket.CreatedByUserId = request.UserId;

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync(cancellationToken);
            return ticket.Id;
        }
    }
}
