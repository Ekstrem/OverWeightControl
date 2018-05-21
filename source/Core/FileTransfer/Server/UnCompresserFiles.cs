using System;
using System.IO;
using System.IO.Compression;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Core.FileTransfer.Server
{
    /// <summary>
    /// Сжимает файлы.
    /// </summary>
    public class UnCompresserFiles : WorkFlowDecoratorBase
    {
        #region Lifetime cicle

        internal UnCompresserFiles() { }

        [InjectionConstructor]
        public UnCompresserFiles(
            IWorkFlowProducerConsumer consumer,
            ISettingsStorage settings,
            IConsoleService console)
            : base(consumer, settings, console)
        {
            _console.AddEvent($"{nameof(UnCompresserFiles)} ready.");
        }

        ~UnCompresserFiles()
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
                if (!fileTransferInfo.IsCompresed)
                    return fileTransferInfo;

                using (Stream stream = new MemoryStream(fileTransferInfo.Data))
                using (Stream zip = new GZipStream(stream, CompressionMode.Decompress))
                using (MemoryStream result = new MemoryStream())
                {
                    zip.CopyTo(result);
                    fileTransferInfo.Data = result.ToArray();
                }

                return fileTransferInfo;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        public override string Description => $"Разжатие файлов";
    }
}