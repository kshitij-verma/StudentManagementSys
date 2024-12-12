using Models.Entities;
using Repositories.DbModels;
using Repositories.Interfaces;

namespace Repositories.RepositoryBase
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