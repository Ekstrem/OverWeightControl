using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using OverWeightControl.Core.Console;

namespace OverWeightControl.Core.ConsoleService
{
    public class FileConsoleServiceService : DefaultConsoleService, IDisposable
    {
        private readonly Guid id;

        public FileConsoleServiceService()
        {
            id = Guid.NewGuid();
        }

        ~FileConsoleServiceService()
        {
            Dispose();
        }

        public void Dispose()
        {
            Flush();
        }


        public override IDictionary<ConsoleMessage, bool> Flush()
        {
            var jLog = JsonConvert.SerializeObject(_log);
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}Logs\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            File.WriteAllLines($"{path}{id}.log", _log.Select(m => m.Key.ToString()).ToArray());
            return _log;
        }
    }
}
