using FluentValidation;
using OfflineTicketingSystem.Application.Tickets.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Tickets.Validators
{
    public class CreateTicketValidator : AbstractValidator<CreateTicketDto>
    {
        public CreateTicketValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x=>x.Description).NotEmpty().MaximumLength(1000);
            RuleFor(x => x.priority).IsInEnum();
        }
    }
}
