using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Student> Students { get; set; } = null!;

        //public ICollection<Course> Courses { get; set; } = null!;
    }


}
