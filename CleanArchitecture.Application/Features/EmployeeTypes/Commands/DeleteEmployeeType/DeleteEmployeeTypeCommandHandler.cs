using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Domain.Model;
using CleanArchitecture.Infrastructure.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.EmployeeTypes.Commands.DeleteEmployeeType
{
    public class DeleteEmployeeTypeCommandHandler : IRequestHandler<DeleteEmployeeTypeCommandRequest>
    {
        private readonly IBaseRepository<EmployeeType, EmployeeDbContext> _employeeTypeRepository;
        private readonly IMapper _mapper;

        public DeleteEmployeeTypeCommandHandler(IBaseRepository<EmployeeType, EmployeeDbContext> employeeRepository, IMapper mapper)
        {
            _employeeTypeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEmployeeTypeCommandRequest request, CancellationToken cancellationToken)
        {
            EmployeeType? employeeTypeToDelete = await _employeeTypeRepository.GetById(request.Id);
            if (employeeTypeToDelete == null)
            {
                throw new NotFoundException(nameof(EmployeeType), request.Id);      
            }

            await _employeeTypeRepository.Remove(employeeTypeToDelete);
            return Unit.Value;
        }
    }
}
