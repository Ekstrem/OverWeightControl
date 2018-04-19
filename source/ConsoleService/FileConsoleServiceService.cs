using System.Collections.Generic;
using Newtonsoft.Json;
using OverWeightControl.Core.Console;

namespace OverWeightControl.Core.ConsoleService
{
    public class FileConsoleServiceService : DefaultConsoleService, IConsoleService
    {
        public override IDictionary<ConsoleMessage, bool> Flush()
        {
            var jLog = JsonConvert.SerializeObject(_log);
            System.Console.Write(jLog);
            return _log;
        }
    }
}
