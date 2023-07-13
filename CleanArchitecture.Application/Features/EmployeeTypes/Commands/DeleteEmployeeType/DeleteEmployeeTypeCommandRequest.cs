using MediatR;

namespace CleanArchitecture.Application.Features.EmployeeTypes.Commands.DeleteEmployeeType
{
    public class DeleteEmployeeTypeCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
