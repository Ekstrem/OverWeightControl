using System;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace OverWeightControl.Core.FileTransfer
{
    /// <summary>
    /// Класс хранящий информацию о пересылаемом файле.
    /// Для удалённого использования.
    /// </summary>
    [DataContract]
    public class FileTransferInfo : ICloneable
    {
        public FileTransferInfo() => IsCompresed = false;

        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public long Size { get; set; }
        [DataMember]
        public string Hash { get; set; }
        [DataMember]
        public string Ext { get; set; }

        [DataMember]
        public byte[] Data { get; set; }

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
    }
}
