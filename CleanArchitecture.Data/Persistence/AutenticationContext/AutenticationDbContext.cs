using CleanArchitecture.Domain.Model;
using CleanArchitecture.Infrastructure.Persistence.AutenticationContext.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class AutenticationDbContext : DbContext
    {
        public AutenticationDbContext(DbContextOptions<AutenticationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Person> Persons { get; set; } = null!;
        public virtual DbSet<PersonRole> PersonRoles { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration())
                        .ApplyConfiguration(new PersonRoleConfiguration())
                        .ApplyConfiguration(new RoleConfiguration());
        }
    }
}
