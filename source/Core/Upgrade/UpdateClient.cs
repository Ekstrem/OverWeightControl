using System;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
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

        [InjectionConstructor]
        public UpdateClient(
            IConsoleService console,
            ISettingsStorage settings,
            [OptionalDependency]Proxy proxy)
        {
            _console = console;
            _settings = settings;
            _proxy = proxy;
        }

        public void Initial()
        {
            try
            {
                if (_proxy != null)
                {
                    var downloader = _proxy.CreateRemoteProxy<IDownloader>();
                    if (_proxy.State != CommunicationState.Faulted && downloader != null)
                        Task.Factory.StartNew(() => GetVersion(downloader));
                }
            }
            catch (Exception e)
            {
                _console.AddException(e);
            }
        }

        void GetVersion(IDownloader downloader)
        {
            try
            {
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}Updates\\";

                int version = downloader.GetLastVersion();
                int currentVersion = int.TryParse(_settings[ArgsKeyList.Version], out int buf) ? buf : -1;
                if (currentVersion > version)
                    return;

                var files = downloader.GetFileList(version);

                foreach (var file in files)
                {
                    byte[] data = downloader.DownLoadFile(version, file);
                    File.WriteAllBytes($"{path}{Path.GetFileName(file)}", data);
                }

                _settings[ArgsKeyList.Version] = version.ToString();
                _settings.SaveToFile();
            }
            catch (Exception e)
            {
                _console.AddException(e);
            }
        }
    }
}
