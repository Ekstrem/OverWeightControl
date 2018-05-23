using System.IO;
using System.Linq;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.RemoteInteraction;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Runer
{
    public class UpdateClient
    {
        private readonly IConsoleService _console;
        private readonly ISettingsStorage _settings;
        private readonly Proxy _proxy;
        private readonly IDownloader _downloader;

        [InjectionConstructor]
        public UpdateClient(
            IConsoleService console,
            ISettingsStorage settings,
            Proxy proxy)
        {
            _console = console;
            _settings = settings;
            _proxy = proxy;
            _downloader = proxy.CreateRemoteProxy<IDownloader>();
        }

        void GetVersion()
        {
            int version = _downloader.GetLastVersion();
            var files = _downloader
                .GetFileList(version)
                .Select(Path.GetFileName)
                .ToDictionary(k => k, v => _downloader.DownLoadFile(version, v));
            foreach (var file in files)
                File.WriteAllBytes(file.Key, file.Value);
        }
    }
}
