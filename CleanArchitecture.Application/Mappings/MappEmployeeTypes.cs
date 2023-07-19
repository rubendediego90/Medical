using AutoMapper;
using CleanArchitecture.Application.Features.EmployeeTypes.Commands.CreateEmployeeType;
using CleanArchitecture.Application.Features.EmployeeTypes.Commands.UpdateEmployeeType;
using CleanArchitecture.Application.Features.EmployeeTypes.Queries.GetEmployeeTypesList;
using CleanArchitecture.Domain.Model;
using CleanArchitecture.Infrastructure.Specifications.EmployeeTypes;

namespace CleanArchitecture.Application.Mappings
{
    public class MappEmployeeTypes : Profile
    {
        public MappEmployeeTypes()
        {
            CreateMap<EmployeeType, GetEmployeeTypeListQueryResponse>();
            CreateMap<CreateEmployeeTypeCommandRequest, EmployeeType>();
            CreateMap<UpdateEmployeeTypeCommandRequest, EmployeeType>();
            CreateMap<GetEmployeeTypeListQueryRequest, EmployeeTypeSpecificationParams>();
        }
    }
}
