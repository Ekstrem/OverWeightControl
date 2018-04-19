using System.Collections.Concurrent;

namespace OverWeightControl.Core.FileTransfer
{
    /// <summary>
    /// Менеджер отправки файлов.
    /// </summary>
    public abstract class FileTransferManager
    {
        public IProducerConsumerCollection<FileTransferInfo> FindedFiles { get; set; }

        public IProducerConsumerCollection<FileTransferInfo> BufferedFiles { get; set; }

        public IProducerConsumerCollection<FileTransferInfo> SendingFiles { get; set; }
    }
}
