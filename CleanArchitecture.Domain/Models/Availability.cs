using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Model
{
    //Disponibilidad ditas disponibles del medico
    public partial class Availability : BaseDomainModel
    {
        public int? EmployeeId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool? Available { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
