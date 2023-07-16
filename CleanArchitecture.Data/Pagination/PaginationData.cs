namespace CleanArchitecture.Infrastructure.Pagination
{
    public class PaginationData
    {
        public int Count { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }
}
