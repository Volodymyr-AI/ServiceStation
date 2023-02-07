using Microsoft.EntityFrameworkCore;

namespace ServiceStation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

            builder.Services.AddMemoryCache();
            builder.Services.AddControllers();
            

            var app = builder.Build();

            
            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}