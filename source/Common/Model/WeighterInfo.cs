using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OverWeightControl.Common.RawData;
using OverWeightControl.Common.Serialization;

namespace OverWeightControl.Common.Model
{
    /// <summary>
    /// Весовое оборудование.
    /// </summary>
    [JsonObject]
    public class WeighterInfo : ParentBehavior<WeighterInfo>
    {
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public WeighterInfo() { }
        public WeighterInfo(Guid id) => Id = id;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="rawWeighter"></param>
        public WeighterInfo(RawWeighterInfo rawWeighter)
        {
            WeigherNumber = (rawWeighter.WeigherNumber.RecognizedAccuracy ==
                             RecognizedValue.MaxAccuracy)
                ? rawWeighter.WeigherNumber.Value
                : string.Empty;
            VerificationDate = (rawWeighter.VerificationDate.RecognizedAccuracy ==
                                RecognizedValue.MaxAccuracy)
                ? rawWeighter.VerificationDate.Value
                : string.Empty;
            CertificateNumber = (rawWeighter.CertificateNumber.RecognizedAccuracy ==
                                 RecognizedValue.MaxAccuracy)
                ? rawWeighter.CertificateNumber.Value
                : string.Empty;
            ViolationNature = (rawWeighter.ViolationNature.RecognizedAccuracy ==
                              RecognizedValue.MaxAccuracy)
                ? rawWeighter.ViolationNature.Value
                : string.Empty;
            ViolationKoap = (rawWeighter.ViolationKoap.RecognizedAccuracy ==
                             RecognizedValue.MaxAccuracy)
                ? rawWeighter.ViolationKoap.Value
                : string.Empty;
        }

        /// <summary>
        /// Номер весов.
        /// </summary>
        [JsonProperty(Order = 1)]
        [StringLength(20)]
        public string WeigherNumber { get; set; }

        /// <summary>
        /// Дата поверки.
        /// DD.MM.YYYY
        /// </summary>
        [JsonProperty(Order = 2)]
        [StringLength(10)]
        public string VerificationDate { get; set; }

        /// <summary>
        /// Номер свидетельства (клейма).
        /// </summary>
        [JsonProperty(Order = 3)]
        [StringLength(20)]
        public string CertificateNumber { get; set; }

        /// <summary>
        /// Характер нарушения.
        /// </summary>
        [JsonProperty(Order = 4)]
        [StringLength(100)]
        public string ViolationNature { get; set; }

        /// <summary>
        /// КоАП РФ.
        /// Ст. 12.21.1 ч.1 - 11
        /// </summary>
        [JsonProperty(Order = 5)]
        [StringLength(15)]
        public string ViolationKoap { get; set; }

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
            return obj is WeighterInfo w
                   && WeigherNumber.Equals(w?.WeigherNumber)
                   && VerificationDate.Equals(w?.VerificationDate)
                   && CertificateNumber.Equals(w?.CertificateNumber)
                   && ViolationNature.Equals(w?.ViolationNature)
                   && ViolationKoap.Equals(w?.ViolationKoap);
        }

        /// <summary>Служит хэш-функцией по умолчанию.</summary>
        /// <returns>Хэш-код для текущего объекта.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (WeigherNumber != null ? WeigherNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VerificationDate != null ? VerificationDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CertificateNumber != null ? CertificateNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ViolationNature != null ? ViolationNature.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ViolationKoap != null ? ViolationKoap.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}