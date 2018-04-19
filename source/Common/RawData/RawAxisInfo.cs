using Newtonsoft.Json;

namespace OverWeightControl.Common.RawData
{
    /// <summary>
    /// Осевые нагрузки.
    /// </summary>
    [JsonObject]
    public class RawAxisInfo
    {
        /// <summary>
        /// Номер оси.
        /// </summary>
        [JsonProperty(Order = 1)]
        public RecognizedValue AxisNum { get; set; }

        /// <summary>
        /// Скатность.
        /// </summary>
        [JsonProperty(Order = 2)]
        public RecognizedValue AxisStinginess { get; set; }

        /// <summary>
        /// Тип подвески. 
        /// </summary>
        [JsonProperty(Order = 3)]
        public RecognizedValue SuspentionType { get; set; }

        /// <summary>
        /// Дистанция до следующей оси, в мм.
        /// </summary>
        [JsonProperty(Order = 4)]
        public RecognizedValue Distance2NextAxis { get; set; }

        /// <summary>
        /// Измерено, т.
        /// </summary>
        [JsonProperty(Order = 5)]
        public RecognizedValue MeasuredAsisWeight { get; set; }

        /// <summary>
        /// Норматив, т.
        /// </summary>
        [JsonProperty(Order = 6)]
        public RecognizedValue LegalAxisWeight { get; set; }

        /// <summary>
        /// Спец. разр., т.
        /// </summary>
        [JsonProperty(Order = 7)]
        public RecognizedValue SpecialAllow { get; set; }

        /// <summary>
        /// Применяемые, т.
        /// </summary>
        [JsonProperty(Order = 8)]
        public RecognizedValue UsedAxisAllow { get; set; }

        /// <summary>
        /// Учит.превыш., т.
        /// </summary>
        [JsonProperty(Order = 9)]
        public RecognizedValue WeightRecordedExcess { get; set; }

        /// <summary>
        /// Учит. превыш., %.
        /// </summary>
        [JsonProperty(Order = 10)]
        public RecognizedValue PercentRecordedExcess { get; set; }

        /// <summary>
        /// Перегруз.
        /// </summary>
        [JsonProperty(Order = 11)]
        public RecognizedValue Overweight { get; set; }
    }
}
