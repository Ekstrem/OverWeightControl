using System;
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

        protected override bool Proccess() => LoadFiles().Any();

        public override string Description => "Удаление файлов";
    }
}