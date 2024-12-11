using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;
using System.Reflection.Emit;

namespace Repositories.DbModels
{
    public class SMSContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        // constructor
        public SMSContext(DbContextOptions<SMSContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Faculty 
            modelBuilder.Entity<Faculty>(ff =>
            {
                ff.HasKey(f => new { f.Id });
                ff.Property(f => f.Name);
                ff.HasMany(f => f.Students)
                 .WithOne(s => s.Faculty);
            });

            // Student
            modelBuilder.Entity<Student>(ss =>
            {
                ss.HasKey(s => new { s.Id });
                ss.Property(s => s.Name);
                ss.Property(s => s.Phone);
                ss.HasMany(s => s.Enrollments)
                 .WithOne(e => e.Student);
                ss.HasMany(s => s.Courses)
                .WithMany(c => c.Students);
                ss.HasOne(s => s.Faculty)
                .WithMany(f => f.Students)
                .HasForeignKey(s => s.FacultyId);
            });

            //Course
            modelBuilder.Entity<Course>(cc =>
            {
                cc.HasKey(c => new { c.Id });
                cc.Property(c => c.Name);
                cc.HasMany(c => c.Students)
                .WithMany(s => s.Courses);
                cc.HasMany(c => c.Enrollments)
                .WithOne(e => e.Course);
            });

            // Many to Many relationship between Students and their Courses conjoined by Enrollment
            modelBuilder.Entity<Enrollment>(ee =>
            {
                ee.HasKey(e => new { e.StudentId, e.CourseId });
                ee.HasOne(e => e.Student)
                 .WithMany(s => s.Enrollments)
                 .HasForeignKey(e => e.StudentId);
                ee.HasOne(e => e.Course)
                 .WithMany(c => c.Enrollments)
                 .HasForeignKey(e => e.CourseId);

            });

            // Seeding Faculty data
            modelBuilder.Entity<Faculty>().HasData(
                new Faculty { Id = 1, Name = "Technical Science" },
                new Faculty { Id = 2, Name = "Science" },
                new Faculty { Id = 3, Name = "Arts" },
                new Faculty { Id = 4, Name = "Business" },
                new Faculty { Id = 5, Name = "Mathematics" }
                    );

            // Seeding Course data
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Data Structures" },
                new Course { Id = 2, Name = "Advanced Algebra" },
                new Course { Id = 3, Name = "Law and Ethics" },
                new Course { Id = 4, Name = "Introduction to Algebra" },
                new Course { Id = 5, Name = "Business Process Management" }
                    );

            // Seeding Student data
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Technical Science", Phone = "11111111" },
                new Student { Id = 2, Name = "Science", Phone = "23232323"},
                new Student { Id = 3, Name = "Arts", Phone = "24242424"},
                new Student { Id = 4, Name = "Business", Phone = "4444444" },
                new Student { Id = 5, Name = "Mathematics", Phone = "555555"}
                    );
        }
    }
}