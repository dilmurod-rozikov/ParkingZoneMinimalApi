using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingZoneMinimalApi.DTOs;
using ParkingZoneMinimalApi.Models;
using ParkingZoneMinimalApi.Services.Interfaces;

namespace ParkingZoneMinimalApi.EndPoints
{
    public static class ParkingZoneEndPoints
    {
        public static void MapParkingZoneEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/parkingzones/{id}/exists", async (int id, IParkingZoneService service) =>
            {
                var exists = await service.GetByIdAsync(id);
                if (exists == null)
                    return Results.NotFound();

                return Results.Ok(exists);
            }).WithName("ParkingZoneExists");

            app.MapGet("/parkingzones", async (IParkingZoneService service, IMapper mapper) =>
                Results.Ok(mapper.Map<List<ParkingZoneDto>>(await service.GetAllAsync())));

            app.MapGet("/parkingzones/{id}", async (int id, IParkingZoneService service, IMapper mapper) =>
            {
                var zone = mapper.Map<ParkingZoneDto>(await service.GetByIdAsync(id));
                if (zone == null)
                    return Results.NotFound();

                return Results.Ok(zone);
            });

            app.MapPost("parkingzones/{dto}", async ([FromBody] ParkingZoneDto dto, IParkingZoneService service, IMapper mapper) =>
            {
                if (dto is null)
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

            app.MapPatch("parkingzones/{id, dto}", async (int id, [FromBody] ParkingZoneDto dto, IParkingZoneService service, IMapper mapper) =>
            {
                if (id != dto.Id || dto is null)
                    return Results.BadRequest("Ids are not matching...");
                var zone = await service.GetByIdAsync(id);
                if (zone == null)
                    return Results.NotFound();

                try
                {
                    if (!await service.UpdateAsync(mapper.Map<ParkingZone>(dto)))
                        return Results.StatusCode(500);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.Error.WriteLine($"Error creating parking zone: {ex.Message}");
                    return Results.StatusCode(500);
                }

                return Results.NoContent();
            });

            app.MapDelete("parkingzones/{id}", async (int id, IParkingZoneService service, IMapper mapper) =>
            {
                var zone = await service.GetByIdAsync(id);
                if (zone == null)
                    return Results.NotFound();

                if (!await service.DeleteAsync(zone))
                {
                    Console.Error.WriteLine("Something went wrong in the server while deleting the data.");
                    return Results.StatusCode(500);
                }

                return Results.Ok();
            });
        }
    }
}
