using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Newtonsoft.Json;
using OverWeightControl.Common.Serialization;
using OverWeightControl.Core.Console;

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
            FindAtPpvkTime = DateTime.Parse(fileTransferInfo.FindAtPpvkTime);
            ReciveFileTime = DateTime.Parse(fileTransferInfo.ReciveFileTime);
            SaveToDbTime = DateTime.Parse(fileTransferInfo.SaveToDbTime);
        }
        
        [JsonProperty(Order = 1)]
        [DisplayName("Имя(№) ППВК")]
        public string PpvkName { get; set; }
        [JsonProperty(Order = 2)]
        [DisplayName("Расширение файла.")]
        public string Extention { get; set; }
        [JsonProperty(Order = 3)]
        [DisplayName("Время когда файл был найден после сканирования.")]
        public DateTime FindAtPpvkTime { get; set; }
        [JsonProperty(Order = 4)]
        [DisplayName("Время когда файл был доставлен на обработку.")]
        public DateTime ReciveFileTime { get; set; }
        [JsonProperty(Order = 5)]
        [DisplayName("Время когда данные были сохранены в БД.")]
        public DateTime SaveToDbTime { get; set; }
    }
}