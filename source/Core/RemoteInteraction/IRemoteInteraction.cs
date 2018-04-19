using System.Collections.Generic;
using OverWeightControl.Core.FileTransfer;

namespace OverWeightControl.Core.RemoteInteraction
{
    /// <summary>
    /// Интерфейс передачи файлов.
    /// </summary>
    interface IFileTransfer
    {
        /// <summary>
        /// Инициирует соединение трасфера файлов.
        /// Пересылает список файлов.
        /// </summary>
        /// <param name="sendList">Список информации о передаваемых файлах.</param>
        /// <returns>Список информации о не дошедших файлах.</returns>
        ICollection<FileTransferInfo> SendList(ICollection<FileTransferInfo> sendList);

        /// <summary>
        /// Отправка файла.
        /// </summary>
        /// <param name="stream">Данные файла.</param>
        /// <returns>Колличество полученных файлов.</returns>
        long SendFile(byte[] stream);
    }
}
