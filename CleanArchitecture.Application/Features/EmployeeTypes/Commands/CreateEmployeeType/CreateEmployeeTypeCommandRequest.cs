using MediatR;
namespace CleanArchitecture.Application.Features.EmployeeTypes.Commands.CreateEmployeeType
{
    public class CreateEmployeeTypeCommandRequest : IRequest<int>
    {
        public string DEmployeeType { get; set; } = null!;

    }
}
