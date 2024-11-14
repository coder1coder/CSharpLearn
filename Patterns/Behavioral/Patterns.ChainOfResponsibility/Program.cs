namespace Patterns.ChainOfResponsibility
{
    class Program
    {
        /// <summary>
        /// Цепочка обязанностей — это поведенческий паттерн проектирования, который позволяет
        /// передавать запросы последовательно по цепочке обработчиков.
        /// Каждый последующий обработчик решает, может ли он обработать запрос сам
        /// и стоит ли передавать запрос дальше по цепи.
        /// </summary>
        static void Main(string[] _)
        {
            var waiter = new WaiterHandler("Get order");
            waiter
                .SetNextHandle(new CookHandler())
                .SetNextHandle(new WaiterHandler("Give order"));
            
            waiter.Handle(new RestaurantOrder());
        }
    }
}