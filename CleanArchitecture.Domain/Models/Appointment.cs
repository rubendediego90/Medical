using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Model
{
    //Cita de medico con paciente
    public partial class Appointment : BaseDomainModel
    {
        public int? PersonId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? ConsultationReason { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Person? Person { get; set; }
    }
}
