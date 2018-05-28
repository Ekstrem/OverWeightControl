using System;
using System.IO;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Core.FileTransfer.Client
{
    /// <summary>
    /// Загружает данные из файла.
    /// </summary>
    public class BufferedFiles : WorkFlowDecoratorBase
    {
        #region Lifetime cicle

        internal BufferedFiles() { }

        [InjectionConstructor]
        public BufferedFiles(
            IWorkFlowProducerConsumer consumer,
            ISettingsStorage settings,
            IConsoleService console)
            : base(consumer, settings, console)
        {
            _console.AddEvent($"{nameof(BufferedFiles)} ready.");
        }

        ~BufferedFiles()
        {
            Dispose();
        }

        /// <summary>
        ///   Выполняет определяемые приложением задачи, связанные с удалением, высвобождением или сбросом неуправляемых ресурсов.
        /// </summary>
        public override void Dispose()
        {
            _console.AddEvent($"{nameof(BufferedFiles)} stoped.");
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
            try
            {
                var fileName = $"{_settings.Key(ArgsKeyList.ScanPath)}\\{fileTransferInfo.Id}{fileTransferInfo.Ext}";
                fileTransferInfo.Data = File.ReadAllBytes(fileName);
                return fileTransferInfo;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        public override string Description =>
            WorkflowChainsDescriptions.GetDescription(this.GetType());
    }
}
