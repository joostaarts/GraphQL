using GraphQlPlayground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlPlayground.Data.Repositories
{
    public class StudentRepository
    {
        CourseContext _context;

        public StudentRepository(CourseContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }
    }

}
