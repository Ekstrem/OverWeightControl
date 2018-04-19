using System.Collections.Generic;
using Newtonsoft.Json;

namespace OverWeightControl.Common.RawData
{
    /// <summary>
    /// Сведения о ТС.
    /// </summary>
    [JsonObject]
    public class RawVehicleInfo
    {
        /// <summary>
        /// Общее о ТС.
        /// </summary>
        [JsonProperty(Order = 1)]
        public ICollection<RawVehicleDetail> Detail { get; set; }

        /// <summary>
        /// Наименование владельца (собственника) ТС,
        /// осуществляющего перевозку тяжеловесного груза.
        /// </summary>
        [JsonProperty(Order = 2)]
        public RecognizedValue VehicleOwner { get; set; }

        /// <summary>
        /// Страна регистрации.
        /// </summary>
        [JsonProperty(Order = 3)]
        public RecognizedValue VehicleCountry { get; set; }

        /// <summary>
        /// Код субъекта.
        /// </summary>
        [JsonProperty(Order = 4)]
        public RecognizedValue VehicleSubjectCode { get; set; }

        /// <summary>
        /// Адрес организации.
        /// </summary>
        [JsonProperty(Order = 5)]
        public RecognizedValue VehicleCompanyAddress { get; set; }

        /// <summary>
        /// Маршрут движения.
        /// </summary>
        [JsonProperty(Order = 6)]
        public RecognizedValue VehicleRoute { get; set; }

        /// <summary>
        /// Грузоотправитель
        /// </summary>
        [JsonProperty(Order = 7)]
        public RecognizedValue VehicleShipper { get; set; }

        /// <summary>
        /// Пройдено расстояние по федеральным трассам
        /// </summary>
        [JsonProperty(Order = 8)]
        public RecognizedValue FederalHighwaysDistance { get; set; }

        /// <summary>
        /// Вид перевозки.
        /// </summary>
        [JsonProperty(Order = 9)]
        public RecognizedValue CarriageType { get; set; }
    }
}