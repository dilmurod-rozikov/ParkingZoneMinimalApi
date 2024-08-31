using ParkingZoneMinimalApi.DataAccess;
using ParkingZoneMinimalApi.Models;
using ParkingZoneMinimalApi.Repository.Interfaces;

namespace ParkingZoneMinimalApi.Repository
{
    public class ReservationRepo : Repository<Reservation>, IReservationRepo
    {
        private readonly ApplicationDbContext _context;
        public ReservationRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
