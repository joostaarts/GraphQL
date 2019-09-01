﻿using GraphQL.Types;
using GraphQlPlayground.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlPlayground.GraphQL.Types
{
    public class Query : ObjectGraphType
    {
        public Query(StudentRepository studentRepository)
        {
            Field<ListGraphType<StudentType>>("students", resolve: context => studentRepository.GetAll());
        }
    }
}