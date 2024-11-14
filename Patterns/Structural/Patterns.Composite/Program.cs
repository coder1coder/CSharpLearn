namespace Patterns.Composite
{
    class Program
    {
        /// <summary>
        /// Компоновщик — это структурный паттерн, который позволяет создавать дерево объектов
        /// и работать с ним так же, как и с единичным объектом.
        /// </summary>
        static void Main(string[] _)
        {
            var financeDirector = new Header("Finance Director");
            financeDirector.AddChild(new Employee("Finance director worker 1"));
            financeDirector.AddChild(new Employee("Finance director worker 2"));
            
            var chiefEngineer = new Header("Chief engineer");
            chiefEngineer.AddChild(new Employee("Chief engineer worker 1"));

            var boss = new Header("Boss");
            boss.AddChild(financeDirector);
            boss.AddChild(chiefEngineer);
            
            boss.DoWork();
        }
    }
}