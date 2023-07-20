using AutoMapper;
using CleanArchitecture.Application.IRepositories;
using CleanArchitecture.Domain.Model;
using CleanArchitecture.Infrastructure.Extensions;
using MediatR;

namespace CleanArchitecture.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommandRequest, int?>
    {
        //private readonly IBaseRepository<Person, AutenticationDbContext> _personRepository;
        private readonly IPersonRepository _personRepository;

        
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<int?> Handle(CreatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            Task<bool> existUser = _personRepository.CheckExistence(p => p.Email.ToLower() == request.Email.ToLower());
            //TODO: lanzar error si existe

            request.Password = request.Password.EncryptMd5();

            Person PersonEntity = _mapper.Map<Person>(request);

            Person? newPerson = await _personRepository.Add(PersonEntity);

            return newPerson != null ? newPerson!.Id : null;

        }
    }
}
