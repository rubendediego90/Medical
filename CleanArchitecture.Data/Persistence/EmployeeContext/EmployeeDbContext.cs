using CleanArchitecture.Domain.Model;
using CleanArchitecture.Infrastructure.Persistence.EmployeeContext.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeTypeConfiguration())
                        .ApplyConfiguration(new EmployeConfiguration());
        }
    }
}
