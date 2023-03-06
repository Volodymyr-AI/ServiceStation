using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace ServiceStation.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), typeof(Application.AssemblyMarker).Assembly));
            return services;
        }
    }
}
