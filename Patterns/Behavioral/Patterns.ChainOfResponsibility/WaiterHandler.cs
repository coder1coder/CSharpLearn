using System;

namespace Patterns.ChainOfResponsibility
{
    public class WaiterHandler: BaseHandler
    {
        private readonly string _responsibility;
        public WaiterHandler(string responsibility)
        {
            _responsibility = responsibility;
        }
        public override void Handle(IRestaurantOrder restaurantOrder)
        {
            Console.WriteLine($"Waiter handle request: {_responsibility}");
            base.Handle(restaurantOrder);
        }
    }
}