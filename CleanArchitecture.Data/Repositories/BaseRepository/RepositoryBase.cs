using System.Linq.Expressions;
using CleanArchitecture.Domain.BaseRepository;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Specifications;
using CleanArchitecture.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class RepositoryBase<T, TContext> : IBaseRepository<T, TContext> where T : BaseDomainModel where TContext : DbContext
    {
        protected readonly TContext _context;

        public RepositoryBase(TContext context)
        {
            _context = context;
        }

        public async Task<T?> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>?> AddList(List<T> listItems)
        {
            await _context.Set<T>().AddRangeAsync(listItems);
            await _context.SaveChangesAsync();
            return listItems;
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRange(List<T> listItems)
        {
            _context.Set<T>().UpdateRange(listItems);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IQueryable<T> GetAsNoTracking(Expression<Func<T, bool>> expression)
        {
            return Get(expression).AsNoTracking();
        }

        public IQueryable<T> GetAsNoTracking()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByIdWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public IQueryable<T> GetAllWithSpec(ISpecification<T> spec)
        {
            return ApplySpecification(spec);
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<PaginationData> GetPaginationWithSpec(ISpecification<T> spec, int pageIndex, int pageSize)
        {
            int total = await ApplySpecification(spec).CountAsync();
            decimal rounded = Math.Ceiling(Convert.ToDecimal(total) / Convert.ToDecimal(pageSize));
            int totalPages = Convert.ToInt32(rounded);
            return new PaginationData()
            {
                Count = await ApplySpecification(spec).CountAsync(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageCount = totalPages
            };
        }

        public IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

        public async Task<bool> CheckExistence(Expression<Func<T,bool>> expresion)
        {
            return await _context.Set<T>().AnyAsync(expresion);
        }

    }
}
