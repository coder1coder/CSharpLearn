using System;

namespace Patterns.ChainOfResponsibility
{
    public class CookHandler: BaseHandler
    {
        public override void Handle(IRestaurantOrder restaurantOrder)
        {
            Console.WriteLine("Cook handle request");
            base.Handle(restaurantOrder);
        }
    }
}