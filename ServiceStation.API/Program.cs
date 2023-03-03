using ServiceStation.Application.Common.Mappings;
using ServiceStation.Application.Interfaces;
using ServiceStation.Persistense;
using System.Reflection;
using ServiceStation.Application;

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

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");


            app.MapControllers();
            
            app.Run();
        }
    }
}