using CleanArchitecture.Application.Features.Authtenfication.Commands.Login;
using CleanArchitecture.Application.IRepositories;
using CleanArchitecture.Domain.Model;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class PersonRepository : RepositoryBase<Person, AutenticationDbContext>,IPersonRepository
    {
        public PersonRepository(AutenticationDbContext context) : base(context)
        {
        }

        public Task<PersonLoginCommandResponse> Login(PersonLoginCommandRequest resquest)
        {
            throw new NotImplementedException();
        }


    }
}
