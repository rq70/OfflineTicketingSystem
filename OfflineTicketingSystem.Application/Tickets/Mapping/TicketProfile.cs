using AutoMapper;
using OfflineTicketingSystem.Application.Tickets.DTOs;
using OfflineTicketingSystem.Domain.Entities;

namespace OfflineTicketingSystem.Application.Tickets.Mapping
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<CreateTicketDto, Ticket>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Status, opt => opt.Ignore())
                .ForMember(d => d.CreatedAt, opt => opt.Ignore())
                .ForMember(d => d.UpdatedAt, opt => opt.Ignore())
                .ForMember(d => d.CreatedByUserId, opt => opt.Ignore())
                .ForMember(d => d.AssignedToUserId, opt => opt.Ignore());

            CreateMap<Ticket, TicketResponseDto>()
                .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.CreatedByUser.FullName))
                .ForMember(d => d.AssignedTo, o => o.MapFrom(s => s.AssignedToUser != null ? s.AssignedToUser.FullName : null));
        }
    }
}
