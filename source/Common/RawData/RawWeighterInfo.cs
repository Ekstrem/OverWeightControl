using Newtonsoft.Json;

namespace OverWeightControl.Common.RawData
{
    /// <summary>
    /// Весовое оборудование.
    /// </summary>
    [JsonObject]
    public class RawWeighterInfo
    {
        /// <summary>
        /// Номер весов.
        /// </summary>
        [JsonProperty(Order = 1)]
        public RecognizedValue WeigherNumber { get; set; }

        /// <summary>
        /// Дата поверки.
        /// DD.MM.YYYY
        /// </summary>
        [JsonProperty(Order = 2)]
        public RecognizedValue VerificationDate { get; set; }

        /// <summary>
        /// Номер свидетельства (клейма).
        /// </summary>
        [JsonProperty(Order = 3)]
        public RecognizedValue CertificateNumber { get; set; }

        /// <summary>
        /// Характер нарушения.
        /// </summary>
        [JsonProperty(Order = 4)]
        public RecognizedValue ViolationNature { get; set; }

        /// <summary>
        /// КоАП РФ.
        /// Ст. 12.21.1 ч.1 - 11
        /// </summary>
        [JsonProperty(Order = 5)]
        public RecognizedValue ViolationKoap { get; set; }
    }
}