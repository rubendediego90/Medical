using FluentValidation;
using MediatR;


namespace CleanArchitecture.Application.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var errorsList = _validators.Select(x => x.Validate(context))
                                            .SelectMany(x => x.Errors)
                                            .ToList();

                if (errorsList.Any())
                {
                    throw new ValidationException(errorsList);
                }
            }

            return await next();
        }
    }
}
