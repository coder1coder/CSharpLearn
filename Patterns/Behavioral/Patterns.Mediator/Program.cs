namespace Patterns.Mediator
{
    class Program
    {
        /// <summary>
        /// Посредник — это поведенческий паттерн проектирования,
        /// который позволяет уменьшить связанность множества классов между собой,
        /// благодаря перемещению этих связей в один класс-посредник.
        /// </summary>
        static void Main(string[] _)
        {
            var mediator = new RoomMediator();

            mediator.AttachMember(new RoomMember("Carl"));
            mediator.AttachMember(new RoomMember("Leo"));
            mediator.AttachMember(new RoomMember("Tommy"));

            mediator.Members[0].Send("Carl", "Hello from first user");
        }
    }
}