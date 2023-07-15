using CleanArchitecture.Application.Specifications;
using CleanArchitecture.Application.Specifications.EmployeeTypes;
using CleanArchitecture.Domain.Model;
namespace Application.Specifications.EmployeeTypes

{
    public class EmployeeTypeForCountingSpecification : BaseSpecification<EmployeeType>
    {
        public EmployeeTypeForCountingSpecification(EmployeeTypeSpecificationParams employeeTypeParams)
            : base(x =>
                    (string.IsNullOrEmpty(employeeTypeParams.Search) || x.DEmployeeType!.Contains(employeeTypeParams.Search))
             )
        {
        }
    }
}
