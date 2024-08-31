using ParkingZoneMinimalApi.DataAccess;
using ParkingZoneMinimalApi.Models;
using ParkingZoneMinimalApi.Repository.Interfaces;

namespace ParkingZoneMinimalApi.Repository
{
    public class ParkingSlotRepo : Repository<ParkingSlot>, IParkingSlotRepo
    {
        private readonly ApplicationDbContext _context;
        public ParkingSlotRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
