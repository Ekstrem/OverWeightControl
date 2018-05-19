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
            var storeFileName = $"{_settings.Key(ArgsKeyList.StorePath)}\\{fileTransferInfo.Id}";
            var buFileName = $"{_settings.Key(ArgsKeyList.BackUpPath)}\\{fileTransferInfo.Id}.{fileTransferInfo.Ext}";
            File.Copy(storeFileName, buFileName);
            return fileTransferInfo;
        }

        public override string Description => "Копирование в BackUp";
    }
}
