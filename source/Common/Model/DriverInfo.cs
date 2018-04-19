using Newtonsoft.Json;
using OverWeightControl.Common.RawData;

namespace OverWeightControl.Common.Model
{
    /// <summary>
    /// Водитель ТС.
    /// </summary>
    [JsonObject]
    public class DriverInfo
    {
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public DriverInfo() { }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="rawDriver"></param>
        public DriverInfo(RawDriverInfo rawDriver)
        {
            FnMnSname = (rawDriver.FnMnSname.RecognizedAccuracy ==
                         RecognizedValue.MaxAccuracy)
                ? rawDriver.FnMnSname.Value
                : string.Empty;
            DriversLicenseNumber = (rawDriver.DriversLicenseNumber.RecognizedAccuracy ==
                                    RecognizedValue.MaxAccuracy)
                ? rawDriver.DriversLicenseNumber.Value
                : string.Empty;
            OperatorName = (rawDriver.OperatorName.RecognizedAccuracy ==
                            RecognizedValue.MaxAccuracy)
                ? rawDriver.OperatorName.Value
                : string.Empty;
            GibddName = (rawDriver.GibddName.RecognizedAccuracy ==
                         RecognizedValue.MaxAccuracy)
                ? rawDriver.GibddName.Value
                : string.Empty;
            GetingMark = (rawDriver.GetingMark.RecognizedAccuracy ==
                          RecognizedValue.MaxAccuracy)
                ? rawDriver.GetingMark.Value
                : string.Empty;
        }

        /// <summary>
        /// Ф.И.О.
        /// </summary>
        [JsonProperty(Order = 1)]
        public string FnMnSname { get; set; }

        /// <summary>
        /// № водительского удостоверения.
        /// </summary>
        [JsonProperty(Order = 2)]
        public string DriversLicenseNumber { get; set; }

        /// <summary>
        /// Ф.И.О. оператора ППВК.
        /// </summary>
        [JsonProperty(Order = 3)]
        public string OperatorName { get; set; }

        /// <summary>
        /// Ф.И.О сотрудника ГИБДД.
        /// </summary>
        [JsonProperty(Order = 4)]
        public string GibddName { get; set; }

        /// <summary>
        /// Отметка о получении копии акта водителем.
        /// </summary>
        [JsonProperty(Order = 5)]
        public string GetingMark { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DriverInfo other
                   && string.Equals(FnMnSname, other.FnMnSname)
                   && string.Equals(DriversLicenseNumber, other.DriversLicenseNumber)
                   && string.Equals(OperatorName, other.OperatorName)
                   && string.Equals(GibddName, other.GibddName)
                   && string.Equals(GetingMark, other.GetingMark);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (FnMnSname != null ? FnMnSname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DriversLicenseNumber != null ? DriversLicenseNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OperatorName != null ? OperatorName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (GibddName != null ? GibddName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (GetingMark != null ? GetingMark.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}