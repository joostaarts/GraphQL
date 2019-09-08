using GraphQL.Types;
using GraphQlPlayground.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlPlayground.GraphQL.Types
{
    public class StudenAddedMessageType : ObjectGraphType<StudenAddedMessage>
    {
        public StudenAddedMessageType()
        {
            Field(t => t.Id);
        }
    }
}
