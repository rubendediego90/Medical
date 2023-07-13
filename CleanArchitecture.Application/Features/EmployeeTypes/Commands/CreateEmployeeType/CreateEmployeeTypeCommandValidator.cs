using FluentValidation;

namespace CleanArchitecture.Application.Features.EmployeeTypes.Commands.CreateEmployeeType
{
    public class CreateEmployeeTypeCommandValidator : AbstractValidator<CreateEmployeeTypeCommandRequest>
    {
        public CreateEmployeeTypeCommandValidator()
        {
            RuleFor(p => p.DEmployeeType)
                .NotEmpty().WithMessage("{DEmployeeType} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{DEmployeeType} no puede exceder los 50 caracteres");
        }
    }
}
