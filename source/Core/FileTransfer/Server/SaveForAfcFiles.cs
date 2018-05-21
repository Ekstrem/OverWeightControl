using System;
using System.IO;
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
            try
            {
                string directory = _settings.Key(ArgsKeyList.AfcPath);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                var fileName = $"{directory}\\{fileTransferInfo.Id}.{fileTransferInfo.Ext}";
                File.WriteAllBytes(fileName, fileTransferInfo.Data);
                return fileTransferInfo;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        public override string Description => "Сохраненние файлов для AFC";
    }
}
