namespace CleanArchitecture.Domain.Model
{
    public partial class EmployeeType
    {
        public int Id { get; set; }
        public string? DEmployeeType { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
