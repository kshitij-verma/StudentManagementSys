using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RepositoryBase
{
    public interface ICourseRepository : ICourseRepository<Course>
    {
        //Task<IEnumerable<Course>> GetAllCoursesAsync();
        //Task<Course> GetCourseByIdAsync(int id);
        //Task SaveAsync();
        //Task UpdateCourseAsync(Course course);
        //Task AddCourseAsync(Course course);
        //Task DeleteCourseAsync(int id);
    }
}
