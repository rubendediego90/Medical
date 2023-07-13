using FluentValidation;

namespace CleanArchitecture.Application.Features.EmployeeTypes.Commands.UpdateEmployeeType
{
    public class UpdateEmployeeTypeCommandValidator : AbstractValidator<UpdateEmployeeTypeCommandRequest>
    {
        public UpdateEmployeeTypeCommandValidator()
        {
            RuleFor(p => p.DEmployeeType)
                .NotNull().WithMessage("{DEmployeeType} no permite valores nulos");

        }
    }
}
