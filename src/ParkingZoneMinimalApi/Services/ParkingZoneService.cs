using ParkingZoneMinimalApi.Models;
using ParkingZoneMinimalApi.Repository.Interfaces;
using ParkingZoneMinimalApi.Services.Interfaces;

namespace ParkingZoneMinimalApi.Services
{
    public class ParkingZoneService : Service<ParkingZone>, IParkingZoneService
    {
        public ParkingZoneService(IRepository<ParkingZone> repository) : base(repository)
        {
        }
    }
}
