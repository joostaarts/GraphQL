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

            var rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                var student = new Student()
                {
                    FirstName = $"john{i}",
                    LastName = $"doe{i}",
                    DateOfBirth = DateTime.Now.AddDays(rand.Next(-15000, -5000))
                };
                context.Students.Add(student);
            }


            for (int i = 0; i < 10; i++)
            {
                var course = new Course()
                {
                    Credits = rand.Next(5, 11),
                    Title = $"Just a course {i}"
                };
                context.Courses.Add(course);
            }


            context.SaveChanges();


            context.Students.ToList().ForEach(s =>
            {
                var enrollment = new Enrollment()
                {
                    Student = s,
                    Course = context.Courses.First(),
                    Grade = (Grade)rand.Next((int)Grade.A, (int)Grade.F + 1)
                };
                context.Enrollments.Add(enrollment);
            });
            context.SaveChanges();
        }
    }
}
