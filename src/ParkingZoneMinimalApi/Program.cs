
using Microsoft.EntityFrameworkCore;
using ParkingZoneMinimalApi.DataAccess;
using ParkingZoneMinimalApi.Repository.Interfaces;
using ParkingZoneMinimalApi.Repository;
using ParkingZoneMinimalApi.Services.Interfaces;
using ParkingZoneMinimalApi.Services;

namespace ParkingZoneMinimalApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/", () => "Hello World");

            app.Run();
        }
    }
}
