using GraphQlPlayground.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace GraphQlPlayground.Services.Notification
{
    public class StudentAddedNotificationService
    {
        public readonly ISubject<StudenAddedMessage> _messageSream = new ReplaySubject<StudenAddedMessage>(1);

        public StudenAddedMessage AddNewStudentMessage(Models.Student student)
        {
            var message = new StudenAddedMessage()
            {
                Id = student.Id
            };
            _messageSream.OnNext(message);
            return message;
        }

        public IObservable<StudenAddedMessage> GetMessages()
        {
            return _messageSream.AsObservable();
        }
    }
}
