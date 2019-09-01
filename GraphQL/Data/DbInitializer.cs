using GraphQlPlayground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlPlayground.Data
{
    public class DbInitializer
    {
        public static void Initialize(CourseContext context)
        {
            context.Database.EnsureCreated();

            context.Enrollments.RemoveRange(context.Enrollments);
            context.Courses.RemoveRange(context.Courses);
            context.Students.RemoveRange(context.Students);
            context.SaveChanges();

            if (context.Students.Any())
            {
                return;
            }

            var student = new Student()
            {
                FirstName = "john",
                LastName = "doe",
                DateOfBirth = DateTime.Now.AddDays(10000)
            };
            context.Students.Add(student);

            var course = new Course()
            {
                Credits = 10,
                Title = "Just a course"
            };
            context.Courses.Add(course);

            context.SaveChanges();

            var enrollment = new Enrollment()
            {
                Student = student,
                Course = course,
                Grade = Grade.A
            };
            context.Enrollments.Add(enrollment);


            context.SaveChanges();
        }
    }
}
