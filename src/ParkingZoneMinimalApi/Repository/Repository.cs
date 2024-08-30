using Microsoft.EntityFrameworkCore;
using ParkingZoneMinimalApi.DataAccess;
using ParkingZoneMinimalApi.Repository.Interfaces;

namespace ParkingZoneMinimalApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        
    }
}
