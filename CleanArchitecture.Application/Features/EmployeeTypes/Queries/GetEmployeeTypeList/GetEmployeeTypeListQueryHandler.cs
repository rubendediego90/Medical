using AutoMapper;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Domain.Model;
using CleanArchitecture.Infrastructure.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetEmployeeTypeListQueryHandler : IRequestHandler<GetEmployeeTypeListQueryRequest, List<GetEmployeeTypeListQueryResponse>>
    {
        private readonly IBaseRepository<EmployeeType, EmployeeDbContext> _employeeTypeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeTypeListQueryHandler(IBaseRepository<EmployeeType, EmployeeDbContext> employeeRepository, IMapper mapper)
        {
            _employeeTypeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetEmployeeTypeListQueryResponse>> Handle(GetEmployeeTypeListQueryRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<EmployeeType> videoList = _employeeTypeRepository.GetAsNoTracking();

            var a = videoList.ToList();

            return _mapper.Map<List<GetEmployeeTypeListQueryResponse>>(a);
        }
    }
}
