using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "36450b6e-6f1c-404d-8178-d6dc83bf1b49",
                    Email = "rubendediegogomez@gmail.com",
                    NormalizedEmail = "ruben@ezentis.com",//para hacer login
                    Nombre = "Ruben",
                    Apellidos = "de Diego",
                    UserName = "rdediego",
                    NormalizedUserName = "rubenddiegoezentis",
                    PasswordHash = hasher.HashPassword(null, "ruben123456@"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = "05f6ed86-0e09-4338-958d-c8e8132a7e29",
                    Email = "juanperez@gmail.com",
                    NormalizedEmail = "juanperez@ezentis.com",
                    Nombre = "Juan",
                    Apellidos = "Perez",
                    UserName = "jperez",
                    NormalizedUserName = "jperezezentis",
                    PasswordHash = hasher.HashPassword(null, "juanp123456@"),
                    EmailConfirmed = true,
                }
           );
        }
    }
}
