using CleanArchitecture.Infrastructure.Pagination;
using CleanArchitecture.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.IRepositories
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

        // Task<PagedResult<T>> GetPaginatedGenericList(DtoListFiltersBase dtoListFiltersBase, IQueryable<T> func);

        Task<TEntity?> GetById(int id);

        Task<TEntity?> GetByIdWithSpec(ISpecification<TEntity> spec);

        Task<IReadOnlyList<TEntity>> GetAllWithSpec(ISpecification<TEntity> spec);

        Task<PaginationData> GetPaginationWithSpec(ISpecification<TEntity> spec, int pageIndex, int pageSize);

    }
}
