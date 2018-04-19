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
            Register = true;
        }

        public int Order { get; set; }
        public Type Abstractions { get; set; }
        public Type Realization { get; set; }
        public string Name { get; set; }
        public bool Register { get; set; }
        public LifetimeManager Lifetime { get; set; }

        /// <summary>Возвращает строку, представляющую текущий объект.</summary>
        /// <returns>Строка, представляющая текущий объект.</returns>
        public override string ToString()
        {
            return $"{Abstractions.Name}, {Realization.Name}, {Name}";
        }
    }
}