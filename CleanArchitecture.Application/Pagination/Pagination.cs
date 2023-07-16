using CleanArchitecture.Infrastructure.Pagination;

namespace CleanArchitecture.Application.Pagination
{
    public class Pagination<T> where T : class
    {
        public PaginationData? PaginationData { get; set; }
        public IReadOnlyList<T>? Items { get; set; }
    }
}
