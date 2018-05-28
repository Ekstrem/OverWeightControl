using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Core.FileTransfer
{
    /// <summary>
    /// Завершает очередь обработки файлов.
    /// </summary>
    public class FinalizeFiles : WorkFlowDecoratorBase
    {

        #region Lifetime cicle

        internal FinalizeFiles()
        {
        }

        [InjectionConstructor]
        public FinalizeFiles(
            IWorkFlowProducerConsumer consumer,
            ISettingsStorage settings,
            IConsoleService console)
            : base(consumer, settings, console)
        {
            _console.AddEvent($"{nameof(FinalizeFiles)} ready.");
        }

        ~FinalizeFiles()
        {
            Dispose();
        }

        public override void Dispose()
        {
            _console.AddEvent($"{nameof(FinalizeFiles)} stoped.");
            base.Dispose();
        }

        #endregion

        /// <summary>
        /// Производит операцию над файлом, согласно назначению класса.
        /// </summary>
        /// <param name="fileTransferInfo">Информация о классе.</param>
        /// <returns>Обработанный класс.</returns>
        protected override FileTransferInfo DetailedProc(FileTransferInfo fileTransferInfo)
        {
            return null;
        }

        public override IEnumerable<FileTransferInfo> LoadFiles()
        {
            var list = new List<FileTransferInfo>();
            FileTransferInfo fti = null;
            try
            {
                while (_consumer.TryTake(out fti)
                       && CancelationToken == WorkFlowCancelationToken.Started)
                {
                    var buf = DetailedProc(fti);
                    if (buf != null)
                    {
                        list.Add(buf);
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

        protected override bool Proccess() => LoadFiles().Any();

        public override string Description => "Очистка очереди";
    }
}