using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "23406cd3-7b99-4754-bdf6-36e1598ffa9f",
                    UserId = "36450b6e-6f1c-404d-8178-d6dc83bf1b49",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "6b8c3a6b-ff55-4fd6-8b9a-6356d7902e87",
                    UserId = "05f6ed86-0e09-4338-958d-c8e8132a7e29",
                }
           );
        }
    }
}
