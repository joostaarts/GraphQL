using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQlPlayground.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQlPlayground.Data
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
