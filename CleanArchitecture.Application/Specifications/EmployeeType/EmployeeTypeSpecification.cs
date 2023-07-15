using CleanArchitecture.Application.Specifications;
using CleanArchitecture.Application.Specifications.EmployeeTypes;
using CleanArchitecture.Domain.Model;

namespace Application.Specifications.EmployeeTypes
{
    public class EmployeeTypeSpecification : BaseSpecification<EmployeeType>
    {
        public EmployeeTypeSpecification(EmployeeTypeSpecificationParams employeeTypeParams)
           : base(
                   x =>
                    (string.IsNullOrEmpty(employeeTypeParams.DEmployeeType) || x.DEmployeeType!.Contains(employeeTypeParams.DEmployeeType))
                 )
        {
            ApplyPaging(employeeTypeParams.PageSize * (employeeTypeParams.PageIndex - 1), employeeTypeParams.PageSize);

            if (!string.IsNullOrEmpty(employeeTypeParams.Sort))
            {
                switch (employeeTypeParams.Sort)
                {
                    case "dEmployeeTypeAsc":
                        AddOrderBy(p => p.DEmployeeType!);
                        break;

                    case "dEmployeeTypeDesc":
                        AddOrderByDescending(p => p.DEmployeeType!);
                        break;

                    default:
                        AddOrderBy(p => p.Id!);
                        break;
                }
            }
        }
    }
}
