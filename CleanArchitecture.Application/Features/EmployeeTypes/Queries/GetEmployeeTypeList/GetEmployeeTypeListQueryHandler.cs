using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Domain.BaseRepository;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Model;
using CleanArchitecture.Infrastructure.Pagination;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Specifications.EmployeeTypes;
using MediatR;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Features.EmployeeTypes.Queries.GetEmployeeTypesList
{
    public class GetEmployeeTypeListQueryHandler : IRequestHandler<GetEmployeeTypeListQueryRequest, Pagination<GetEmployeeTypeListQueryResponse>>
    {
        private readonly IBaseRepository<EmployeeType, EmployeeDbContext> _employeeTypeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeTypeListQueryHandler(IBaseRepository<EmployeeType, EmployeeDbContext> employeeRepository, IMapper mapper)
        {
            _employeeTypeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<Pagination<GetEmployeeTypeListQueryResponse>> Handle(GetEmployeeTypeListQueryRequest request, CancellationToken cancellationToken)
        {
            EmployeeTypeSpecificationParams employeeTypeSpecificationParams = _mapper.Map<EmployeeTypeSpecificationParams>(request);

            /*var sddsds5 = _employeeTypeRepository.GetAsNoTracking()
                                                 .ApplyQueryFilters(GetQueryFilters(request))
                                                 .ProjectTo<GetEmployeeTypeListQueryResponse>(_mapper.ConfigurationProvider)
                                                 .OrderBy("id",true)
                                                 .ToList();//TODO: revisar en asif
            
            */
            IReadOnlyList<GetEmployeeTypeListQueryResponse> items = GetItems(employeeTypeSpecificationParams);
            PaginationData pagination = await GetPagination(employeeTypeSpecificationParams, request);

            Pagination<GetEmployeeTypeListQueryResponse> paginationItems = new()
            {
                PaginationData = pagination,
                Items = items
            };

            return paginationItems;
        }

        private async Task<PaginationData> GetPagination(EmployeeTypeSpecificationParams employeeTypeSpecificationParams, GetEmployeeTypeListQueryRequest request)
        {
            EmployeeTypeForCountingSpecification specCount = new(employeeTypeSpecificationParams);
            return await _employeeTypeRepository.GetPaginationWithSpec(specCount, request.PageIndex, request.PageSize);
        }

        private IReadOnlyList<GetEmployeeTypeListQueryResponse> GetItems(EmployeeTypeSpecificationParams employeeTypeSpecificationParams)
        {
            EmployeeTypeSpecification spec = new(employeeTypeSpecificationParams);
            return _employeeTypeRepository.GetAllWithSpec(spec)
                                          .ProjectTo<GetEmployeeTypeListQueryResponse>(_mapper.ConfigurationProvider)
                                          .ToList();
        }

        private static List<Expression<Func<EmployeeType, bool>>> GetQueryFilters(GetEmployeeTypeListQueryRequest filters)
        {
            List<Expression<Func<EmployeeType, bool>>> queryFilters = new();

            if (filters.DEmployeeType is not null)
            {
                queryFilters.Add(q => q.DEmployeeType != null && filters.DEmployeeType.Contains(q.DEmployeeType));
            }

            return queryFilters;
        }
    }
}
