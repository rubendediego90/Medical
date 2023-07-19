using AutoMapper;
using CleanArchitecture.Domain.BaseRepository;
using CleanArchitecture.Domain.Model;
using CleanArchitecture.Infrastructure.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommandRequest, int?>
    {
        private readonly IBaseRepository<Person, AutenticationDbContext> _personRepository;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IBaseRepository<Person, AutenticationDbContext> personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<int?> Handle(CreatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            Person PersonEntity = _mapper.Map<Person>(request);

            Person? newPerson = await _personRepository.Add(PersonEntity);

            return newPerson != null ? newPerson!.Id : null;

        }
    }
}
