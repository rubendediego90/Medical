using CleanArchitecture.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.AutenticationContext.Configuration
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.Address).HasMaxLength(100);

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.DateOfBirth).HasColumnType("date");

            builder.Property(e => e.Dni)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("DNI");

            builder.Property(e => e.Email).HasMaxLength(75);

            builder.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            builder.Property(e => e.LastModifiedDate).HasColumnType("datetime");

            builder.Property(e => e.LastName1).HasMaxLength(50);

            builder.Property(e => e.LastName2).HasMaxLength(50);

            builder.Property(e => e.Name).HasMaxLength(25);

            builder.Property(e => e.Password).HasMaxLength(30);
        }
    }
}
