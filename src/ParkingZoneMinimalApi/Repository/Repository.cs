using Microsoft.EntityFrameworkCore;
using ParkingZoneMinimalApi.DataAccess;
using ParkingZoneMinimalApi.Repository.Interfaces;

namespace ParkingZoneMinimalApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task Create(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
