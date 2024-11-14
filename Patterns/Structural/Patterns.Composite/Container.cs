using System.Collections.Generic;

namespace Patterns.Composite
{
    public abstract class Container: DefaultComponent
    {
        private readonly List<DefaultComponent> _children = new();
        
        protected Container(string name) : base(name)
        {
        }

        public virtual DefaultComponent[] GetChildren() => _children.ToArray();
        public virtual void AddChild(DefaultComponent component) => _children.Add(component);
        
        public override void DoWork()
        {
            base.DoWork();

            foreach (var child in GetChildren())
            {
                child.DoWork();
            }
        }
    }
}