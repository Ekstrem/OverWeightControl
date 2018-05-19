using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Core.FileTransfer.Server
{
    public class SaveForAfcFiles : WorkFlowDecoratorBase, IDisposable
    {
        #region Lifetime cicle

        internal SaveForAfcFiles() { }

        [InjectionConstructor]
        public SaveForAfcFiles(
            IWorkFlowProducerConsumer consumer,
            ISettingsStorage settings,
            IConsoleService console)
            : base(consumer, settings, console)
        {
            _console.AddEvent($"{nameof(UnCompresserFiles)} ready.");
        }

        ~SaveForAfcFiles()
        {
            Dispose();
        }

        /// <summary>
        ///   Выполняет определяемые приложением задачи, связанные с удалением, высвобождением или сбросом неуправляемых ресурсов.
        /// </summary>
        public override void Dispose()
        {
            _console.AddEvent($"{nameof(UnCompresserFiles)} stoped.");
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
            var fileName = $"{_settings.Key(ArgsKeyList.AfcPath)}\\{fileTransferInfo.Id}.{fileTransferInfo.Ext}";
            File.WriteAllBytes(fileName, fileTransferInfo.Data);
            return null;
        }

        public override string Description => "Сохраненние файлов для AFC";
    }
}
