using System;

namespace Patterns.Mediator
{
    public class RoomMember
    {
        private RoomMediator _mediator;
        public string Name { get; init; }

        public RoomMember(string name)
        {
            Name = name;
        }

        public void SetMediator(RoomMediator mediator)
        {
            _mediator = mediator;
        }

        public void Send(string userName, string message)
        {
            _mediator.Send(userName, message);
        }

        public void Notify(string message)
        {
            Console.WriteLine($"{Name} got notification with message: {message}");
        }
    }
}