using AutoMapper;
using ParkingZoneMinimalApi.DTOs;
using ParkingZoneMinimalApi.Models;

namespace ParkingZoneMinimalApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ParkingZone, ParkingZoneDto>()
                .ReverseMap();
            CreateMap<ParkingSlot, ParkingSlotDto>()
                .ReverseMap();
            CreateMap<Reservation, ReservationDto>()
                .ReverseMap();
        }
    }
}
