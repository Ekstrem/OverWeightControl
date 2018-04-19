using System;
using System.Collections.Generic;
using Unity.Attributes;

namespace OverWeightControl.Core.Settings
{
    public class FileSettingsStorage : ISettingsStorage
    {
        private readonly IDictionary<string, string> _args;

        [InjectionConstructor]
        public FileSettingsStorage(
            ISettingsStorage strorage)
        {
            _args = strorage.GetArgs();
        }

        public string Key(string keyName)
        {
            return _args[keyName];
        }

        public IDictionary<string, string> GetArgs()
        {
            return _args;
        }

        public IDictionary<string, string> LoadFromFile()
        {
            throw new NotImplementedException();
        }

        public void Update(IDictionary<string, string> newSet)
        {
            throw new NotImplementedException();
        }

        public bool SaveToFile()
        {
            throw new NotImplementedException();
        }
    }
}
