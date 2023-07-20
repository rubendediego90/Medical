using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Domain.BaseRepository
{
    public interface IBaseRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        Task<TEntity?> Add(TEntity entity);

        Task<List<TEntity>?> AddList(List<TEntity> listItems);

        Task Update(TEntity entity);

        Task UpdateRange(List<TEntity> listItems);

        Task Remove(TEntity entity);

        IQueryable<TEntity> Get();

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> GetAsNoTracking();

        IQueryable<TEntity> GetAsNoTracking(Expression<Func<TEntity, bool>> expression);

        Task<TEntity?> GetById(int id);

        Task<TEntity?> GetByIdWithSpec(ISpecification<TEntity> spec);

        Task<IReadOnlyList<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> spec);
        IQueryable<TEntity> GetAllWithSpec(ISpecification<TEntity> spec);

        Task<PaginationData> GetPaginationWithSpec(ISpecification<TEntity> spec, int pageIndex, int pageSize);

        Task<bool> CheckExistence(Expression<Func<TEntity, bool>> expresion);

    }
}
