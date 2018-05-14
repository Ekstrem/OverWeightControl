using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Settings;

namespace OverWeightControl.Core.FileTransfer.WorkFlow
{
    public abstract class WorkFlowDecoratorBase : WorkFlowBase, IDisposable
    {
        private readonly IWorkFlowProducerConsumer _consumer;

        #region Lifetime

        protected WorkFlowDecoratorBase()
        {
            _queue = new ConcurrentQueue<FileTransferInfo>();
            CancelationToken = WorkFlowCancelationToken.Ready;
        }

        protected WorkFlowDecoratorBase(
            IWorkFlowProducerConsumer consumer,
            ISettingsStorage settings,
            IConsoleService console)
            : base(settings, console)
        {
            _consumer = consumer ?? throw new ArgumentNullException(nameof(consumer));

            _queue = new ConcurrentQueue<FileTransferInfo>();
            CancelationToken = WorkFlowCancelationToken.Ready;
        }

        public virtual void Dispose() { }

        #endregion

        /// <summary>
        /// Рабочий процесс по передаче файлов.
        /// </summary>
        public override void WorkFlow()
        {
            _consumer.WorkFlow();
            Task.Factory.StartNew(base.WorkFlow);
        }

        /// <summary>
        /// Производит операцию над файлом, согласно назначению класса.
        /// </summary>
        /// <param name="fileTransferInfo">Информация о классе.</param>
        /// <returns>Обработанный класс.</returns>
        protected virtual FileTransferInfo DetailedProc(
            FileTransferInfo fileTransferInfo) => fileTransferInfo;

        /// <summary>
        /// Производит поиск и копирование новых файлов
        /// в дирректории сканирования.
        /// </summary>
        /// <returns>Список информации о файлах.</returns>
        public override IEnumerable<FileTransferInfo> LoadFiles()
        {
            var list = new List<FileTransferInfo>();
            FileTransferInfo fti = null;
            try
            {
                while (_consumer.TryTake(out fti))
                {
                    var buf = DetailedProc(fti);
                    if (buf != null)
                    {
                        list.Add(buf);
                    }
                    else
                    {
                        // Если возникла ошибка, ошибочный экземляр вернётся.
                        if (fti != null)
                        {
                            _consumer.TryAdd(fti);
                            _console.AddEvent($"Maybe corrupted: {fti}", ConsoleMessageType.Trace);
                        }
                    }
                }

                return list;
            }
            catch (Exception e)
            {
                _console.AddException(e);

                #region Return to parrent queue

                // Если возникла ошибка, ошибочный экземляр вернётся.
                if (fti != null)
                {
                    _consumer.TryAdd(fti);
                    _console.AddEvent($"Maybe corrupted: {fti}", ConsoleMessageType.Trace);
                }

                // Также при ошибке возращаются вся обработанная часть.
                if (list.Count > 0)
                {
                    list.ForEach(item => _queue.TryAdd(item));
                }

                #endregion

                return null;
            }
        }

        public sealed override WorkFlowCancelationToken CancelationToken
        {
            get => base.CancelationToken;
            set
            {
                _consumer.CancelationToken = value;
                base.CancelationToken = value;
            }
        }

        public override IDictionary<string, int> GetStatistic()
        {
            var dic = new Dictionary<string, int>(
                ((IWorkflowStatistic)_consumer).GetStatistic()) {{Description, Count}};
            return dic;
        }
    }
}
