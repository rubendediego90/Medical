using CleanArchitecture.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.AutenticationContext.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.DRole)
                .HasMaxLength(50)
                .HasColumnName("DRole");

            builder.Property(e => e.LastModifiedDate).HasColumnType("datetime");
        }
    }
}
