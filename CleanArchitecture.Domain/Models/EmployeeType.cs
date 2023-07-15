using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Model
{
    public partial class EmployeeType : BaseDomainModel
    {
        public string? DEmployeeType { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
