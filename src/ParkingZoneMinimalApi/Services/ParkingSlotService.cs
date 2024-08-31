using ParkingZoneMinimalApi.Models;
using ParkingZoneMinimalApi.Repository.Interfaces;
using ParkingZoneMinimalApi.Services.Interfaces;

namespace ParkingZoneMinimalApi.Services
{
    public class ParkingSlotService : Service<ParkingSlot>, IParkingSlotService
    {
        public ParkingSlotService(IRepository<ParkingSlot> repository) : base(repository) { }
    }
}
