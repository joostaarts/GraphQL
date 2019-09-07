using GraphQlPlayground.GraphQL.Types;
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

        public object GetStudent(int id)
        {
            return _context.Students.Single(student => student.Id == id);
        }

        public async Task<Student> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }

}
