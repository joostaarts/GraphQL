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

            if (context.Students.Any())
            {
                return;
            }

            var p = new Student()
            {
                FirstName = "first",
                LastName = "last"
            };

            context.Students.Add(p);

            context.SaveChanges();
        }
    }
}
