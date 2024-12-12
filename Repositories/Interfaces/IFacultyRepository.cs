using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IFacultyRepository : IRepository<Faculty> // where Faculty: class
    {                                  
        //Task<IEnumerable<Faculty>> GetAllFacultiesAsync();
        //Task<Faculty> GetFacultyByIdAsync(int id);
        //Task SaveAsync();
        //Task UpdateFacultyAsync(Faculty faculty);
        //Task AddFacultyAsync(Faculty faculty);
        //Task DeleteFacultyAsync(int id);
    }
}
