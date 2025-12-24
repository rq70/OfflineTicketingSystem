using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OfflineTicketingSystem.Application.Interfaces;
using OfflineTicketingSystem.Application.Tickets.DTOs;
using OfflineTicketingSystem.Application.Tickets.Queries;

namespace OfflineTicketingSystem.Application.Tickets.Handlers
{
    public class GetMyTicketsQueryHandler : IRequestHandler<GetMyTicketsQuery, List<TicketResponseDto>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetMyTicketsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TicketResponseDto>> Handle(GetMyTicketsQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _context.Tickets
                .Where(t => t.CreatedByUserId == request.UserId)
                .Include(t=>t.CreatedByUser)
                .Include(t=>t.AssignedToUser)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<TicketResponseDto>>(tickets);
        }
    }
}
