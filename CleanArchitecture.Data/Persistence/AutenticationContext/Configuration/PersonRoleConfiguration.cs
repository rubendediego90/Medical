using CleanArchitecture.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.AutenticationContext.Configuration
{
    internal class PersonRoleConfiguration : IEntityTypeConfiguration<PersonRole>
    {
        public void Configure(EntityTypeBuilder<PersonRole> builder)
        {
            builder.ToTable("PersonRole");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.LastModifiedDate).HasColumnType("datetime");

            builder.Property(e => e.PersonId).HasColumnName("PersonID");

            builder.Property(e => e.RoleId).HasColumnName("RoleID");

            builder.HasOne(d => d.Person)
                .WithMany(p => p.PersonRoles)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__PersonRol__Perso__286302EC");

            builder.HasOne(d => d.Role)
                .WithMany(p => p.PersonRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__PersonRol__RoleI__29572725");
        }
    }
}
