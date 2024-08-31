
using ParkingZoneMinimalApi.Models;
using ParkingZoneMinimalApi.Repository.Interfaces;
using ParkingZoneMinimalApi.Services.Interfaces;

namespace ParkingZoneMinimalApi.Services
{
    public class ReservationService : Service<Reservation>, IReservationService
    {
        public ReservationService(IRepository<Reservation> repository) : base(repository)
        {
        }
    }
}
