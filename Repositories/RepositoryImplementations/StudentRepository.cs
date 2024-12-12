using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repositories.DbModels;
using Repositories.RepositoryBase;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.RepositoryImplementations
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly SMSContext _context;

        public StudentRepository(SMSContext context) : base(context)
        {
            _context = context;
        }
    }
}
