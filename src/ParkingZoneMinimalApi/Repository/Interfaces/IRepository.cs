namespace ParkingZoneMinimalApi.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();

        public Task<T?> GetById(int id);

        public Task Create(T entity);

        public Task<bool> Update(T entity);

        public Task<bool> Delete(T entity);
    }
}
