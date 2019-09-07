using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlPlayground.GraphQL
{
    public class CourseSchema : Schema
    {
        public CourseSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<Types.Query>();
            Mutation = resolver.Resolve<Types.Mutation>();
        }

    }

}
