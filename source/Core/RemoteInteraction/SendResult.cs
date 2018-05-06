using System.Runtime.Serialization;
using Newtonsoft.Json;
using Guid = System.Guid;

namespace OverWeightControl.Core.RemoteInteraction
{
    /// <summary>
    /// Результат передачи файла.
    /// </summary>
    [DataContract]
    [JsonObject]
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
        [JsonProperty]
        public Guid FileId { get; set; }

        /// <summary>
        /// Файл удачно получен
        /// </summary>
        [DataMember]
        [JsonProperty]
        public bool Commited { get; set; }
        /// <summary>
        /// Размер полученных данных.
        /// </summary>
        [DataMember]
        [JsonProperty]
        public long DataSize { get; set; }

        /// <summary>
        /// Результирующий хэш.
        /// </summary>
        [DataMember]
        [JsonProperty]
        public string ResultHash { get; set; }
    }
}