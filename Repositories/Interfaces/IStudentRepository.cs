using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        //Task<IEnumerable<Student>> GetAllStudentsAsync();
        //Task<Course> GetStudentByIdAsync(int id);
        //Task SaveAsync();
        //Task UpdateStudentAsync(Student student);
        //Task AddStudentAsync(Student student);
        //Task DeleteStudentAsync(int id);
    }
}
