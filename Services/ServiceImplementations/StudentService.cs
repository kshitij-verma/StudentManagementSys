using Models.Entities;
using Repositories.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
    public class StudentService
    {
        private readonly IStudentRepository<Student> _studentRepository;

        public StudentService(IStudentRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, Student updatedStudent)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
            {
                return false; // Student not found
            }

            // Update student properties
            student.Name = updatedStudent.Name; // Update logic
            student.Phone = updatedStudent.Phone;
            await _studentRepository.SaveAsync(); // Save changes to the database
            return true;
        }

        public async Task AddAsync(Student student)
        {

            await _studentRepository.AddAsync(student);
        }

        public async Task DeleteAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
        }
    }

}
