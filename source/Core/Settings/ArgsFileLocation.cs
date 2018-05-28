using System;
using Unity.Attributes;

namespace OverWeightControl.Core.Settings
{
    public class ArgsFileLocation
    {
        private readonly string _defaultPath;

        [InjectionConstructor]
        public ArgsFileLocation(
            [OptionalDependency]ISettingsStorage settings)
        {
            _defaultPath = settings == null
                ? AppDomain.CurrentDomain.BaseDirectory
                : settings["ArgsFileLocation"];
        }

        public ArgsFileLocation(string fileName)
        {
            _defaultPath = fileName;
        }


        public string GetPath()
        {
            return _defaultPath;
        }
    }
}