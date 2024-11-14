using System;
using System.Collections.Generic;

namespace Patterns.Flyweight
{
    public class FlyweightFactory
    {
        private Dictionary<string, BaseFlyweight> _flyweights { get; set; } = new();

        public BaseFlyweight GetFlyweight(string key)
        {
            if (_flyweights.TryGetValue(key, out var flyweight))
                return flyweight;

            BaseFlyweight newInstance = key switch
            {
                nameof(FlyweightA) => new FlyweightA(),
                nameof(FlyweightB) => new FlyweightB(),
                _ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
            };
            
            _flyweights.Add(newInstance.GetType().Name, newInstance);
            
            return _flyweights[key];
        }
    }
}