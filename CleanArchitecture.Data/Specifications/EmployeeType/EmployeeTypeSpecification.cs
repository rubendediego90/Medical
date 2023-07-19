using CleanArchitecture.Domain.Model;

namespace CleanArchitecture.Infrastructure.Specifications.EmployeeTypes
{
    public class EmployeeTypeSpecification : BaseSpecification<EmployeeType>
    {
        public EmployeeTypeSpecification(EmployeeTypeSpecificationParams employeeTypeParams)
           : base(
                   x =>
                    (string.IsNullOrEmpty(employeeTypeParams.DEmployeeType) || x.DEmployeeType!.Contains(employeeTypeParams.DEmployeeType))
                 )
        {
            ApplyPaging(employeeTypeParams.PageIndex, employeeTypeParams.PageSize);

            //Se puede refactorizar para usar el orderBy como en el extensión, lo dejo asi por tener dos caminos diferentes
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
