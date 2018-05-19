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
    /// Удаляет файлы.
    /// </summary>
    public class DeleteFiles : WorkFlowDecoratorBase
    {

        #region Lifetime cicle

        internal DeleteFiles()
        {
        }

        [InjectionConstructor]
        public DeleteFiles(
            IWorkFlowProducerConsumer consumer,
            ISettingsStorage settings,
            IConsoleService console)
            : base(consumer, settings, console)
        {
            _console.AddEvent($"{nameof(DeleteFiles)} ready.");
        }

        ~DeleteFiles()
        {
            Dispose();
        }

        public override void Dispose()
        {
            _console.AddEvent($"{nameof(DeleteFiles)} stoped.");
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
            var storeFileName = $"{_settings.Key(ArgsKeyList.StorePath)}\\{fileTransferInfo.Id}";
            File.Delete(storeFileName);
            return fileTransferInfo;
        }

        protected override bool Proccess() => LoadFiles().Any();

        public override string Description => "Удаление файлов";
    }
}