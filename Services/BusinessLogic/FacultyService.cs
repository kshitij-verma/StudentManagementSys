using Models.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
    public class FacultyService
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyService(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public async Task<IEnumerable<Faculty>> GetAllFacultiesAsync()
        {
            return await _facultyRepository.GetAllFacultiesAsync();
        }

        public async Task<Faculty> GetFacultyByIdAsync(int id)
        {
            return await _facultyRepository.GetFacultyByIdAsync(id);
        }

        public async Task<bool> UpdateFacultyAsync(int id, Faculty updatedFaculty)
        {
            var faculty = await _facultyRepository.GetFacultyByIdAsync(id);

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
            
            await _facultyRepository.AddFacultyAsync(faculty);
        }

        public async Task DeleteFacultyAsync(int id)
        {
            await _facultyRepository.DeleteFacultyAsync(id);
        }
    }

}
