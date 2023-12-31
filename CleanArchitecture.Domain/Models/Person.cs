﻿using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enum;

namespace CleanArchitecture.Domain.Model
{
    //id persona puede ser empleado o paciente
    public partial class Person : BaseDomainModel
    {
        public string Password { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public string? Name { get; set; }
        public string? LastName1 { get; set; }
        public string? LastName2 { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public EnumGender? Gender { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; } = null!;

        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
        public virtual ICollection<PersonRole>? PersonRoles { get; set; }
    }
}
