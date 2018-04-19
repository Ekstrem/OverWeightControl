using System.Collections.Generic;

namespace OverWeightControl.Core.Settings
{
    public interface ISettingsStorage
    {
        string Key(string keyName);
        IDictionary<string, string> GetArgs();
        IDictionary<string, string> LoadFromFile();
        bool SaveToFile();
    }
}