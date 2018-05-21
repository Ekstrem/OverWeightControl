using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using OverWeightControl.Core.Console;
using Unity.Attributes;

namespace OverWeightControl.Core.Settings
{
    using Dict = IDictionary<string, string>;

    public class DefaultSettingsStorage : ISettingsStorage, IDisposable
    {
        private readonly IConsoleService _console;
        private static Dict _args;
        private readonly string _argsFilePath;

        [InjectionConstructor]
        public DefaultSettingsStorage(
            IConsoleService console)
        {
            _console = console;
            if (_args != null)
                return;

            _argsFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}args.txt";
            _args = File.Exists(_argsFilePath)
                ? LoadFromFile()
                : new Dictionary<string, string>
                {
                    {
                        ArgsKeyList.ScanPath,
                        $"{AppDomain.CurrentDomain.BaseDirectory}"
                    },
                    {
                        ArgsKeyList.StorePath,
                        $"{AppDomain.CurrentDomain.BaseDirectory}Store"
                    },
                    {
                        ArgsKeyList.BackUpPath,
                        $"{AppDomain.CurrentDomain.BaseDirectory}BackUp"
                    },
                    {ArgsKeyList.ArgsFileLocation, _argsFilePath},
                    {ArgsKeyList.IsDebugMode, "false"},
                    {ArgsKeyList.WFProcWaitingFor, "60"},
                    {ArgsKeyList.ServerName, "localhost"},
                    {ArgsKeyList.Port, "8001"},
                    {ArgsKeyList.ScanExt, "*.pdf"},
                    {
                        ArgsKeyList.AfcPath,
                        $"{AppDomain.CurrentDomain.BaseDirectory}AfcPath"
                    },
                    {
                        ArgsKeyList.Mode,
                        "BelModel"
                    },
                    {
                        ArgsKeyList.ConnectionString,
                        "Data Source=EHC\\SQLEXPRESS;Initial Catalog=ActsDB;Integrated Security=True"
                    },
                    { ArgsKeyList.Binding, "Net" }
                };
        }

        public void Dispose()
        {
            SaveToFile();
            _args = null;
        }

        public DefaultSettingsStorage(string fileName)
        {
            _args[ArgsKeyList.ArgsFileLocation] = fileName;
            LoadFromFile();
        }

        public DefaultSettingsStorage(Dict args)
        {
            _args = args;
        }

        public string Key(string keyName)
        {
            return _args.ContainsKey(keyName)
                ? _args[keyName]
                : String.Empty;
        }

        public Dict GetArgs()
        {
            return _args;
        }

        public Dict LoadFromFile()
        {
            try
            {
                string json = File
                    .ReadAllLines(_argsFilePath)
                    .Aggregate((a, i) => a + i);

                return JsonConvert
                    .DeserializeObject<Dict>(json);
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        public bool SaveToFile()
        {
            try
            {
                string json = JsonConvert
                    .SerializeObject(_args, Formatting.Indented);
                File.WriteAllText(_args[ArgsKeyList.ArgsFileLocation], json);
                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);

                var newFileLocation = $"{AppDomain.CurrentDomain.BaseDirectory}args.txt";
                if (_args[ArgsKeyList.ArgsFileLocation] == newFileLocation) return false;

                _args[ArgsKeyList.ArgsFileLocation] = newFileLocation;
                return SaveToFile();
            }
        }
    }
}
