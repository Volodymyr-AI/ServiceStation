using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStation.Application.Interfaces;

namespace ServiceStation.Persistense
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistense(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IAppDbContext>(provider =>
                (IAppDbContext)provider.GetService<AppDbContext>());
            return services;
        }
    }
}
