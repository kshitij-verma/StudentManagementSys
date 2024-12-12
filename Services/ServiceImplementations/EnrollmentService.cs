using Models.Entities;
using Repositories.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
    public class EnrollmentService
    {
        private readonly IEnrollmentRepository<Enrollment> _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository<Enrollment> enrollmentRepository)
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

        //public async Task<bool> UpdateAsync(int id, Enrollment updatedEnrollment)
        //{
        //    var enrollment = await _enrollmentRepository.GetByIdAsync(id);

        //    if (enrollment == null)
        //    {
        //        return false; // Enrollment not found
        //    }

        //    // Update enrollment properties
        //    enrollment.Name = updatedFaculty.Name; // Update logic
        //    await _facultyRepository.SaveAsync(); // Save changes to the database
        //    return true;
        //}

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
