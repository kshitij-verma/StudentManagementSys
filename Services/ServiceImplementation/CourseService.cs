using Models.Entities;
using Repositories.RepositoryBase;
using Services.ServicesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.RepositoryImplementations;

namespace Services.BusinessLogic
{
    public class CourseService : IService<Course>
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, Course updatedCourse)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
            {
                return false; // Course not found
            }

            // Update course properties
            course.Name = updatedCourse.Name; // Update logic
            await _courseRepository.SaveAsync(); // Save changes to the database
            return true;
        }

        public async Task AddAsync(Course course)
        {

            await _courseRepository.AddAsync(course);
        }

        public async Task DeleteAsync(int id)
        {
            await _courseRepository.DeleteAsync(id);
        }
    }

}
