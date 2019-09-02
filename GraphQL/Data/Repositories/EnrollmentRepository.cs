using GraphQlPlayground.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ILookup<int, Enrollment>> GetEnrollmentsForStudents(IEnumerable<int> studentIds)
        {
            var enrollments = await _context.Enrollments.Where(e => studentIds.Contains(e.StudentID)).ToListAsync();
            return enrollments.ToLookup(e => e.StudentID);
        }
    }
}
