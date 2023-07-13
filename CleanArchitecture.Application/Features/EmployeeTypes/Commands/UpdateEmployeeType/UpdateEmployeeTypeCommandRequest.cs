using MediatR;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Application.Features.EmployeeTypes.Commands.UpdateEmployeeType
{
    public  class UpdateEmployeeTypeCommandRequest : IRequest 
    {
        public int Id { get; set; }

        public string DEmployeeType { get; set; }

    }
}
