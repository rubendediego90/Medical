using CleanArchitecture.Application.Pagination;
using MediatR;

namespace CleanArchitecture.Application.Features.EmployeeTypes.Queries.GetEmployeeTypesList
{
    public class GetEmployeeTypeListQueryRequest : PaginationBaseQuery, IRequest<Pagination<GetEmployeeTypeListQueryResponse>>
    {
        public string? DEmployeeType { get; set; }

    }
}


