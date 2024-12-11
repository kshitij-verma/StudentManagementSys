using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repositories.DbModels;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.RepositoryBase
{
        public class FacultyRepository : IFacultyRepository
        {
            private readonly SMSContext _context;

            public FacultyRepository(SMSContext context)
            {
                _context = context;
            }


        public async Task<IEnumerable<Faculty>> GetAllFacultiesAsync()
        {
            return await _context.Faculties
                .Include(f => f.Students) 
                .ToListAsync();
        }

        public async Task<Faculty> GetFacultyByIdAsync(int id)
        {
            return await _context.Faculties
                .Include(f => f.Students)  
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task UpdateFacultyAsync(Faculty faculty)
        {
            _context.Entry(faculty).State = EntityState.Modified;  // Mark the entity as modified
            await _context.SaveChangesAsync(); 
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync(); 
        }

        public async Task AddFacultyAsync(Faculty faculty)
        {
            await _context.Faculties.AddAsync(faculty);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFacultyAsync(int id)
        {

            var faculty = await _context.Faculties.FindAsync(id);
            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();
        }


    }
}
