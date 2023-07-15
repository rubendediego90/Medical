using CleanArchitecture.Application.Pagination;

namespace CleanArchitecture.Application.Specifications.EmployeeTypes
{
    public class EmployeeTypeSpecificationParams : PaginationBaseQuery
    {
        public string? DEmployeeType { get; set; }
    }
}
