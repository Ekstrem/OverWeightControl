using Newtonsoft.Json;
using OverWeightControl.Common.Serialization;

namespace OverWeightControl.Common.RawData
{
    /// <summary>
    /// Основной класс - акт о превышении нагрузки.
    /// </summary>
    [JsonObject]
    public class RawAct : ParentBehavior<RawAct>
    {
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public RawAct() : base() { }

        /// <summary>
        /// Номер акта.
        /// </summary>
        [JsonProperty(Order = 1)]
        public RecognizedValue ActNumber { get; set; }

        /// <summary>
        /// Дата Акта.
        /// DD.MM.YYYY
        /// </summary>
        [JsonProperty(Order = 2)]
        public RecognizedValue ActDate { get; set; }

        /// <summary>
        /// Время акта.
        /// HH:mm:ss
        /// </summary>
        [JsonProperty(Order = 3)]
        public RecognizedValue ActTime { get; set; }

        /// <summary>
        /// Номер ППВК.
        /// value>0.
        /// </summary>
        [JsonProperty(Order = 4)]
        public RecognizedValue PpvkNumber { get; set; }

        /// <summary>
        /// Место проведения контроля (взвешивания).
        /// </summary>
        [JsonProperty(Order = 5)]
        public RecognizedValue WeightPoint { get; set; }

        /// <summary>
        /// Весовое оборудование.
        /// </summary>
        [JsonProperty(Order = 6)]
        public RawWeighterInfo Weighter { get; set; }

        /// <summary>
        /// Сведения о ТС.
        /// </summary>
        [JsonProperty(Order = 7)]
        public RawVehicleInfo Vehicle { get; set; }

        /// <summary>
        /// Водитель ТС.
        /// </summary>
        [JsonProperty(Order = 8)]
        public RawDriverInfo Driver { get; set; }

        /// <summary>
        /// Информация о грузе.
        /// </summary>
        [JsonProperty(Order = 9)]
        public RawCargoInfo Cargo { get; set; }
    }
}
