using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Model
{
    public partial class Employee : BaseDomainModel
    {
        public int? PersonId { get; set; }
        public int? EmployeeTypeId { get; set; }
        public virtual EmployeeType? EmployeeType { get; set; }
        public virtual Person? Person { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<Availability>? Availabilities { get; set; }
        public virtual ICollection<ScheduleWork>? ScheduleWorks { get; set; }
    }
}
