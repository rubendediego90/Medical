using AutoMapper;
using CleanArchitecture.Application.Features.EmployeeTypes.Commands.CreateEmployeeType;
using CleanArchitecture.Application.Features.EmployeeTypes.Commands.UpdateEmployeeType;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Domain.Model;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeType, GetEmployeeTypeListQueryResponse>();
            CreateMap<CreateEmployeeTypeCommandRequest, EmployeeType>();
            CreateMap<UpdateEmployeeTypeCommandRequest, EmployeeType>();

        }
    }
}
