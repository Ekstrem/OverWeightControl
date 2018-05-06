using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Settings;

namespace OverWeightControl.Core.FileTransfer.WorkFlow
{
    public abstract class WorkFlowBase : IWorkFlowProducerConsumer, IWorkflowStatistic
    {
        protected IProducerConsumerCollection<FileTransferInfo> _queue;
        protected readonly ISettingsStorage _settings;
        protected readonly IConsoleService _console;

        protected WorkFlowBase() { }

        protected WorkFlowBase(
            ISettingsStorage settings,
            IConsoleService console)
        {
            if (settings == null)
            {
                new ArgumentNullException(nameof(settings));
            }
            _settings = settings;

            if (console==null)
            {
                new ArgumentNullException(nameof(console));
            }
            _console = console;
        }


        /// <summary>
        ///   Пытается добавить объект в коллекцию <see cref="T:System.Collections.Concurrent.IProducerConsumerCollection`1" />.
        /// </summary>
        /// <param name="item">
        ///   Объект, добавляемый в коллекцию <see cref="T:System.Collections.Concurrent.IProducerConsumerCollection`1" />.
        /// </param>
        /// <returns>
        ///   Значение true, если объект был успешно добавлен; в противном случае — значение false.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="item" /> Недопустим для данной коллекции.
        public virtual bool TryAdd(FileTransferInfo item) => _queue.TryAdd(item);
        
        /// <summary>
        ///   Пытается удалить и вернуть объект из коллекции <see cref="T:System.Collections.Concurrent.IProducerConsumerCollection`1" />.
        /// </summary>
        /// <param name="item">
        ///   При возвращении данного метода, если объект был успешно удален и возвращен, <paramref name="item" /> содержит удаленный объект.
        ///    Если объект, доступный для удаления, не найден, значение не определено.
        /// </param>
        /// <returns>
        ///   значение true, если объект был успешно удален и возвращен; в противном случае — значение false.
        /// </returns>
        public virtual bool TryTake(out FileTransferInfo item) => _queue.TryTake(out item);

        public abstract IEnumerable<FileTransferInfo> LoadFiles();
        
        /// <summary>
        /// Рабочий процесс по передаче файлов.
        /// </summary>
        public virtual void WorkFlow()
        {
            try
            {
                CancelationToken = WorkFlowCancelationToken.Started;
                var ct = CancelationToken;

                while (ct != WorkFlowCancelationToken.Stoped)
                {
                    if (ct == WorkFlowCancelationToken.Started)
                    {
                        Proccess();
                    }

                    Thread.Sleep(1000 * int.Parse(_settings.Key(ArgsKeyList.WFProcWaitingFor)));

                    lock (this)
                    {
                        ct = CancelationToken;
                    }
                }
            }
            catch (Exception e)
            {
                _console.AddException(e);
            }
        }

        protected virtual bool Proccess()
        {
            var loadedFiles = LoadFiles().Where(f => f != null).ToList();
            return loadedFiles.Any() && loadedFiles.Select(TryAdd).All(p => p);
        }



        public virtual WorkFlowCancelationToken CancelationToken { get; set; }

        public int Count => _queue.Count;

        public abstract string Description { get; }
        public IDictionary<string, int> GetStatistic()
        {
            var dic = new Dictionary<string, int>
            {
                { Description, Count }
            };
            return dic;
        }
    }
}