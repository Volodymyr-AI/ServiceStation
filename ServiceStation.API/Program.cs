using ServiceStation.Application.Common.Mappings;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application;
using ServiceStation.Persistense;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ServiceStation.BusinessLogic;

namespace ServiceStation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

            builder.Services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IAppDbContext).Assembly));
            });

            builder.Services.AddApplication();
            builder.Services.AddBusinessLogic();
            builder.Services.AddPersistense(builder.Configuration);

            builder.Services.AddSwaggerGen();
            
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
            app.UseSwaggerUI();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyOrigin());

            app.MapControllers();
            app.MapGet("/", () => "Hello World!");
           
            app.Run();
        }
    }
}