using Newtonsoft.Json;

namespace OverWeightControl.Common.RawData
{
    public class RawVehicleDetail
    {
        /// <summary>
        /// Тип ТС.
        /// </summary>
        [JsonProperty(Order = 1)]
        public RecognizedValue VehicleType { get; set; }

        /// <summary>
        /// Марка ТС.
        /// </summary>
        [JsonProperty(Order = 2)]
        public RecognizedValue VehicleBrand { get; set; }

        /// <summary>
        /// Модель ТС.
        /// </summary>
        [JsonProperty(Order = 3)]
        public RecognizedValue VehicleModel { get; set; }

        /// <summary>
        /// Регистрационый номер ТС.
        /// </summary>
        [JsonProperty(Order = 4)]
        public RecognizedValue StateNumber { get; set; }
    }
}