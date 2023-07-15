using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Extensions
{
    public static class QueryExtension
    {
        public static IQueryable<T> ApplyQueryFilters<T>(this IQueryable<T> query, List<Expression<Func<T, bool>>> filters)
        {
            foreach (Expression<Func<T, bool>> filter in filters)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string? fieldOrderBy, bool? orderByDescending)
        {
            if (!string.IsNullOrEmpty(fieldOrderBy))
            {
                string text = ((orderByDescending.HasValue && orderByDescending.Value) ? "descending" : "ascending");
                query = query.OrderBy(fieldOrderBy + " " + text);
            }

            return query;
        }
    }
}
