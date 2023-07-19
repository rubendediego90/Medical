using CleanArchitecture.Infrastructure.Pagination;

namespace CleanArchitecture.Infrastructure.Specifications.EmployeeTypes
{
    public class EmployeeTypeSpecificationParams : PaginationBaseQuery
    {
        public string? DEmployeeType { get; set; }
    }
}
