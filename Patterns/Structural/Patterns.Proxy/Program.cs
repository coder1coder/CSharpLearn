namespace Patterns.Proxy
{
    class Program
    {
        /// <summary>
        /// Заместитель — это структурный паттерн проектирования,
        /// который позволяет подставлять вместо реальных объектов специальные объекты-заменители.
        /// Эти объекты перехватывают вызовы к оригинальному объекту,
        /// позволяя сделать что-то до или после передачи вызова оригиналу.
        /// </summary>
        static void Main(string[] _)
        {
            var originalObject = new DefaultPaymentTerminal();
            var proxiedObject = new ProxyPaymentTerminal(originalObject);
            
            proxiedObject.Pay();
        }
    }
}