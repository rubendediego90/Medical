using System.Linq.Expressions;
using CleanArchitecture.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity, TContext> : IBaseRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        protected readonly TContext _context;

        public RepositoryBase(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>?> AddList(List<TEntity> listItems)
        {
            await _context.Set<TEntity>().AddRangeAsync(listItems);
            await _context.SaveChangesAsync();
            return listItems;
        }

        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRange(List<TEntity> listItems)
        {
            _context.Set<TEntity>().UpdateRange(listItems);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Where(expression);
        }

        public IQueryable<TEntity> GetAsNoTracking(Expression<Func<TEntity, bool>> expression)
        {
            return Get(expression).AsNoTracking();
        }

        public IQueryable<TEntity> GetAsNoTracking()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity?> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        /*public async Task<PagedResult<T>> GetPaginatedGenericList(DtoListFiltersBase dtoListFiltersBase, IQueryable<T> func)
        {
            int num = await func.CountAsync();
            if (!dtoListFiltersBase.CurrentPage.HasValue)
            {
                dtoListFiltersBase.CurrentPage = 1;
            }

            if (!dtoListFiltersBase.PageSize.HasValue)
            {
                dtoListFiltersBase.PageSize = ((num <= 0) ? 1 : num);
            }

            return func.PageResult(dtoListFiltersBase.CurrentPage.Value, dtoListFiltersBase.PageSize.Value, num);
        }*/

    }
}
