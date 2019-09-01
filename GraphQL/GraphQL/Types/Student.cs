using GraphQL.Types;
using GraphQlPlayground.Data.Repositories;
using GraphQlPlayground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlPlayground.GraphQL.Types
{
    public class StudentType : ObjectGraphType<Student>
    {
        public StudentType(EnrollmentRepository enrollmentRepository)
        {
            Field(t => t.Id);
            Field(t => t.DateOfBirth);
            Field(t => t.FirstName);
            Field(t => t.LastName);

            Field<ListGraphType<EnrollmentType>>("enrollments",
                resolve: context => enrollmentRepository.GetEnrollmentsForStudent(context.Source.Id));
        }
    }
}
