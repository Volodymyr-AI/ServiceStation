using ServiceStation.Application.Common.Mappings;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application;
using ServiceStation.Persistense;
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace ServiceStation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>();

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IAppDbContext).Assembly));
            });

            builder.Services.AddApplication();
            builder.Services.AddPersistense(builder.Configuration);
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            builder.Services.AddControllers();
            
            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ServiceStation API v1");
            });
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.MapControllers();
            
            app.Run();
        }
    }
}