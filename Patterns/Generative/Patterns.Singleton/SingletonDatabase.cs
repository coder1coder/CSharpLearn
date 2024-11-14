using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Patterns.Singleton
{
    public class SingletonDatabase
    {
        private readonly ConcurrentBag<string> _cities;

        public SingletonDatabase()
        {
            _cities = new ConcurrentBag<string>
            {
                "Moscow", "Saint-Petersburg"
            };
        }

        public void AddValue(string value) => _cities.Add(value);
        public IEnumerable<string> GetCities() => _cities;

        private static readonly Lazy<SingletonDatabase> Instance = new(() => new SingletonDatabase());

        public static SingletonDatabase DatabaseInstance => Instance.Value;
    }
}