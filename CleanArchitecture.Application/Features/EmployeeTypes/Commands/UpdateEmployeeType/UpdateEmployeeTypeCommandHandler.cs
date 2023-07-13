using AutoMapper;
using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Domain.Model;
using CleanArchitecture.Infrastructure.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.EmployeeTypes.Commands.UpdateEmployeeType
{
    public class UpdateEmployeeTypeCommandHandler : IRequestHandler<UpdateEmployeeTypeCommandRequest>
    {
        private readonly IBaseRepository<EmployeeType, EmployeeDbContext> _employeeTypeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeTypeCommandHandler(IBaseRepository<EmployeeType, EmployeeDbContext> employeeRepository, IMapper mapper)
        {
            _employeeTypeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEmployeeTypeCommandRequest request, CancellationToken cancellationToken)
        {
            EmployeeType? employeTypeToUpdate =  await _employeeTypeRepository.GetById(request.Id);

            if (employeTypeToUpdate == null)
            {
                // throw new NotFoundException(nameof(Streamer), request.Id);
            }

            _mapper.Map(request, employeTypeToUpdate);

            await _employeeTypeRepository.Update(employeTypeToUpdate);

            return Unit.Value;
        }
    }
}
