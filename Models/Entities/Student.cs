using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }


        public ICollection<Course> Courses { get; set; } = null!;
        public ICollection<Enrollment> Enrollments { get; set; } = null!;

        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; } = null!;


    }
}
