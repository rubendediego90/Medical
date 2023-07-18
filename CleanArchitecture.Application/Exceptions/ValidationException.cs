using FluentValidation.Results;

namespace CleanArchitecture.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }

        public ValidationException(IEnumerable<string> errors) : base("Se produjeron uno o más errores de validación.")
        {
            Errors = errors.ToList();
        }

        public List<string>? Errors { get; }
    }
}
