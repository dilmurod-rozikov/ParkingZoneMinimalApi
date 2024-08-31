using AutoMapper;
using ParkingZoneMinimalApi.DTOs;
using ParkingZoneMinimalApi.Models;

namespace ParkingZoneMinimalApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ParkingZone, ParkingZoneDto>();
            CreateMap<ParkingZoneDto, ParkingZone>();
            CreateMap<ParkingSlot, ParkingSlotDto>();
            CreateMap<ParkingSlotDto, ParkingSlot>();
            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationDto, Reservation>();
        }
    }
}
