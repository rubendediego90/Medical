using Application.Specifications.EmployeeTypes;
using AutoMapper;
using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Application.Pagination;
using CleanArchitecture.Application.Specifications.EmployeeTypes;
using CleanArchitecture.Domain.Model;
using CleanArchitecture.Infrastructure.IRepositories;
using CleanArchitecture.Infrastructure.Persistence;
using MediatR;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Features.EmployeeTypes.Queries.GetEmployeeTypesList
{
    public class GetEmployeeTypeListQueryHandler : IRequestHandler<GetEmployeeTypeListQueryRequest, PaginationVm<GetEmployeeTypeListQueryResponse>>
    {
        private readonly IBaseRepository<EmployeeType, EmployeeDbContext> _employeeTypeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeTypeListQueryHandler(IBaseRepository<EmployeeType, EmployeeDbContext> employeeRepository, IMapper mapper)
        {
            _employeeTypeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<PaginationVm<GetEmployeeTypeListQueryResponse>> Handle(GetEmployeeTypeListQueryRequest request, CancellationToken cancellationToken)
        {
            var employeeTypeSpecificationParams = new EmployeeTypeSpecificationParams
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Search = request.Search,
                Sort = request.Sort,
            };
            var spec = new EmployeeTypeSpecification(employeeTypeSpecificationParams);

            var sddsds5 = _employeeTypeRepository.GetAsNoTracking()
                                                 .ApplyQueryFilters(GetQueryFilters(request))
                                                 .OrderBy("id",true);

            var videos = await _employeeTypeRepository.GetAllWithSpec(spec);

            var specCount = new EmployeeTypeForCountingSpecification(employeeTypeSpecificationParams);
            var totalVideos = await _employeeTypeRepository.CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalVideos) / Convert.ToDecimal(request.PageSize));
            var totalPages = Convert.ToInt32(rounded);

            var data = _mapper.Map<IReadOnlyList<EmployeeType>, IReadOnlyList<GetEmployeeTypeListQueryResponse>>(videos);

            var pagination = new PaginationVm<GetEmployeeTypeListQueryResponse>
            {
                Count = totalVideos,
                Data = data,
                PageCount = totalPages,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };

            return pagination;
        }

        private static List<Expression<Func<EmployeeType, bool>>> GetQueryFilters(GetEmployeeTypeListQueryRequest filters)
        {
            var queryFilters = new List<Expression<Func<EmployeeType, bool>>>();

            if (filters.DEmployeeType is not null)
            {
                queryFilters.Add(q => q.DEmployeeType != null && filters.DEmployeeType.Contains(q.DEmployeeType));
            }

            return queryFilters;
        }

        public IQueryable<T> ApplyQueryFilters2<T>(IQueryable<T> query, List<Expression<Func<T, bool>>> filters)
        {
            foreach (Expression<Func<T, bool>> filter in filters)
            {
                query = query.Where(filter);
            }

            return query;
        }
    }

}
