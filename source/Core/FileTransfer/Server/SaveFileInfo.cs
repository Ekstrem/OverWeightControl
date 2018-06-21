using System;
using System.IO;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Core.FileTransfer.Server
{
    public class SaveFileInfo : WorkFlowDecoratorBase, IDisposable
    {
        #region Lifetime cicle

        internal SaveFileInfo() { }

        [InjectionConstructor]
        public SaveFileInfo(
            IWorkFlowProducerConsumer consumer,
            ISettingsStorage settings,
            IConsoleService console)
            : base(consumer, settings, console)
        {
            _console.AddEvent($"{nameof(SaveFileInfo)} ready.");
        }

        ~SaveFileInfo()
        {
            Dispose();
        }

        /// <summary>
        ///   Выполняет определяемые приложением задачи, связанные с удалением, высвобождением или сбросом неуправляемых ресурсов.
        /// </summary>
        public override void Dispose()
        {
            _console.AddEvent($"{nameof(SaveFileInfo)} stoped.");
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
                var info = new PpvkFileInfo(fileTransferInfo);
                var directory = _settings[ArgsKeyList.BackUpPath];
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                var path = $"{directory}\\{fileTransferInfo.Id}.details";
                File.WriteAllText(path, info.ToJson());
                return fileTransferInfo;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        public override string Description => // "Сохраненние файлов для AFC";
            WorkflowChainDescription.GetDescription(this.GetType());
    }
}
