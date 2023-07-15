using CleanArchitecture.Application.Pagination;
using MediatR;

namespace CleanArchitecture.Application.Features.EmployeeTypes.Queries.GetEmployeeTypesList
{
    public class GetEmployeeTypeListQueryRequest : PaginationBaseQuery, IRequest<PaginationVm<GetEmployeeTypeListQueryResponse>>
    {
        public string? DEmployeeType { get; set; }

    }
}


