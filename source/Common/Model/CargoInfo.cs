using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using OverWeightControl.Common.RawData;
using OverWeightControl.Common.Serialization;

namespace OverWeightControl.Common.Model
{
    /// <summary>
    /// Информация о грузе.
    /// </summary>
    [JsonObject]
    public class CargoInfo : ParentBehavior<CargoInfo>
    {
        /// <summary>
        /// Конструктор данных.
        /// </summary>
        public CargoInfo() { }

        public CargoInfo(Guid id) => Id = id;

        /// <summary>
        /// Конструктор данных.
        /// </summary>
        /// <param name="rawCargo">Перводачальная модель.</param>
        public CargoInfo(RawCargoInfo rawCargo)
        {
            CargoCharacter = (rawCargo.CargoCharacter.RecognizedAccuracy ==
                              RecognizedValue.MaxAccuracy)
                ? rawCargo.CargoCharacter.Value
                : string.Empty;
            CargoType = (rawCargo.CargoType.RecognizedAccuracy ==
                         RecognizedValue.MaxAccuracy)
                ? rawCargo.CargoType.Value
                : string.Empty;
            LegalWeight = (rawCargo.LegalWeight.RecognizedAccuracy ==
                           RecognizedValue.MaxAccuracy)
                ? float.Parse(rawCargo.LegalWeight.Value)
                : -1;
            ValetWeight = (rawCargo.ValetWeight.RecognizedAccuracy ==
                           RecognizedValue.MaxAccuracy)
                ? float.Parse(rawCargo.ValetWeight.Value)
                : -1;
            FactWeight = (rawCargo.FactWeight.RecognizedAccuracy ==
                          RecognizedValue.MaxAccuracy)
                ? float.Parse(rawCargo.FactWeight.Value)
                : -1;
            PercentWeightOverflow = (rawCargo.PercentWeightOverflow.RecognizedAccuracy ==
                                     RecognizedValue.MaxAccuracy)
                ? float.Parse(rawCargo.PercentWeightOverflow.Value)
                : -1;
            CargoSpecialAllow = (rawCargo.CargoSpecialAllow.RecognizedAccuracy ==
                                 RecognizedValue.MaxAccuracy)
                ? float.Parse(rawCargo.CargoSpecialAllow.Value)
                : -1;
            RoadSection = (rawCargo.RoadSection.RecognizedAccuracy ==
                           RecognizedValue.MaxAccuracy)
                ? rawCargo.RoadSection.Value
                : string.Empty;
            Tariffs = (rawCargo.Tariffs.RecognizedAccuracy ==
                       RecognizedValue.MaxAccuracy)
                    ? int.Parse(rawCargo.Tariffs.Value)
                    : -1;
            LegLength = (rawCargo.LegLength.RecognizedAccuracy ==
                         RecognizedValue.MaxAccuracy)
                ? float.Parse(rawCargo.LegLength.Value)
                : -1;
            Axises = rawCargo.Axises
                .Select(m => new AxisInfo(m))
                .ToList();
            Pass = (rawCargo.Pass.RecognizedAccuracy ==
                    RecognizedValue.MaxAccuracy)
                ? rawCargo.Pass.Value
                : string.Empty;
            OtherViolation = (rawCargo.OtherViolation.RecognizedAccuracy ==
                              RecognizedValue.MaxAccuracy)
                ? rawCargo.OtherViolation.Value
                : string.Empty;
            DriverExplanation = (rawCargo.DriverExplanation.RecognizedAccuracy ==
                                 RecognizedValue.MaxAccuracy)
                ? rawCargo.DriverExplanation.Value
                : string.Empty;
        }

        /// <summary>
        /// Характеристика груза.
        /// </summary>
        [JsonProperty(Order = 1)]
        [StringLength(20)]
        public string CargoCharacter { get; set; }

        /// <summary>
        /// Вид груза.
        /// </summary>
        [JsonProperty(Order = 2)]
        [StringLength(30)]
        public string CargoType { get; set; }

