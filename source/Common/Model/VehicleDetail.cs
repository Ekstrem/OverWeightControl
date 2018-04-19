using Newtonsoft.Json;
using OverWeightControl.Common.RawData;

namespace OverWeightControl.Common.Model
{
    public class VehicleDetail
    {
        /// <summary>
        /// Информация о транспортном средстве.
        /// </summary>
        public VehicleDetail() { }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="rawVehicleDetail"></param>
        public VehicleDetail(RawVehicleDetail rawVehicleDetail)
        {
            VehicleType = (rawVehicleDetail.VehicleType.RecognizedAccuracy ==
                           RecognizedValue.MaxAccuracy)
                ? rawVehicleDetail.VehicleType.Value
                : string.Empty;
            VehicleBrand = (rawVehicleDetail.VehicleBrand.RecognizedAccuracy ==
                            RecognizedValue.MaxAccuracy)
                ? rawVehicleDetail.VehicleBrand.Value
                : string.Empty;
            VehicleModel = (rawVehicleDetail.VehicleModel.RecognizedAccuracy ==
                            RecognizedValue.MaxAccuracy)
                ? rawVehicleDetail.VehicleModel.Value
                : string.Empty;
            StateNumber = (rawVehicleDetail.StateNumber.RecognizedAccuracy ==
                           RecognizedValue.MaxAccuracy)
                ? rawVehicleDetail.StateNumber.Value
                : string.Empty;
        }

        /// <summary>
        /// Тип ТС.
        /// </summary>
        [JsonProperty(Order = 1)]
        public string VehicleType { get; set; }

        /// <summary>
        /// Марка ТС.
        /// </summary>
        [JsonProperty(Order = 2)]
        public string VehicleBrand { get; set; }

        /// <summary>
        /// Модель ТС.
        /// </summary>
        [JsonProperty(Order = 3)]
        public string VehicleModel { get; set; }

        /// <summary>
        /// Регистрационый номер ТС.
        /// </summary>
        [JsonProperty(Order = 4)]
        public string StateNumber { get; set; }

        public override bool Equals(object obj)
        {
            return obj is VehicleDetail detail
                   && VehicleType.Equals(detail?.VehicleType)
                   && VehicleBrand.Equals(detail?.VehicleBrand)
                   && VehicleModel.Equals(detail?.VehicleModel)
                   && StateNumber.Equals(detail?.StateNumber);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (VehicleType != null ? VehicleType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VehicleBrand != null ? VehicleBrand.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VehicleModel != null ? VehicleModel.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StateNumber != null ? StateNumber.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}