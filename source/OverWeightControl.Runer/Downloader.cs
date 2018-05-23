using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Settings;

namespace OverWeightControl.Runer
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
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}Updates//";
                return Directory
                    .GetDirectories(path)
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
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}Updates//{version}";
                string fileMask = _settings.Key(ArgsKeyList.ScanExt);
                return Directory
                    .GetFiles(path, fileMask)
                    .Select(m => new FileInfo(m).FullName);
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
