using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<EmployeeDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped(typeof(IBaseRepository<,>), typeof(RepositoryBase<,>));
            // services.AddScoped<IVideoRepository, VideoRepository>();

            return services;
        }

    }
}
