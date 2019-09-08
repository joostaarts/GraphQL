using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQlPlayground.GraphQL.Types;
using GraphQlPlayground.Models.Messages;
using GraphQlPlayground.Services.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlPlayground.GraphQL
{
    public class Subscription : ObjectGraphType
    {
        public Subscription(StudentAddedNotificationService service)
        {
            Name = "Subscription";

            AddField(new EventStreamFieldType
            {
                Name = "studentAdded",
                Type = typeof(StudenAddedMessageType),
                Resolver = new FuncFieldResolver<StudenAddedMessage>(c => c.Source as StudenAddedMessage),
                Subscriber = new EventStreamResolver<StudenAddedMessage>(c => service.GetMessages())
            });


        }
    }
}
