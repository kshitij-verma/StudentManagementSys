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
        }
    }
}