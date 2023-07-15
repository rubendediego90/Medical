using CleanArchitecture.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.EmployeeContext.Configuration
{
    internal class EmployeeTypeConfiguration : IEntityTypeConfiguration<EmployeeType>
    {
        public void Configure(EntityTypeBuilder<EmployeeType> builder)
        {
            builder.ToTable("EmployeeType");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.LastModifiedDate).HasColumnType("datetime");

            builder.Property(e => e.DEmployeeType)
                .HasMaxLength(50)
                .HasColumnName("DEmployeeType");
        }
    }
}
