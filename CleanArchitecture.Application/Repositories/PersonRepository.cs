using CleanArchitecture.Application.Features.Authtenfication.Commands.Login;
using CleanArchitecture.Application.IRepositories;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Model;
using CleanArchitecture.Domain.Specifications;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public Task<Person?> Add(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>?> AddList(List<Person> listItems)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Person> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Person> Get(Expression<Func<Person, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Person> GetAllWithSpec(ISpecification<Person> spec)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Person>> GetAllWithSpecAsync(ISpecification<Person> spec)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Person> GetAsNoTracking()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Person> GetAsNoTracking(Expression<Func<Person, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Person?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person?> GetByIdWithSpec(ISpecification<Person> spec)
        {
            throw new NotImplementedException();
        }

        public Task<PaginationData> GetPaginationWithSpec(ISpecification<Person> spec, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<PersonLoginCommandResponse> Login(PersonLoginCommandRequest resquest)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRange(List<Person> listItems)
        {
            throw new NotImplementedException();
        }
    }
}
