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
            var dataLog = JsonConvert.SerializeObject(_log.Keys, Formatting.Indented);
            File.WriteAllText($"{path}{id}.log", dataLog);
            return _log;
        }
    }
}
