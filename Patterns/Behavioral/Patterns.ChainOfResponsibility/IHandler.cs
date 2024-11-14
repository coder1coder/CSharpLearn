namespace Patterns.ChainOfResponsibility
{
    public interface IHandler
    {
        void Handle(IRestaurantOrder restaurantOrder);
        IHandler SetNextHandle(IHandler nextHandler);
    }
}