using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RepositoryBase
{
    public interface IEnrollmentRepository : ICourseRepository<Enrollment>
    {
        //Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();
        //Task<Enrollment> GetEnrollmentByIdAsync(int id);
        //Task SaveAsync();
        //Task UpdateEnrollmentAsync(Enrollment enrollment);
        //Task AddEnrollmentAsync(Enrollment enrollment);
        //Task DeleteEnrollmentAsync(int id);
    }
}
