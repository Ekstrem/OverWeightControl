using System.Collections.Generic;

namespace OverWeightControl.Core.Settings
{
    public interface ISettingsStorage
    {
        string this[string key] { get; set; }
        ICollection<string> GetKeys();
        IDictionary<string, string> LoadFromFile();
        bool SaveToFile();
    }
}