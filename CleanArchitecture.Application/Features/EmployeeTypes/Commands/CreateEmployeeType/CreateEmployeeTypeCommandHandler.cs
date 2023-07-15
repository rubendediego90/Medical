using AutoMapper;
using CleanArchitecture.Domain.Model;
using CleanArchitecture.Infrastructure.IRepositories;
using CleanArchitecture.Infrastructure.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.EmployeeTypes.Commands.CreateEmployeeType
{
    public class CreateEmployeeTypeCommandHandler : IRequestHandler<CreateEmployeeTypeCommandRequest, int>
    {
        private readonly IBaseRepository<EmployeeType, EmployeeDbContext> _employeeTypeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeTypeCommandHandler(IBaseRepository<EmployeeType, EmployeeDbContext> employeeRepository, IMapper mapper)
        {
            _employeeTypeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEmployeeTypeCommandRequest request, CancellationToken cancellationToken)
        {
            EmployeeType employeeTypeEntity = _mapper.Map<EmployeeType>(request);
            EmployeeType newEmployeeType = await _employeeTypeRepository.Add(employeeTypeEntity);

            return newEmployeeType.Id;
        }

    }
}
