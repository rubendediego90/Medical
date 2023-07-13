namespace CleanArchitecture.Domain.Model
{
    public partial class Availability
    {
        public int AvailabilityId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool? Available { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
