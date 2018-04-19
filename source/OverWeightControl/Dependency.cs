using System;
using Unity.Lifetime;

namespace OverWeightControl
{
    public class Dependency
    {
        public Dependency(int order = -1)
        {
            Order = order;
            Name = string.Empty;
            Lifetime = new ContainerControlledLifetimeManager();
        }

        public int Order { get; set; }
        public Type Abstractions { get; set; }
        public Type Realization { get; set; }
        public string Name { get; set; }
        public bool Register { get; set; }
        public LifetimeManager Lifetime { get; set; }
    }
}