using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.RemoteInteraction;
using Unity.Attributes;

namespace OverWeightControl.Runer
{
    public class UpdateClient
    {
        private readonly IConsoleService _console;
        private readonly Proxy _proxy;
        private readonly IDownloader _downloader;

        [InjectionConstructor]
        public UpdateClient(
            IConsoleService console,
            Proxy proxy)
        {
            _console = console;
            _proxy = proxy;
            _downloader = proxy.CreateRemoteProxy<IDownloader>();
        }

        
    }
}
