namespace Patterns.ChainOfResponsibility
{
    public abstract class BaseHandler: IHandler
    {
        private IHandler _next;
        
        public virtual void Handle(IRestaurantOrder restaurantOrder)
        {
            _next?.Handle(restaurantOrder);
        }

        public IHandler SetNextHandle(IHandler nextHandler)
        {
            _next = nextHandler;
            return _next;
        }
    }
}