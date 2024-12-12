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
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }


        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}

