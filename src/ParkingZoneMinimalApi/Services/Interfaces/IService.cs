
namespace ParkingZoneMinimalApi.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T?> GetByIdAsync(int id);

        public Task CreateAsync(T entity);

        public Task<bool> UpdateAsync(T entity);

        public Task<bool> DeleteAsync(T entity);
    }
}
