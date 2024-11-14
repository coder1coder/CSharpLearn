using System;

namespace Patterns.Proxy
{
    public class DefaultPaymentTerminal: IPaymentTerminal
    {
        public void Pay()
        {
            Console.WriteLine("Do default pay");
        }
    }
}