using System;
using System.IO;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Core.FileTransfer
{
    /// <summary>
    /// Отправляет файлы на BackUp.
    /// </summary>
    public class BackUpFiles : WorkFlowDecoratorBase
    {

        #region Lifetime cicle

        internal BackUpFiles()
        {
        }

        [InjectionConstructor]
        public BackUpFiles(
            IWorkFlowProducerConsumer consumer,
            ISettingsStorage settings,
            IConsoleService console)
            : base(consumer, settings, console)
        {
            _console.AddEvent($"{nameof(BackUpFiles)} ready.");
        }

        ~BackUpFiles()
        {
            Dispose();
        }

        public override void Dispose()
        {
            _console.AddEvent($"{nameof(BackUpFiles)} stoped.");
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
                string directory = _settings[ArgsKeyList.BackUpPath];
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                var oldFile = $"{_settings[ArgsKeyList.StorePath]}\\{fileTransferInfo.Id}";
                var newFile = $"{directory}\\{fileTransferInfo.Id};{fileTransferInfo.PpvkName}.{fileTransferInfo.Ext}";
                if (File.Exists(oldFile))
                {
                    File.Copy(oldFile, newFile);
                }
                else
                {
                    File.WriteAllBytes(newFile, fileTransferInfo.Data);
                }

                return fileTransferInfo;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        public override string Description => // "Копирование в BackUp";
            WorkflowChainDescription.GetDescription(this.GetType());
    }
}
