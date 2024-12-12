using Models.Entities;
using Repositories.DbModels;
using Repositories.RepositoryBase;

namespace Repositories.RepositoryImplementations
{
    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        private readonly SMSContext _context;

        public EnrollmentRepository(SMSContext context) : base(context)
        {
            _context = context;
        }
    }
}