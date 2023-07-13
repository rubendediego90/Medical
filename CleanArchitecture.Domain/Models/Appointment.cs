﻿namespace CleanArchitecture.Domain.Model
{
    public partial class Appointment
    {
        public int Id { get; set; }
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