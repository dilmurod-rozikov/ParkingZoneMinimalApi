
using Microsoft.EntityFrameworkCore;
using ParkingZoneMinimalApi.DataAccess;
using ParkingZoneMinimalApi.Repository.Interfaces;
using ParkingZoneMinimalApi.Repository;
using ParkingZoneMinimalApi.Services.Interfaces;
using ParkingZoneMinimalApi.Services;
using AutoMapper;
using ParkingZoneMinimalApi.DTOs;
using ParkingZoneMinimalApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ParkingZoneMinimalApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

            builder.Services.AddScoped<IParkingZoneRepo, ParkingZoneRepo>();
            builder.Services.AddScoped<IParkingZoneService, ParkingZoneService>();

            builder.Services.AddScoped<IParkingSlotService, ParkingSlotService>();
            builder.Services.AddScoped<IParkingSlotRepo, ParkingSlotRepo>();

            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddScoped<IReservationRepo, ReservationRepo>();

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(typeof(Helper.MappingProfiles));
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapGet("/parkingzones", async (IParkingZoneService service, IMapper mapper) =>
                Results.Ok(mapper.Map<List<ParkingZoneDto>> (await service.GetAllAsync())));

            app.MapGet("/parkingzones/{id}", async (int id, IParkingZoneService service, IMapper mapper) =>
            {
                var zone = mapper.Map<ParkingZoneDto>(await service.GetByIdAsync(id));
                if (zone == null)
                    return Results.NotFound();

                return Results.Ok(zone);
            });

            app.MapPost("parkingzones/{dto}", async ([FromBody]ParkingZoneDto dto, IParkingZoneService service, IMapper mapper) =>
            {
                if(dto is null)
                    return Results.BadRequest("Parkingzone data is required");

                try
                {
                    var zone = mapper.Map<ParkingZone>(dto);
                    await service.CreateAsync(zone);
                    return Results.Created($"/parkingzones/{zone.Id}", zone);
                }
                catch (DbUpdateException ex)
                {
                    Console.Error.WriteLine($"Error creating parking zone: {ex.Message}");

                    return Results.StatusCode(500);
                }
            });

            app.Run();
        }
    }
}
