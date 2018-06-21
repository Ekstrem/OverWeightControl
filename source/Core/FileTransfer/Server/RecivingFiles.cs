using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.RemoteInteraction;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Core.FileTransfer.Server
{
    /// <summary>
    /// Часть цепочки ответственная за получение сообщений.
    /// Она же - обёртка над сервисом получения файлов.
    /// </summary>
    public class RecivingFiles :
        WorkFlowBase,
        IDisposable,
        IRemoteInteraction
    {
        private static Host _host;
        private static IProducerConsumerCollection<FileTransferInfo> s_ownBlackJackQueue;

        #region Lifetime

        [InjectionConstructor]
        public RecivingFiles(
            ISettingsStorage settings,
            IConsoleService console,
            Host host)
        : base(settings, console)
        {
            _host = host;
            if (s_ownBlackJackQueue == null)
                s_ownBlackJackQueue = new ConcurrentQueue<FileTransferInfo>();
            _console.AddEvent($"{nameof(RecivingFiles)} ready.");
        }

        ~RecivingFiles()
        {
            _console.AddEvent($"{nameof(RecivingFiles)} stoped.");
            Dispose();
        }

        public void Dispose()
        {
            if (CancelationToken == WorkFlowCancelationToken.Stoped)
                _host.Dispose();
        }

        #endregion

        public override bool TryAdd(FileTransferInfo item) => s_ownBlackJackQueue.TryAdd(item);

        public override bool TryTake(out FileTransferInfo item) => s_ownBlackJackQueue.TryTake(out item);

        public override int Count => s_ownBlackJackQueue.Count;

        /// <summary>
        /// Производит поиск и копирование новых файлов
        /// в дирректории сканирования.
        /// </summary>
        /// <returns>Список информации о файлах.</returns>
        public override IEnumerable<FileTransferInfo> LoadFiles()
        {
            return null;
        }

        protected override bool Proccess()
        {
            return false;
        }

        public override void WorkFlow() { }

        public override string Description => // "Получено файлов";
            WorkflowChainDescription.GetDescription(this.GetType());

        #region IRemoteInteraction
        
        /// <summary>
        /// Отправка файла.
        /// </summary>
        /// <param name="fileId">Имя файла.</param>
        /// <param name="stream">Данные файла.</param>
        /// <returns>Колличество полученных файлов.</returns>
        public SendResult SendFile(Guid fileId, FileTransferInfo stream)
        {
            stream.ReciveFileTime = DateTime.Now;
            TryAdd(stream);
            return SendResult.SimpleComplitedResult(fileId);
        }

        /// <summary>
        /// Отправка части файла.
        /// </summary>
        /// <param name="fileId">Имя файла.</param>
        /// <param name="partNum"></param>
        /// <param name="partCount">Колличество частей</param>
        /// <param name="stream">Данные файла.</param>
        /// <returns>Колличество полученных файлов.</returns>
        public bool SendFilePart(Guid fileId, int partNum, int partCount, byte[] stream)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Проверка частично отправляемого файла
        /// </summary>
        /// <param name="fileId">Имя файла.</param>
        /// <returns>Колличество полученных файлов.</returns>
        public SendResult CheckFile(Guid fileId)
        {
            throw new NotImplementedException();
        }

        public string Ping()
        {
            return "Pong";
        }

        #endregion

    }
}
