using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity.Attributes;
using Unity.Interception.Utilities;

namespace OverWeightControl.Core.FileTransfer.Client
{
    /// <summary>
    /// Класс забирает все файлы из ScanPath,
    /// перекладывает в StorePath, организует для этого подымаемую
    /// очередь с внятным WorkFlow.
    /// </summary>
    public class FinderFiles : WorkFlowBase, IDisposable
    {
        private readonly string _path;
        private ICollection<string> _removeList;

        #region Lifetime

        public FinderFiles()
        {
            _queue = new ConcurrentQueue<FileTransferInfo>();
            _removeList = new HashSet<string>();

            CancelationToken = WorkFlowCancelationToken.Stoped;
        }

        [InjectionConstructor]
        public FinderFiles(
            ISettingsStorage settings,
            IConsoleService console)
            : base(settings, console)
        {
            _path =
                _settings?.Key(ArgsKeyList.ScanPath)
                ?? AppDomain.CurrentDomain.BaseDirectory;

            var fileName = $"{_settings.Key(ArgsKeyList.StorePath)}\\list.json";
            _queue = !File.Exists(fileName)
                ? new ConcurrentQueue<FileTransferInfo>()
                : new ConcurrentQueue<FileTransferInfo>(LoadFromFile(fileName));
            
            _removeList = new List<string>();

            CancelationToken = WorkFlowCancelationToken.Ready;

            _console.AddEvent($"{nameof(FinderFiles)} ready.");
        }

        ~FinderFiles()
        {
            Dispose();
        }

        public void Dispose()
        {
            try
            {
                CancelationToken = WorkFlowCancelationToken.Stoped;

                // save copied fileList info in file
                string json = JsonConvert
                    .SerializeObject(_queue.ToList());
                var fileName = $"{_settings.Key(ArgsKeyList.StorePath)}\\list.json";
                File.WriteAllText(fileName, json);

                // deleting copied files
                if (!bool.Parse(_settings.Key(ArgsKeyList.IsDebugMode)))
                {
                    _removeList.ForEach(File.Delete);
                }

                _console.AddEvent($"{nameof(FinderFiles)} stoped.");
            }
            catch (Exception e)
            {
                _console?.AddException(e);
            }
        }

        #endregion

        /// <summary>
        /// Рабочий процесс по передаче файлов.
        /// </summary>
        public override void WorkFlow()
        {
            Task.Factory.StartNew(base.WorkFlow);
        }

        protected override bool Proccess()
        {
            var files = LoadFiles();
            if (files == null || !files.Any())
                return false;
            files
                .Where(f => !TryAdd(f))
                .ForEach(e => _console.AddEvent(
                    e.Id.ToString(), ConsoleMessageType.Trace));
            return true;
        }

        /// <summary>
        /// Производит поиск и копирование новых файлов
        /// в дирректории сканирования.
        /// </summary>
        /// <returns>Список информации о файлах.</returns>
        public override IEnumerable<FileTransferInfo> LoadFiles()
        {
            try
            {
                string fileMask = _settings.Key(ArgsKeyList.ScanExt);
                return Directory
                    .GetFiles(_path, fileMask)
                    .Except(_removeList)
                    .Select(m => new FileInfo(m))
                    .Select(file =>
                    {
                        Guid id = Guid.NewGuid();
                        var newFileName = $"{_settings.Key(ArgsKeyList.StorePath)}\\{id}";
                        File.Copy(file.FullName, newFileName);
                        _removeList.Add(file.FullName);
                        return new FileTransferInfo
                        {
                            Id = id,
                            Size = file.Length,
                            Ext = file.Extension
                        };
                    });
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        private IEnumerable<FileTransferInfo> LoadFromFile(string fileName)
        {
            try
            {
                string json = File
                    .ReadAllLines(fileName)
                    .Aggregate((a, i) => a + i);

                File.Delete(fileName);

                return JsonConvert
                    .DeserializeObject<List<FileTransferInfo>>(json)
                    .AsEnumerable();
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        public override string Description => $"Копирование отсканированных файлов";
    }
}