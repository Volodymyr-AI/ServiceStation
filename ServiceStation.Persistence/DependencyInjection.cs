﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStation.Application.Interfaces;

namespace ServiceStation.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
                                        IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<StationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IStationDbContext>(provider => provider.GetService<StationDbContext>());
            return services;
        }
    }
}
 