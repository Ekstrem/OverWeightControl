using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OverWeightControl.Common.RawData;
using OverWeightControl.Common.Serialization;

namespace OverWeightControl.Common.Model
{
    /// <summary>
    /// Осевые нагрузки.
    /// </summary>
    [JsonObject]
    public class AxisInfo : ParentBehavior<AxisInfo>
    {
        /// <summary>
        /// Конструктор данных.
        /// </summary>
        public AxisInfo() { }

        /// <summary>
        /// Конструктор данных.
        /// </summary>
        /// <param name="rawAxisInfo"></param>
        public AxisInfo(RawAxisInfo rawAxisInfo)
        {
            AxisNum = (rawAxisInfo.AxisNum.RecognizedAccuracy ==
                       RecognizedValue.MaxAccuracy)
                ? rawAxisInfo.AxisNum.Value
                : string.Empty;
            AxisStinginess = (rawAxisInfo.AxisStinginess.RecognizedAccuracy ==
                              RecognizedValue.MaxAccuracy)
                ? int.Parse(rawAxisInfo.AxisStinginess.Value)
                : -1;
            SuspentionType = (rawAxisInfo.SuspentionType.RecognizedAccuracy ==
                              RecognizedValue.MaxAccuracy)
                ? rawAxisInfo.SuspentionType.Value
                : string.Empty;
            Distance2NextAxis = (rawAxisInfo.Distance2NextAxis.RecognizedAccuracy ==
                                 RecognizedValue.MaxAccuracy)
                ? int.Parse(rawAxisInfo.Distance2NextAxis.Value)
                : -1;
            MeasuredAsisWeight = (rawAxisInfo.MeasuredAsisWeight.RecognizedAccuracy ==
                                  RecognizedValue.MaxAccuracy)
                ? float.Parse(rawAxisInfo.MeasuredAsisWeight.Value)
                : -1;
            LegalAxisWeight = (rawAxisInfo.LegalAxisWeight.RecognizedAccuracy ==
                               RecognizedValue.MaxAccuracy)
                ? float.Parse(rawAxisInfo.LegalAxisWeight.Value)
                : -1;
            SpecialAllow = (rawAxisInfo.SpecialAllow.RecognizedAccuracy ==
                            RecognizedValue.MaxAccuracy)
                ? float.Parse(rawAxisInfo.SpecialAllow.Value)
                : -1;
            UsedAxisAllow = (rawAxisInfo.UsedAxisAllow.RecognizedAccuracy ==
                             RecognizedValue.MaxAccuracy)
                ? float.Parse(rawAxisInfo.UsedAxisAllow.Value)
                : -1;
            WeightRecordedExcess = (rawAxisInfo.WeightRecordedExcess.RecognizedAccuracy ==
                                    RecognizedValue.MaxAccuracy)
                ? float.Parse(rawAxisInfo.WeightRecordedExcess.Value)
                : -1;
            PercentRecordedExcess = (rawAxisInfo.PercentRecordedExcess.RecognizedAccuracy ==
                                     RecognizedValue.MaxAccuracy)
                ? float.Parse(rawAxisInfo.PercentRecordedExcess.Value)
                : -1;
            Overweight = (rawAxisInfo.AxisNum.RecognizedAccuracy ==
                          RecognizedValue.MaxAccuracy)
                ? rawAxisInfo.Overweight.Value
                : string.Empty;
        }

        /// <summary>
        /// Номер оси.
        /// </summary>
        [JsonProperty(Order = 1)]
        [StringLength(2)]
        public string AxisNum { get; set; }

        /// <summary>
        /// Скатность.
        /// </summary>
        [JsonProperty(Order = 2)]
        public int AxisStinginess { get; set; }

        /// <summary>
        /// Тип подвески. 
        /// </summary>
        [JsonProperty(Order = 3)]
        [StringLength(8)]
        public string SuspentionType { get; set; }

        /// <summary>
        /// Дистанция до следующей оси, в мм.
        /// </summary>
        [JsonProperty(Order = 4)]
        public int Distance2NextAxis { get; set; }

        /// <summary>
        /// Измерено, т.
        /// </summary>
        [JsonProperty(Order = 5)]
        public float MeasuredAsisWeight { get; set; }

        /// <summary>
        /// Норматив, т.
        /// </summary>
        [JsonProperty(Order = 6)]
        public float LegalAxisWeight { get; set; }

        /// <summary>
        /// Спец. разр., т.
        /// </summary>
        [JsonProperty(Order = 7)]
        public float SpecialAllow { get; set; }

        /// <summary>
        /// Применяемые, т.
        /// </summary>
        [JsonProperty(Order = 8)]
        public float UsedAxisAllow { get; set; }

        /// <summary>
        /// Учит.превыш., т.
        /// </summary>
        [JsonProperty(Order = 9)]
        public float WeightRecordedExcess { get; set; }

        /// <summary>
        /// Учит. превыш., %.
        /// </summary>
        [JsonProperty(Order = 10)]
        public float PercentRecordedExcess { get; set; }

        /// <summary>
        /// Перегруз.
        /// </summary>
        [JsonProperty(Order = 11)]
        [StringLength(8)]
        public string Overweight { get; set; }

        /// <summary>
        ///   Определяет, равен ли заданный объект текущему объекту.
        /// </summary>
        /// <param name="obj">
        ///   Объект, который требуется сравнить с текущим объектом.
        /// </param>
        /// <returns>
        ///   Значение <see langword="true" />, если указанный объект равен текущему объекту; в противном случае — значение <see langword="false" />.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is AxisInfo other
                && string.Equals(AxisNum, other?.AxisNum) 
                   && AxisStinginess == other?.AxisStinginess 
                   && string.Equals(SuspentionType, other?.SuspentionType)
                   && Distance2NextAxis == other?.Distance2NextAxis 
                   && MeasuredAsisWeight.Equals(other?.MeasuredAsisWeight) 
                   && LegalAxisWeight.Equals(other?.LegalAxisWeight) 
                   && SpecialAllow.Equals(other?.SpecialAllow) 
                   && UsedAxisAllow.Equals(other?.UsedAxisAllow) 
                   && WeightRecordedExcess.Equals(other?.WeightRecordedExcess) 
                   && PercentRecordedExcess.Equals(other?.PercentRecordedExcess) 
                   && string.Equals(Overweight, other?.Overweight);
        }

        /// <summary>Служит хэш-функцией по умолчанию.</summary>
        /// <returns>Хэш-код для текущего объекта.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (AxisNum != null ? AxisNum.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ AxisStinginess;
                hashCode = (hashCode * 397) ^ (SuspentionType != null ? SuspentionType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Distance2NextAxis;
                hashCode = (hashCode * 397) ^ MeasuredAsisWeight.GetHashCode();
                hashCode = (hashCode * 397) ^ LegalAxisWeight.GetHashCode();
                hashCode = (hashCode * 397) ^ SpecialAllow.GetHashCode();
                hashCode = (hashCode * 397) ^ UsedAxisAllow.GetHashCode();
                hashCode = (hashCode * 397) ^ WeightRecordedExcess.GetHashCode();
                hashCode = (hashCode * 397) ^ PercentRecordedExcess.GetHashCode();
                hashCode = (hashCode * 397) ^ (Overweight != null ? Overweight.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
