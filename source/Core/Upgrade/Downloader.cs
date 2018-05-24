using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Settings;

namespace OverWeightControl.Core.Upgrade
{
    public class Downloader : IDownloader
    {
        private readonly IConsoleService _console;
        private readonly ISettingsStorage _settings;

        public Downloader(
            IConsoleService console,
            ISettingsStorage settings)
        {
            _console = console;
            _settings = settings;
        }

        public int GetLastVersion()
        {
            try
            {
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}Updates\\";
                var dirs = Directory
                    .GetDirectories(path)
                    .Select(m => m.Split('\\').Last());
                return dirs
                    .Select(m => int.TryParse(m, out int buf) ? buf : -1)
                    .Max();
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return -1;
            }
        }

        public IEnumerable<string> GetFileList(int version)
        {
            try
            {
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}Updates\\{version}";
                var files = Directory.GetFiles(path, "*.dll")
                .Union(Directory.GetFiles(path, "*.exe"));
                // .Select(Path.GetFileName);
                return files.Select(m => new FileInfo(m).FullName);
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        public byte[] DownLoadFile(int version, string fileName)
        {
            try
            {
                return File.ReadAllBytes(fileName);
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return new byte[0];
            }
        }
    }
}
