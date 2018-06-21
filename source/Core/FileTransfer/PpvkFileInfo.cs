using System;
using System.ComponentModel;
using Newtonsoft.Json;
using OverWeightControl.Common.Serialization;

namespace OverWeightControl.Core.FileTransfer
{
    /// <summary>
    /// Класс хранящий метаинформацию о пересылаемом файле.
    /// </summary>
    public class PpvkFileInfo : ParentBehavior<PpvkFileInfo>
    {
        public PpvkFileInfo()
        {
        }

        public PpvkFileInfo(FileTransferInfo fileTransferInfo)
        {
            Id = fileTransferInfo.Id;
            PpvkName = fileTransferInfo.PpvkName;
            Extention = fileTransferInfo.Ext;
            FindAtPpvkTime = fileTransferInfo.FindAtPpvkTime;
            ReciveFileTime = fileTransferInfo.ReciveFileTime;
            SaveToDbTime = fileTransferInfo.SaveToDbTime;
        }
        
        [JsonProperty]
        [DisplayName("Имя(№) ППВК")]
        public string PpvkName { get; set; }
        [JsonProperty]
        [DisplayName("Расширение файла.")]
        public string Extention { get; set; }
        [JsonProperty]
        [DisplayName("Время когда файл был найден после сканирования.")]
        public DateTime FindAtPpvkTime { get; set; }
        [JsonProperty]
        [DisplayName("Время когда файл был доставлен на обработку.")]
        public DateTime ReciveFileTime { get; set; }
        [JsonProperty]
        [DisplayName("Время когда данные были сохранены в БД.")]
        public DateTime SaveToDbTime { get; set; }
    }
}