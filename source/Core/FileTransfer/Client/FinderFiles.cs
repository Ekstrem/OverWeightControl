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
        private readonly IDictionary<string, Guid> _removeList;

        #region Lifetime

        public FinderFiles()
        {
            _queue = new ConcurrentQueue<FileTransferInfo>();
            _removeList = new Dictionary<string, Guid>();

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
            
            _removeList = new Dictionary<string, Guid>();

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
                if (CancelationToken != WorkFlowCancelationToken.Stoped)
                {
                    // save copied fileList info in file
                    string json = JsonConvert
                        .SerializeObject(_queue.ToList());
                    var fileName = $"{_settings.Key(ArgsKeyList.StorePath)}\\list.json";
                    File.WriteAllText(fileName, json);
                }
                else
                {
                    // Если всё завершается правильно, через CancelationToken, удаляются файлы.
                    var files = _queue
                        .Select(m => m.Id)
                        .ToList();
                    var filesToRemove = files.Any()
                        ? _removeList
                            .Where(f => files.Contains(f.Value))
                            .Select(m => m.Key)
                        : _removeList.Keys;
                    filesToRemove.ForEach(e =>
                    {
                        try
                        {
                            File.Delete(e);
                            _console.AddEvent($"File {e} was deleted.");
                        }
                        catch (Exception ex)
                        {
                            _console.AddException(ex);
                        }
                    });

                    _console.AddEvent($"{nameof(FinderFiles)} stoped.");
                }
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
                // Получение искомого расширения файлов.
                string fileMask = _settings.Key(ArgsKeyList.ScanExt);
                // Поиск файлов в ScanPath
                var files = fileMask
                    .Split('|')
                    .Select(m => m.Trim())
                    .Select(n => Directory.GetFiles(_path, n))
                    .SelectMany(strings => strings)
                    .Except(_removeList.Keys)
                    .Select(m => new FileInfo(m))
                    .AsEnumerable();
                
                var fties = new List<FileTransferInfo>();
                var newDirectory = _settings.Key(ArgsKeyList.StorePath);
                if (!Directory.Exists(newDirectory))
                    Directory.CreateDirectory(newDirectory);

                // Заполнение FileTrasportInfo.
                foreach (var file in files)
                {
                    Guid id = Guid.NewGuid();
                    File.Copy(file.FullName, $"{newDirectory}\\{id}");
                    _removeList.Add(file.FullName, id);
                    var fti = new FileTransferInfo
                    {
                        Id = id,
                        Size = file.Length,
                        Ext = file.Extension
                    };
                    fties.Add(fti);
                }

                return fties;
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