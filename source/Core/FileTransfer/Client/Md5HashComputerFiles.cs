using System;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Core.FileTransfer.Client
{
    /// <summary>
    /// Считает MD5 хэш файла.
    /// </summary>
    public class Md5HashComputerFiles : WorkFlowDecoratorBase
    {

        #region Lifetime cicle

        internal Md5HashComputerFiles()
        {
        }

        [InjectionConstructor]
        public Md5HashComputerFiles(
            IWorkFlowProducerConsumer consumer,
            ISettingsStorage settings,
            IConsoleService console)
            : base(consumer, settings, console)
        {
            _console.AddEvent($"{nameof(Md5HashComputerFiles)} ready.");
        }

        ~Md5HashComputerFiles()
        {
            Dispose();
        }

        public override void Dispose()
        {
            _console.AddEvent($"{nameof(Md5HashComputerFiles)} stoped.");
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
                if (fileTransferInfo.Hash == null)
                    fileTransferInfo.Hash = FileTransferInfo.GetHash(fileTransferInfo.Data);
                return fileTransferInfo.Hash.Equals(FileTransferInfo.GetHash(fileTransferInfo.Data))
                    ? fileTransferInfo
                    : null;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        public override string Description => $"Подсчёт хэша файлов";
    }
}