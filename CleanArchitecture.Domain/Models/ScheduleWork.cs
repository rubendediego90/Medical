namespace CleanArchitecture.Domain.Model
{
    public partial class ScheduleWork
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string? DayWeek { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
