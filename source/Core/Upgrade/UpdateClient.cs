using System;
using System.IO;
using System.Linq;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.RemoteInteraction;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Core.Upgrade
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
            GetVersion();
        }

        void GetVersion()
        {
            try
            {
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}Updates\\";

                int version = _downloader.GetLastVersion();
                int currentVersion = int.TryParse(_settings.Key(ArgsKeyList.Version), out int buf) ? buf : -1;
                if (currentVersion > version)
                    return;

                var files = _downloader
                    .GetFileList(version)
                    .Select(m => $"{path}{Path.GetFileName(m)}");
                foreach (var file in files)
                {
                    byte[] data = _downloader.DownLoadFile(version, file);
                    File.WriteAllBytes(file, data);
                }

                _settings.GetArgs()[ArgsKeyList.Version] = version.ToString();
            }
            catch (Exception e)
            {
                _console.AddException(e);
            }
        }
    }
}
