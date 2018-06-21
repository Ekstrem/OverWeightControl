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
        private readonly ICollection<Guid> _addedFiles;

        #region Lifetime

        public FinderFiles()
        {
            _queue = new ConcurrentQueue<FileTransferInfo>();
            _addedFiles = new HashSet<Guid>();

            CancelationToken = WorkFlowCancelationToken.Stoped;
        }

        [InjectionConstructor]
        public FinderFiles(
            ISettingsStorage settings,
            IConsoleService console)
            : base(settings, console)
        {
            _path =
                _settings?[ArgsKeyList.ScanPath]
                ?? AppDomain.CurrentDomain.BaseDirectory;

            _queue = new ConcurrentQueue<FileTransferInfo>();
            _addedFiles = new HashSet<Guid>();

            CancelationToken = WorkFlowCancelationToken.Ready;

            _console.AddEvent($"{nameof(FinderFiles)} ready.");
        }

        ~FinderFiles()
        {
            Dispose();
        }

        public void Dispose()
        {
            _addedFiles.Clear();
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
                string fileMask = _settings[ArgsKeyList.ScanExt];
                // Поиск файлов в ScanPath
                var files = fileMask
                    .Split('|')
                    .Select(m => m.Trim())
                    .Select(n => Directory.GetFiles(_path, n))
                    .SelectMany(strings => strings)
                    .Select(m => new FileInfo(m))
                    .AsEnumerable();
                
                var fties = new List<FileTransferInfo>();
                // Заполнение FileTrasportInfo.
                foreach (var file in files)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file.FullName);
                    bool isGuidName = Guid.TryParse(fileName, out Guid result);
                    var fti = new FileTransferInfo
                    {
                        Id = isGuidName ? result : Guid.NewGuid(),
                        Size = file.Length,
                        Ext = file.Extension,
                        FindAtPpvkTime = DateTime.Now
                    };

                    if (!isGuidName)
                    {
                        File.Move(file.FullName, $"{_path}\\{fti.Id}{fti.Ext}");
                        _console.AddEvent($"Файл {file.Name} добавлен в очередь с GUID {fti.Id}");
                    }

                    if (!_addedFiles.Contains(fti.Id))
                    {
                        fties.Add(fti);
                        _addedFiles.Add(fti.Id);
                    }
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

        public override string Description => // $"Копирование отсканированных файлов";
            WorkflowChainDescription.GetDescription(this.GetType());
    }
}