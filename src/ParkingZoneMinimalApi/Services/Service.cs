using ParkingZoneMinimalApi.Repository.Interfaces;
using ParkingZoneMinimalApi.Services.Interfaces;

namespace ParkingZoneMinimalApi.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
    }
}
