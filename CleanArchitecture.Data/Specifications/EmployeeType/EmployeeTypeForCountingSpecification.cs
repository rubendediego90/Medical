using CleanArchitecture.Domain.Model;
namespace CleanArchitecture.Infrastructure.Specifications.EmployeeTypes

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
