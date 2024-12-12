using Models.Entities;
using Repositories.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
    public class FacultyService
    {
        private readonly IFacultyRepository<Faculty> _facultyRepository;

        public FacultyService(IFacultyRepository<Faculty> facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public async Task<IEnumerable<Faculty>> GetAllAsync()
        {
            return await _facultyRepository.GetAllAsync();
        }

        public async Task<Faculty> GetByIdAsync(int id)
        {
            return await _facultyRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, Faculty updatedFaculty)
        {
            var faculty = await _facultyRepository.GetByIdAsync(id);

            if (faculty == null)
            {
                return false; // Faculty not found
            }

            // Update faculty properties
            faculty.Name = updatedFaculty.Name; // Update logic
            await _facultyRepository.SaveAsync(); // Save changes to the database
            return true;
        }

        public async Task AddFacultyAsync(Faculty faculty)
        {
            
            await _facultyRepository.AddAsync(faculty);
        }

        public async Task DeleteFacultyAsync(int id)
        {
            await _facultyRepository.DeleteAsync(id);
        }
    }

}
