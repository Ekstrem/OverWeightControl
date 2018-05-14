using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity.Lifetime;

namespace OverWeightControl
{
    [JsonObject]
    public class Dependency
    {
        public Dependency(int order = -1)
        {
            Order = order;
            Name = string.Empty;
            Lifetime = new ContainerControlledLifetimeManager();
            Register = true;
            AllowRoles = new List<NodeRole>();
        }

        [JsonProperty]
        public int Order { get; set; }

        [JsonProperty]
        public Type Abstractions { get; set; }

        [JsonProperty]
        public Type Realization { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public bool Register { get; set; }

        [JsonProperty]
        public ICollection<NodeRole> AllowRoles { get; set; }

        [JsonIgnore]
        public LifetimeManager Lifetime { get; set; }

        /// <summary>Возвращает строку, представляющую текущий объект.</summary>
        /// <returns>Строка, представляющая текущий объект.</returns>
        public override string ToString() => $"{Abstractions.Name}, {Realization.Name}, {Name}";
    }
}