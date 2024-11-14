using System;

namespace Patterns.Facade
{
    class Program
    {
        /// <summary>
        /// Фасад — это структурный паттерн проектирования, который предоставляет простой интерфейс
        /// к сложной системе классов, библиотеке или фреймворку.
        /// </summary>
        /// <param name="_"></param>
        static void Main(string[] _)
        {
            var facade = new FileUploadFacade(new FileUploader(), new FileCompressor());
            facade.Upload();
        }
    }
}