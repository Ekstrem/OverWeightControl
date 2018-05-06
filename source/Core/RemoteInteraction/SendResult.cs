using System;
using System.Runtime.Serialization;
using Guid = System.Guid;

namespace OverWeightControl.Core.RemoteInteraction
{
    /// <summary>
    /// Результат передачи файла.
    /// </summary>
    [DataContract]
    public class SendResult
    {
        public SendResult() : this(Guid.Empty, 0, false) { }

        public SendResult(Guid fileId, int dataSize, bool commited = true)
        {
            FileId = fileId;
            DataSize = dataSize;
            Commited = commited;
            ResultHash = string.Empty;
        }

        /// <summary>
        /// Простой фабричный метод.
        /// </summary>
        /// <param name="fileId">Имя файла.</param>
        /// <returns>Результат c пустыми полями</returns>
        public static SendResult SimpleComplitedResult(Guid fileId)
        {
            return new SendResult(fileId, 0);
        }
        
        /// <summary>
        /// Имя файла.
        /// </summary>
        [DataMember]
        public Guid FileId { get; set; }

        /// <summary>
        /// Файл удачно получен
        /// </summary>
        [DataMember]
        public bool Commited { get; set; }
        /// <summary>
        /// Размер полученных данных.
        /// </summary>
        [DataMember]
        public long DataSize { get; set; }

        /// <summary>
        /// Результирующий хэш.
        /// </summary>
        [DataMember]
        public string ResultHash { get; set; }
    }
}