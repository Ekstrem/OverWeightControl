using System;
using System.Globalization;
using Newtonsoft.Json;
using OverWeightControl.Common.RawData;
using OverWeightControl.Common.Serialization;

namespace OverWeightControl.Common.Model
{
    /// <summary>
    /// Основной класс - акт о превышении нагрузки.
    /// </summary>
    [JsonObject]
    public class Act : ParentBehavior<Act>
    {
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public Act() : base() { }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="act">Акт перевеса.</param>
        public Act(RawAct act) : base()
        {
            Id = act.Id;
            ActNumber = (act.ActNumber.RecognizedAccuracy ==
                         RecognizedValue.MaxAccuracy)
                ? int.Parse(act.ActNumber.Value)
                : -1;

            DateTime.TryParse(act.ActDate.Value, out var date);
            TimeSpan.TryParse(act.ActTime.Value, out var time);
            if (act.ActDate.RecognizedAccuracy == RecognizedValue.MaxAccuracy
                && date != null && time != null)
            {
                ActDateTime = (date + time)
                    .ToString(CultureInfo.CurrentCulture);
            }

            ActDateTime = (act.ActDate.RecognizedAccuracy ==
                       RecognizedValue.MaxAccuracy)
                ? act.ActDate.Value
                : string.Empty;
            PpvkNumber = (act.ActNumber.RecognizedAccuracy ==
                          RecognizedValue.MaxAccuracy)
                ? int.Parse(act.ActNumber.Value)
                : -1;
            WeightPoint = (act.WeightPoint.RecognizedAccuracy ==
                           RecognizedValue.MaxAccuracy)
                ? act.WeightPoint.Value
                : string.Empty;
            Weighter = new WeighterInfo(act.Weighter);
            Vehicle = new VehicleInfo(act.Vehicle);
            Driver = new DriverInfo(act.Driver);
            Cargo = new CargoInfo(act.Cargo);
        }

        /// <summary>
        /// Номер акта.
        /// </summary>
        [JsonProperty(Order = 1)]
        public int ActNumber { get; set; }

        /// <summary>
        /// Дата Акта.
        /// DD.MM.YYYY
        /// </summary>
        [JsonProperty(Order = 2)]
        public string ActDateTime { get; set; }
        
        /// <summary>
        /// Номер ППВК.
        /// value>0.
        /// </summary>
        [JsonProperty(Order = 4)]
        public int PpvkNumber { get; set; }

        /// <summary>
        /// Место проведения контроля (взвешивания).
        /// </summary>
        [JsonProperty(Order = 5)]
        public string WeightPoint { get; set; }

        /// <summary>
        /// Весовое оборудование.
        /// </summary>
        [JsonProperty(Order = 6)]
        public WeighterInfo Weighter { get; set; }

        /// <summary>
        /// Сведения о ТС.
        /// </summary>
        [JsonProperty(Order = 7)]
        public VehicleInfo Vehicle { get; set; }

        /// <summary>
        /// Водитель ТС.
        /// </summary>
        [JsonProperty(Order = 8)]
        public DriverInfo Driver { get; set; }

        /// <summary>
        /// Информация о грузе.
        /// </summary>
        [JsonProperty(Order = 9)]
        public CargoInfo Cargo { get; set; }

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
            return obj is Act other
                   && ActNumber == other?.ActNumber
                   && string.Equals(ActDateTime, other?.ActDateTime)
                   && PpvkNumber == other?.PpvkNumber
                   && string.Equals(WeightPoint, other?.WeightPoint)
                   && Equals(Weighter, other?.Weighter)
                   && Equals(Vehicle, other?.Vehicle)
                   && Equals(Driver, other?.Driver)
                   && Equals(Cargo, other?.Cargo);
        }

        /// <summary>Служит хэш-функцией по умолчанию.</summary>
        /// <returns>Хэш-код для текущего объекта.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ActNumber;
                hashCode = (hashCode * 397) ^ (ActDateTime != null ? ActDateTime.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PpvkNumber;
                hashCode = (hashCode * 397) ^ (WeightPoint != null ? WeightPoint.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Weighter != null ? Weighter.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Vehicle != null ? Vehicle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Driver != null ? Driver.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Cargo != null ? Cargo.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
