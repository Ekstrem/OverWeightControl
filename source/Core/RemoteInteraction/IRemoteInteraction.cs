using System;
using OverWeightControl.Core.FileTransfer;

namespace OverWeightControl.Core.RemoteInteraction
{
    /// <summary>
    /// Интерфейс передачи файлов.
    /// </summary>
    public interface IRemoteInteraction
    {
        /// <summary>
        /// Отправка файла.
        /// </summary>
        /// <param name="fileId">Имя файла.</param>
        /// <param name="stream">Данные файла.</param>
        /// <returns>Колличество полученных файлов.</returns>
        SendResult SendFile(Guid fileId, FileTransferInfo stream);

        /// <summary>
        /// Отправка части файла.
        /// </summary>
        /// <param name="fileId">Имя файла.</param>
        /// <param name="partNum"></param>
        /// <param name="partCount">Колличество частей</param>
        /// <param name="stream">Данные файла.</param>
        /// <returns>Колличество полученных файлов.</returns>
        bool SendFilePart(Guid fileId, int partNum, int partCount, byte[] stream);

        /// <summary>
        /// Проверка частично отправляемого файла
        /// </summary>
        /// <param name="fileId">Имя файла.</param>
        /// <returns>Колличество полученных файлов.</returns>
        SendResult CheckFile(Guid fileId);
    }
}
