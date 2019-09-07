using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlPlayground.GraphQL.Types.Input
{

    public class StudentInputType : InputObjectGraphType
    {
        public StudentInputType()
        {
            Name = "studentInput";
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<StringGraphType>>("dateOfBirth");
        }
    }

}
