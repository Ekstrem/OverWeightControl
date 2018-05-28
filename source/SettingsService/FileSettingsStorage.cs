using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Attributes;

namespace OverWeightControl.Core.Settings
{
    public class FileSettingsStorage : ISettingsStorage
    {
        private readonly IDictionary<string, string> _args;

        [InjectionConstructor]
        public FileSettingsStorage(
            ISettingsStorage storage)
        {
            _args = storage
                .GetKeys()
                .ToDictionary(k => k, v => storage[v]);
        }

        public string this[string key]
        {
            get => _args[key];
            set => _args[key] = value;
        }

        public ICollection<string> GetKeys()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, string> LoadFromFile()
        {
            throw new NotImplementedException();
        }

        public bool SaveToFile()
        {
            throw new NotImplementedException();
        }
    }
}
