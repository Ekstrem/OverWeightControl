using System;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace OverWeightControl.Core.FileTransfer
{
    /// <summary>
    /// Класс хранящий информацию о пересылаемом файле.
    /// Для удалённого использования.
    /// </summary>
    [DataContract]
    [JsonObject]
    public class FileTransferInfo : ICloneable
    {
        public FileTransferInfo() => IsCompresed = false;

        [DataMember]
        [JsonProperty]
        public Guid Id { get; set; }
        [DataMember]
        [JsonProperty]
        public long Size { get; set; }
        [DataMember]
        [JsonProperty]
        public string Hash { get; set; }
        [DataMember]
        [JsonProperty]
        public string Ext { get; set; }

        [DataMember]
        [JsonProperty]
        public byte[] Data { get; set; }

        [DataMember]
        [JsonProperty]
        public bool IsCompresed { get; set; }

        /// <summary>
        ///   Создает новый объект, являющийся копией текущего экземпляра.
        /// </summary>
        /// <returns>Новый объект, являющийся копией этого экземпляра.</returns>
        public object Clone()
        {
            return new FileTransferInfo
            {
                Id = this.Id,
                Size = this.Size,
                Ext = this.Ext,
                Hash = this.Hash,
                Data = this.Data
            };
        }

        /// <summary>Возвращает строку, представляющую текущий объект.</summary>
        /// <returns>Строка, представляющая текущий объект.</returns>
        public override string ToString()
        {
            return $"ID:{Id}; Ext:{Ext}; Size:{Size}";
        }

        public static string GetHash(byte[] data)
        {
            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(data);
            return Encoding.UTF8.GetString(md5.ComputeHash(hash));
        }

        public static implicit operator Guid(FileTransferInfo file) => file.Id;
        public static implicit operator string(FileTransferInfo file) => file.ToString();
        public static implicit operator byte[](FileTransferInfo file) => file.Data;
    }
}
