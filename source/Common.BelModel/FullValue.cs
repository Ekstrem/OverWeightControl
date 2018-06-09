using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OverWeightControl.Common.Model;
using OverWeightControl.Common.Serialization;

namespace OverWeightControl.Common.BelModel
{
    public class FullValue
    {
        [JsonProperty("index")]
        public int? index { get; set; }
        [JsonProperty("fieldId")]
        public int fieldId { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("recognizedValue")]
        public string recognizedValue { get; set; }
        [JsonProperty("value")]
        public IList<FullValue> value { get; set; }

        public int AsInt()
        {
            return int.TryParse(recognizedValue, out int res) ? res : default(int);
        }

        public float AsFloat()
        {
            return float.TryParse(recognizedValue, out float res) ? res : default(float);
        }

        /// <summary>Возвращает строку, представляющую текущий объект.</summary>
        /// <returns>Строка, представляющая текущий объект.</returns>
        public override string ToString() => recognizedValue;

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
            if (!(obj is FullValue))
                return false;
            return fieldId.Equals(((FullValue) obj).fieldId)
                   && recognizedValue.Equals(((FullValue) obj).recognizedValue);
        }


        public static Act Load(string json)
        {
            var linq = JObject.Parse(json)["blankValues"];
            var act = new Act();
            var dateString = (string) linq["date"]["recognizedValue"]
                       + " " + (string) linq["time"]["recognizedValue"];
            if (DateTime.TryParse(dateString, out var date))
                act.ActDateTime = date;
            if (int.TryParse((string) linq["ppvkNumber"]["recognizedValue"], out int ppvkNum))
                act.PpvkNumber = ppvkNum;

            int actId;
            act.ActNumber =
                int.TryParse((string)linq["blankId"]["recognizedValue"], out actId)
                    ? actId
                    : 0;
            act.WeightPoint = 
                (string) linq["controlsPlace"]["recognizedValue"];

            act.Weighter = new WeighterInfo(act.Id);
            act.Weighter.CertificateNumber = 
                (string) linq["certificateNumber"]["recognizedValue"];
            act.Weighter.WeigherNumber=
                (string)linq["weighingMachineNumber"]["recognizedValue"];
            act.Weighter.VerificationDate =
                (string)linq["controlDate"]["recognizedValue"];
            // act.Weighter.ViolationKoap = (string)linq[""]["recognizedValue"]; ;
            act.Weighter.ViolationNature =
                (string)linq["violationType"]["recognizedValue"]; ;

            act.Cargo = new CargoInfo(act.Id);
            act.Cargo.CargoCharacter =
                (string)linq["goodsCharacteristics"]["recognizedValue"];
            float special;
            act.Cargo.CargoSpecialAllow =
                float.TryParse((string)linq["special"]["recognizedValue"], out special)
                    ? special
                    : 0;
            act.Cargo.CargoType =
                (string)linq["typeGoods"]["recognizedValue"];
            act.Cargo.DriverExplanation = 
                (string)linq["reason"]["recognizedValue"];
            float factWeight;
            act.Cargo.FactWeight =
                float.TryParse((string)linq["weightOfCargo"]["recognizedValue"], out factWeight)
                    ? factWeight
                    : 0;
            // act.Cargo.LegLength = (string)linq[""]["recognizedValue"];
            // act.Cargo.LegalWeight = (string)linq[""]["recognizedValue"];
            // act.Cargo.OtherViolation = (string)linq[""]["recognizedValue"];
            act.Cargo.Pass =
                (string)linq["informationAbout"]["recognizedValue"];
            // act.Cargo.PercentWeightOverflow = (string)linq[""]["recognizedValue"];

            act.Driver = new DriverInfo(act.Id);
            act.Driver.DriversLicenseNumber = 
                (string)linq["driverCardNumber"]["recognizedValue"];
            act.Driver.FnMnSname = 
                (string)linq["driverFullName"]["recognizedValue"];
            // act.Driver.GetingMark = (string)linq[""]["recognizedValue"];
            act.Driver.GibddName =
                (string)linq["employeeFullName"]["recognizedValue"];
            act.Driver.OperatorName =
                (string)linq["operatorFullName"]["recognizedValue"];

            act.Vehicle = new VehicleInfo(act.Id);

            return act;
        }

        public override int GetHashCode()
        {
            var hashCode = -1351203734;
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(index);
            hashCode = hashCode * -1521134295 + fieldId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(recognizedValue);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<FullValue>>.Default.GetHashCode(value);
            return hashCode;
        }
    }
}
