using AutoMapper;
using MediatR;
using OfflineTicketingSystem.Application.Interfaces;
using OfflineTicketingSystem.Application.Tickets.Commands;
using OfflineTicketingSystem.Domain.Entities;
using OfflineTicketingSystem.Domain.Enums;

namespace OfflineTicketingSystem.Application.Tickets.Handlers
{
    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, String>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public DeleteTicketCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<String> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = _context.Tickets.Find(request.Id);

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync(cancellationToken);
            return "Ok";
        }
    }
}
