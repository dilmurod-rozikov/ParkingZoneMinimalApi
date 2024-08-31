using ParkingZoneMinimalApi.DataAccess;
using ParkingZoneMinimalApi.Models;
using ParkingZoneMinimalApi.Repository.Interfaces;

namespace ParkingZoneMinimalApi.Repository
{
    public class ParkingZoneRepo : Repository<ParkingZone>, IParkingZoneRepo
    {
        private readonly ApplicationDbContext _context;
        public ParkingZoneRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
