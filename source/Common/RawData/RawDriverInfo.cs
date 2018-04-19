using Newtonsoft.Json;

namespace OverWeightControl.Common.RawData
{
    /// <summary>
    /// Водитель ТС.
    /// </summary>
    [JsonObject]
    public class RawDriverInfo
    {
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        [JsonProperty(Order = 1)]
        public RecognizedValue FnMnSname { get; set; }

        /// <summary>
        /// № водительского удостоверения.
        /// </summary>
        [JsonProperty(Order = 2)]
        public RecognizedValue DriversLicenseNumber { get; set; }

        /// <summary>
        /// Ф.И.О. оператора ППВК.
        /// </summary>
        [JsonProperty(Order = 3)]
        public RecognizedValue OperatorName { get; set; }

        /// <summary>
        /// Ф.И.О сотрудника ГИБДД.
        /// </summary>
        [JsonProperty(Order = 4)]
        public RecognizedValue GibddName { get; set; }

        /// <summary>
        /// Отметка о получении копии акта водителем.
        /// </summary>
        [JsonProperty(Order = 5)]
        public RecognizedValue GetingMark { get; set; }
    }
}