        /// <summary>
        /// Нормативная масса.
        /// </summary>
        [JsonProperty(Order = 3)]
        public float LegalWeight { get; set; }

        /// <summary>
        /// Допустимая масса.
        /// </summary>
        [JsonProperty(Order = 4)]
        public float ValetWeight { get; set; }

        /// <summary>
        /// Фактическая масса.
        /// </summary>
        [JsonProperty(Order = 5)]
        public float FactWeight { get; set; }

        /// <summary>
        /// Процент перевеса.
        /// </summary>
        [JsonProperty(Order = 7)]
        public float PercentWeightOverflow { get; set; }

        /// <summary>
        /// Специальное разрешение.
        /// </summary>
        [JsonProperty(Order = 6)]
        public float CargoSpecialAllow { get; set; }

        /// <summary>
        /// Участок дороги.
        /// </summary>
        [JsonProperty(Order = 8)]
        [StringLength(50)]
        public string RoadSection { get; set; }

        /// <summary>
        /// Тарифы. Указаны за 100км.
        /// </summary>
        [JsonProperty(Order = 9)]
        public int Tariffs { get; set; }

        /// <summary>
        /// Длина участка.
        /// </summary>
        [JsonProperty(Order = 10)]
        public float LegLength { get; set; }

        /// <summary>
        /// Информация по осям.
        /// </summary>
        [JsonProperty(Order = 11)]
        public ICollection<AxisInfo> Axises { get; set; }

        /// <summary>
        /// Сведения о ГТС в реестре действующих пропусков,
        /// предоставляющих право она въезд и передвижение
        /// в зонах ограничения движения по г. Москва.
        /// </summary>
        [JsonProperty(Order = 12)]
        [StringLength(15)]
        public string Pass { get; set; }

        /// <summary>
        /// Другие нарушения.
        /// </summary>
        [JsonProperty(Order = 13)]
        [StringLength(50)]
        public string OtherViolation { get; set; }

        /// <summary>
        /// Объяснение водителя.
        /// </summary>
        [JsonProperty(Order = 14)]
        [StringLength(250)]
        public string DriverExplanation { get; set; }

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
            return obj is CargoInfo other
                   && string.Equals(CargoCharacter, other?.CargoCharacter)
                   && string.Equals(CargoType, other?.CargoType)
                   && LegalWeight.Equals(other?.LegalWeight)
                   && ValetWeight.Equals(other?.ValetWeight)
                   && FactWeight.Equals(other?.FactWeight)
                   && PercentWeightOverflow.Equals(other?.PercentWeightOverflow)
                   && CargoSpecialAllow.Equals(other?.CargoSpecialAllow)
                   && string.Equals(RoadSection, other?.RoadSection)
                   && Tariffs == other?.Tariffs
                   && LegLength.Equals(other?.LegLength)
                   && Equals(Axises, other?.Axises)
                   && string.Equals(Pass, other?.Pass)
                   && string.Equals(OtherViolation, other?.OtherViolation)
                   && string.Equals(DriverExplanation, other?.DriverExplanation);
        }

        /// <summary>Служит хэш-функцией по умолчанию.</summary>
        /// <returns>Хэш-код для текущего объекта.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (CargoCharacter != null ? CargoCharacter.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CargoType != null ? CargoType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ LegalWeight.GetHashCode();
                hashCode = (hashCode * 397) ^ ValetWeight.GetHashCode();
                hashCode = (hashCode * 397) ^ FactWeight.GetHashCode();
                hashCode = (hashCode * 397) ^ PercentWeightOverflow.GetHashCode();
                hashCode = (hashCode * 397) ^ CargoSpecialAllow.GetHashCode();
                hashCode = (hashCode * 397) ^ (RoadSection != null ? RoadSection.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Tariffs;
                hashCode = (hashCode * 397) ^ LegLength.GetHashCode();
                hashCode = (hashCode * 397) ^ (Axises != null ? Axises.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Pass != null ? Pass.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OtherViolation != null ? OtherViolation.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DriverExplanation != null ? DriverExplanation.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}