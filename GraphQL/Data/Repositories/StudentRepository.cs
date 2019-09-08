using GraphQlPlayground.GraphQL.Types;
using GraphQlPlayground.Models;
using GraphQlPlayground.Services.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlPlayground.Data.Repositories
{
    public class StudentRepository
    {
        private CourseContext _context;
        private StudentAddedNotificationService _notificationService;

        public StudentRepository(CourseContext context, StudentAddedNotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
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
            _notificationService.AddNewStudentMessage(student);
            return student;
        }
    }

}
