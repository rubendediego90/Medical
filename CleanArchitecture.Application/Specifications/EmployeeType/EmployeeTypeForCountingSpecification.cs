using CleanArchitecture.Application.Specifications;
using CleanArchitecture.Application.Specifications.EmployeeTypes;
using CleanArchitecture.Domain.Model;
namespace Application.Specifications.EmployeeTypes

{
    public class EmployeeTypeForCountingSpecification : BaseSpecification<EmployeeType>
    {
        public EmployeeTypeForCountingSpecification(EmployeeTypeSpecificationParams employeeTypeParams)
            : base(x =>
                    (string.IsNullOrEmpty(employeeTypeParams.DEmployeeType) || x.DEmployeeType!.Contains(employeeTypeParams.DEmployeeType))
             )
        {
        }
    }
}
