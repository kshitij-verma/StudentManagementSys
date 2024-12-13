using Models.Entities;
using Repositories.RepositoryBase;
using Repositories.RepositoryImplementations;
using Services.ServicesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
    public class EnrollmentService : IService<Enrollment>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            return await _enrollmentRepository.GetAllAsync();
        }

        public async Task<Enrollment> GetByIdAsync(int id)
        {
            return await _enrollmentRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, Enrollment updatedEnrollment)
        {
            var faculty = await _enrollmentRepository.GetByIdAsync(id);

            if (faculty == null)
            {
                return false; // Faculty not found
            }

            // Update faculty properties
            //faculty.Name = updatedFaculty.Name; // Update logic
            await _enrollmentRepository.SaveAsync(); // Save changes to the database
            return true;
        }
        public async Task AddAsync(Enrollment enrollment)
        {

            await _enrollmentRepository.AddAsync(enrollment);
        }

        public async Task DeleteAsync(int id)
        {
            await _enrollmentRepository.DeleteAsync(id);
        }
    }

}
