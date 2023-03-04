using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace ServiceStation.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication
            (IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
