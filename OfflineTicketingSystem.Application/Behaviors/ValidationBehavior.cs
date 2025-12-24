using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TRespone> : IPipelineBehavior<TRequest, TRespone>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TRespone> Handle(TRequest request, RequestHandlerDelegate<TRespone> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var failures = _validators.Select(v=>v.Validate(context))
                    .SelectMany(r=>r.Errors)
                    .Where(f=>f != null)
                    .ToList();

                if(failures.Count != 0) throw new ValidationException(failures);
            }
            return await next();
        }
    }
}
