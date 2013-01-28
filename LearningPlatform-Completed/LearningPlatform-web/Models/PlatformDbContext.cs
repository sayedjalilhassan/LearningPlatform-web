using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace LearningPlatform.Models
{
    public class PlatformDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Chapter> Chapters { get; set; }
        
        public DbSet<Cart> Carts { get; set; }
        
        public DbSet<Download> Downloads { get; set; }
        
        public DbSet<DownloadDetail> DownloadDetails { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Course>()
               .HasMany(c => c.Instructors).WithMany(i => i.Courses)
               .Map(t => t.MapLeftKey("CourseID")
                   .MapRightKey("InstructorID")
                   .ToTable("CourseInstructor"));
            modelBuilder.Entity<Department>()
                .HasOptional(x => x.Administrator);
        }

    }
}