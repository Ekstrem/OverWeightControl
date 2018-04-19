using System.Collections.Generic;
using Newtonsoft.Json;

namespace OverWeightControl.Common.RawData
{
    /// <summary>
    /// Информация о грузе.
    /// </summary>
    [JsonObject]
    public class RawCargoInfo
    {
        /// <summary>
        /// Характеристика груза.
        /// </summary>
        [JsonProperty(Order = 1)]
        public RecognizedValue CargoCharacter { get; set; }
        /// <summary>
        /// Вид груза.
        /// </summary>
        [JsonProperty(Order = 2)]
        public RecognizedValue CargoType { get; set; }

        /// <summary>
        /// Нормативная масса.
        /// </summary>
        [JsonProperty(Order = 3)]
        public RecognizedValue LegalWeight { get; set; }

        /// <summary>
        /// Допустимая масса.
        /// </summary>
        [JsonProperty(Order = 4)]
        public RecognizedValue ValetWeight { get; set; }

        /// <summary>
        /// Фактическая масса.
        /// </summary>
        [JsonProperty(Order = 5)]
        public RecognizedValue FactWeight { get; set; }

        /// <summary>
        /// Процент перевеса.
        /// </summary>
        [JsonProperty(Order = 7)]
        public RecognizedValue PercentWeightOverflow { get; set; }

        /// <summary>
        /// Специальное разрешение.
        /// </summary>
        [JsonProperty(Order = 6)]
        public RecognizedValue CargoSpecialAllow { get; set; }

        /// <summary>
        /// Участок дороги.
        /// </summary>
        [JsonProperty(Order = 8)]
        public RecognizedValue RoadSection { get; set; }

        /// <summary>
        /// Тарифы. Указаны за 100км.
        /// </summary>
        [JsonProperty(Order = 9)]
        public RecognizedValue Tariffs { get; set; }

        /// <summary>
        /// Длина участка.
        /// </summary>
        [JsonProperty(Order = 10)]
        public RecognizedValue LegLength { get; set; }

        /// <summary>
        /// Информация по осям.
        /// </summary>
        [JsonProperty(Order = 11)]
        public ICollection<RawAxisInfo> Axises { get; set; }

        /// <summary>
        /// Сведения о ГТС в реестре действующих пропусков,
        /// предоставляющих право она въезд и передвижение
        /// в зонах ограничения движения по г. Москва.
        /// </summary>
        [JsonProperty(Order = 12)]
        public RecognizedValue Pass { get; set; }

        /// <summary>
        /// Другие нарушения.
        /// </summary>
        [JsonProperty(Order = 13)]
        public RecognizedValue OtherViolation { get; set; }

        /// <summary>
        /// Объяснение водителя.
        /// </summary>
        [JsonProperty(Order = 14)]
        public RecognizedValue DriverExplanation { get; set; }
    }
}