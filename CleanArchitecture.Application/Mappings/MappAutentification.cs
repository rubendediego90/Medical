using AutoMapper;
using CleanArchitecture.Application.Features.Persons.Commands.CreatePerson;
using CleanArchitecture.Domain.Model;

namespace CleanArchitecture.Application.Mappings
{
    public class MappAutentification : Profile
    {
        public MappAutentification()
        {
            CreateMap<CreatePersonCommandRequest, Person>();
        }
    }
}
