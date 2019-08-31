using GraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Data
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
