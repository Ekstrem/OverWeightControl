using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using OverWeightControl.Common.RawData;
using OverWeightControl.Common.Serialization;

namespace OverWeightControl.Common.Model
{
    /// <summary>
    /// Сведения о ТС.
    /// </summary>
    [JsonObject]
    public class VehicleInfo : ParentBehavior<VehicleDetail>
    {
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public VehicleInfo() { }
        public VehicleInfo(Guid id) => Id = id;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="rawVehicle"></param>
        public VehicleInfo(RawVehicleInfo rawVehicle)
        {
            Detail = rawVehicle.Detail
                .Select(m => new VehicleDetail(m))
                .ToList();
            VehicleOwner = (rawVehicle.VehicleOwner.RecognizedAccuracy ==
                            RecognizedValue.MaxAccuracy)
                ? rawVehicle.VehicleOwner.Value
                : string.Empty;
            VehicleCountry = (rawVehicle.VehicleCountry.RecognizedAccuracy ==
                              RecognizedValue.MaxAccuracy)
                ? rawVehicle.VehicleCountry.Value
                : string.Empty;
            VehicleSubjectCode = (rawVehicle.VehicleSubjectCode.RecognizedAccuracy ==
                                  RecognizedValue.MaxAccuracy)
                ? int.Parse(rawVehicle.VehicleSubjectCode.Value)
                : -1;
            VehicleCompanyAddress = (rawVehicle.VehicleCompanyAddress.RecognizedAccuracy ==
                                     RecognizedValue.MaxAccuracy)
                ? rawVehicle.VehicleCompanyAddress.Value
                : string.Empty;
            VehicleRoute = (rawVehicle.VehicleRoute.RecognizedAccuracy ==
                            RecognizedValue.MaxAccuracy)
                ? rawVehicle.VehicleRoute.Value
                : string.Empty;
            VehicleShipper = (rawVehicle.VehicleShipper.RecognizedAccuracy ==
                              RecognizedValue.MaxAccuracy)
                ? rawVehicle.VehicleShipper.Value
                : string.Empty;
            FederalHighwaysDistance = (rawVehicle.FederalHighwaysDistance.RecognizedAccuracy ==
                                       RecognizedValue.MaxAccuracy)
                ? rawVehicle.FederalHighwaysDistance.Value
                : string.Empty;
            CarriageType = (rawVehicle.CarriageType.RecognizedAccuracy ==
                            RecognizedValue.MaxAccuracy)
                ? rawVehicle.CarriageType.Value
                : string.Empty;
        }

        /// <summary>
        /// Общее о ТС.
        /// </summary>
        [JsonProperty(Order = 1)]
        public ICollection<VehicleDetail> Detail { get; set; }

        /// <summary>
        /// Наименование владельца (собственника) ТС,
        /// осуществляющего перевозку тяжеловесного груза.
        /// </summary>
        [DisplayName("Наименование владельца (собственника) ТС")]
        [JsonProperty(Order = 2)]
        [StringLength(100)]
        public string VehicleOwner { get; set; }

        /// <summary>
        /// Страна регистрации.
        /// </summary>
        [DisplayName("Страна регистрации")]
        [JsonProperty(Order = 3)]
        [StringLength(25)]
        public string VehicleCountry { get; set; }

        /// <summary>
        /// Код субъекта.
        /// </summary>
        [DisplayName("Код субъекта")]
        [JsonProperty(Order = 4)]
        public int VehicleSubjectCode { get; set; }

        /// <summary>
        /// Адрес организации.
        /// </summary>
        [DisplayName("Адрес организации")]
        [JsonProperty(Order = 5)]
        [StringLength(150)]
        public string VehicleCompanyAddress { get; set; }

        /// <summary>
        /// Маршрут движения.
        /// </summary>
        [DisplayName("Маршрут движения")]
        [JsonProperty(Order = 6)]
        [StringLength(25)]
        public string VehicleRoute { get; set; }

        /// <summary>
        /// Грузоотправитель
        /// </summary>
        [DisplayName("Грузоотправитель")]
        [JsonProperty(Order = 7)]
        [StringLength(25)]
        public string VehicleShipper { get; set; }

        /// <summary>
        /// Пройдено расстояние по федеральным трассам
        /// </summary>
        [DisplayName("Пройдено расстояние по федеральным трассам")]
        [JsonProperty(Order = 8)]
        [StringLength(25)]
        public string FederalHighwaysDistance { get; set; }

        /// <summary>
        /// Вид перевозки.
        /// </summary>
        [DisplayName("Вид перевозки")]
        [JsonProperty(Order = 9)]
        [StringLength(25)]
        public string CarriageType { get; set; }

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
            return obj is VehicleInfo other
                   && Equals(Detail, other?.Detail)
                   && string.Equals(VehicleOwner, other?.VehicleOwner)
                   && string.Equals(VehicleCountry, other?.VehicleCountry)
                   && VehicleSubjectCode == other?.VehicleSubjectCode
                   && string.Equals(VehicleCompanyAddress, other?.VehicleCompanyAddress)
                   && string.Equals(VehicleRoute, other?.VehicleRoute)
                   && string.Equals(VehicleShipper, other?.VehicleShipper)
                   && string.Equals(FederalHighwaysDistance, other?.FederalHighwaysDistance)
                   && string.Equals(CarriageType, other?.CarriageType);
        }

        /// <summary>Служит хэш-функцией по умолчанию.</summary>
        /// <returns>Хэш-код для текущего объекта.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Detail != null ? Detail.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VehicleOwner != null ? VehicleOwner.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VehicleCountry != null ? VehicleCountry.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ VehicleSubjectCode;
                hashCode = (hashCode * 397) ^ (VehicleCompanyAddress != null ? VehicleCompanyAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VehicleRoute != null ? VehicleRoute.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VehicleShipper != null ? VehicleShipper.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FederalHighwaysDistance != null ? FederalHighwaysDistance.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CarriageType != null ? CarriageType.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString() =>
            $"{VehicleCountry} {VehicleSubjectCode} {this.CarriageType}";
    }
}