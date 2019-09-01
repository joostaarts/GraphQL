using GraphQlPlayground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlPlayground.Data.Repositories
{
    public class EnrollmentRepository
    {
        CourseContext _context;

        public EnrollmentRepository(CourseContext context)
        {
            _context = context;
        }

        public IEnumerable<Enrollment> GetEnrollmentsForStudent(int id)
        {
            return _context.Enrollments.Where(e => e.StudentID == id);
        }

        public IEnumerable<Enrollment> GetEnrollments()
        {
            return _context.Enrollments;
        }
    }
}
