using FluentValidation;
using MediatR;
using OnionArchitecture.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Behaviours
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any()) return await next();

            var validationContext = new ValidationContext<TRequest>(request);
            var validationErrors = new List<string>();

            foreach (var validator in _validators)
            {
                var validationResult = await validator.ValidateAsync(validationContext, cancellationToken);

                if (!validationResult.IsValid)
                {
                    validationErrors.AddRange(validationResult.Errors.Select(error => error.ErrorMessage));
                }
            }

            if (validationErrors.Any())
            {
                throw new BadRequestException(validationErrors.ToArray());
            }

            return await next();
        }
    }
}
