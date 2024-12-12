using Models.Entities;
using Repositories.DbModels;
using Repositories.RepositoryBase;

namespace Repositories.RepositoryImplementations
{
    public class FacultyRepository : Repository<Faculty>, IFacultyRepository
    {
        private readonly SMSContext _context;

        public FacultyRepository(SMSContext context) : base(context)
        {
            _context = context;
        }
    }
}