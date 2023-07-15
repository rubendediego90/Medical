using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Model
{
    //horario del trabajador
    public partial class ScheduleWork : BaseDomainModel
    {
        public int? EmployeeId { get; set; }
        public string? DayWeek { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
