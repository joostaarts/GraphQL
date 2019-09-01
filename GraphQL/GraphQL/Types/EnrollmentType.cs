using GraphQL.Types;
using GraphQlPlayground.Models;

namespace GraphQlPlayground.GraphQL.Types
{
    public class EnrollmentType : ObjectGraphType<Enrollment>
    {
        public EnrollmentType()
        {
            Field(t => t.Id);
            Field(t => t.CourseID);
            Field(t => t.StudentID);
            Field<GradeEnumType>("Grade");
        }
    }
}