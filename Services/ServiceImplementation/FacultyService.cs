using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.ServicesBase;
using Repositories.RepositoryBase;

namespace Services.ServiceImplementation
{
    public class FacultyService : IFacultyService, IService<Faculty>
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyService(IFacultyRepository facultyRepository)
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

        public async Task AddAsync(Faculty faculty)
        {

            await _facultyRepository.AddAsync(faculty);
        }

        public async Task DeleteAsync(int id)
        {
            await _facultyRepository.DeleteAsync(id);
        }
    }

}
