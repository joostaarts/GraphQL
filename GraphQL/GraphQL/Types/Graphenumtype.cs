using GraphQL.Types;
using GraphQlPlayground.Models;

namespace GraphQlPlayground.GraphQL.Types
{
    public class GradeEnumType : EnumerationGraphType<Grade>
    {
        public GradeEnumType()
        {
            Name = "Grade";
        }

    }
}