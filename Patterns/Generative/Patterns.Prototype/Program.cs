using System;

namespace Patterns.Prototype
{
    class Program
    {
        /// <summary>
        /// Прототип — это порождающий паттерн проектирования, который позволяет копировать объекты,
        /// не вдаваясь в подробности их реализации.
        /// </summary>
        static void Main()
        {
            var person = new Person("Иванов Иван Иванович")
            {
                Document = new Document("10441", "48110182")
            };

            Console.WriteLine("Base entity");
            Console.WriteLine(person.ToString());

            var personClone = person.Clone();

            Console.WriteLine("\nClone");
            Console.WriteLine(personClone);

            personClone.Document.Number = "000";

            Console.WriteLine("\nClone changed");
            Console.WriteLine(personClone);

            Console.WriteLine("\nBase entity after clone changing");
            Console.WriteLine(person.ToString());
        }
    }
}
