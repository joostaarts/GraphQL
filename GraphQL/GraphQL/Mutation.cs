using GraphQL;
using GraphQL.Types;
using GraphQlPlayground.Data.Repositories;
using GraphQlPlayground.GraphQL.Types;
using GraphQlPlayground.GraphQL.Types.Input;
using GraphQlPlayground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlPlayground.GraphQL
{

    public class Mutation : ObjectGraphType
    {
        public Mutation(StudentRepository studentRepository)
        {
            FieldAsync<StudentType>("createStudent",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StudentInputType>>() { Name = "student" }),
                resolve: async context =>
                    {
                        var student = context.GetArgument<Student>("student");
                        return await context.TryAsyncResolve(async c => await studentRepository.CreateStudent(student));
                    }
                );
        }
    }

}
