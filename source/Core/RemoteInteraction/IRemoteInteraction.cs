using System;
using System.ServiceModel;
using OverWeightControl.Core.FileTransfer;

namespace OverWeightControl.Core.RemoteInteraction
{
    /// <summary>
    /// Интерфейс передачи файлов.
    /// </summary>
    [ServiceContract]
    public interface IRemoteInteraction
    {
        /// <summary>
        /// Отправка файла.
        /// </summary>
        /// <param name="fileId">Имя файла.</param>
        /// <param name="stream">Данные файла.</param>
        /// <returns>Колличество полученных файлов.</returns>
        [OperationContract]
        SendResult SendFile(Guid fileId, FileTransferInfo stream);

        /// <summary>
        /// Отправка части файла.
        /// </summary>
        /// <param name="fileId">Имя файла.</param>
        /// <param name="partNum"></param>
        /// <param name="partCount">Колличество частей</param>
        /// <param name="stream">Данные файла.</param>
        /// <returns>Колличество полученных файлов.</returns>
        [OperationContract]
        bool SendFilePart(Guid fileId, int partNum, int partCount, byte[] stream);

        /// <summary>
        /// Проверка частично отправляемого файла
        /// </summary>
        /// <param name="fileId">Имя файла.</param>
        /// <returns>Колличество полученных файлов.</returns>
        [OperationContract]
        SendResult CheckFile(Guid fileId);

        [OperationContract]
        string Ping();
    }
}
