using Microsoft.EntityFrameworkCore;
using Repositories.DbModels;
using Repositories.RepositoryBase;
//using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class Repository<T> : ICourseRepository<T> where T : class
    {
        private readonly SMSContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(SMSContext context)
        {
            _context = context;
            //_dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }


        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}

