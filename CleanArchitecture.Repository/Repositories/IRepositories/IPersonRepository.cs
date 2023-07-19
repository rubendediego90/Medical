using CleanArchitecture.Application.Features.Authtenfication.Commands.Login;
using CleanArchitecture.Domain.Model;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Repository.IRepositories
{
    public interface IPersonRepository : IBaseRepository<Person, AutenticationDbContext>
    {
        Task<PersonLoginCommandResponse> Login(PersonLoginCommandRequest resquest);
            
    }
}
