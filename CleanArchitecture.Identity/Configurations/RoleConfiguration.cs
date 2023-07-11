using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "23406cd3-7b99-4754-bdf6-36e1598ffa9f",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRADOR"
                },
                new IdentityRole
                {
                    Id = "6b8c3a6b-ff55-4fd6-8b9a-6356d7902e87",
                    Name = "Operator",
                    NormalizedName = "OPERATOR"
                }
           );
        }
    }
}
