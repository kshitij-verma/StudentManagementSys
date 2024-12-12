using Models.Entities;
using Repositories.DbModels;
using Repositories.RepositoryBase;

namespace Repositories.RepositoryImplementations
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly SMSContext _context;

        public CourseRepository(SMSContext context) : base(context)
        {
            _context = context;
        }
    }
}