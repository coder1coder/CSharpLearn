using System;

namespace Patterns.Proxy
{
    public class ProxyPaymentTerminal: IPaymentTerminal
    {
        private readonly IPaymentTerminal _originalObject;
        
        public ProxyPaymentTerminal(IPaymentTerminal originalObject)
        {
            _originalObject = originalObject;
        }
        
        public void Pay()
        {
            Console.WriteLine("Log pay operation");
            _originalObject.Pay();
        }
    }
}