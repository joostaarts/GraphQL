using GraphQL.Types;
using GraphQlPlayground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlPlayground.GraphQL.Types
{
    public class StudentType : ObjectGraphType<Student>
    {
        public StudentType()
        {
            Field(t => t.ID);
            Field(t => t.DateOfBirth);
            Field(t => t.FirstName);
            Field(t => t.LastName);
        }
    }
}
