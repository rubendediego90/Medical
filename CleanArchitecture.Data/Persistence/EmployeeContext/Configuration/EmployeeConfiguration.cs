using CleanArchitecture.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.EmployeeContext.Configuration
{
    internal class EmployeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.EmployeeTypeId).HasColumnName("EmployeeTypeID");

            builder.Property(e => e.PersonId).HasColumnName("PersonID");

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.LastModifiedDate).HasColumnType("datetime");

            builder.HasOne(d => d.EmployeeType)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeTypeId)
                .HasConstraintName("FK__Employee__Employ__2F10007B");

            builder.HasOne(d => d.Person)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__Employee__Person__2E1BDC42");
        }
    }
}
