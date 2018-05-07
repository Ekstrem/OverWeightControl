using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OverWeightControl.Common.Serialization;

namespace OverWeightControl.Common.BelModel
{
    public class FullValue
    {
        public int? index { get; set; }
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    [JsonObject]
    public class Date
    {
        [JsonProperty]
        public int fieldId { get; set; }
        [JsonProperty]
        public string description { get; set; }
        [JsonProperty]
        public string recognizedValue { get; set; }
    }

    public class Reason
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class Country
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class Code
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class InformationAbout
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class Value2
    {
        public int index { get; set; }
        public int fieldId { get; set; }
        public string recognizedValue { get; set; }
    }

    public class Value
    {
        public string key { get; set; }
        public IList<Value2> value { get; set; }
    }

    public class VehicleInformation
    {
        public string description { get; set; }
        public IList<Value> value { get; set; }
    }

    public class EmployeeFullName
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class Value3
    {
        public int index { get; set; }
        public int fieldId { get; set; }
        public string recognizedValue { get; set; }
    }

    public class DistanceBetween
    {
        public string key { get; set; }
        public IList<Value3> value { get; set; }
    }

    public class PpvkNumber
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class GoodsCharacteristics
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class ControlDate
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class ViolationType
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class DriverCardNumber
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class TypeTransportation
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class From
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class TypeGoods
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class FullNameOwner
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class DriverFullName
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class ControlsPlace
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class Value5
    {
        public int index { get; set; }
        public int fieldId { get; set; }
        public string recognizedValue { get; set; }
    }

    public class Value4
    {
        public string key { get; set; }
        public IList<Value5> value { get; set; }
    }

    public class AxleLoads
    {
        public string description { get; set; }
        public IList<Value4> value { get; set; }
    }

    public class Value7
    {
        public int fieldId { get; set; }
        public string recognizedValue { get; set; }
    }

    public class Value6
    {
        public string key { get; set; }
        public IList<Value7> value { get; set; }
    }

    public class WeightOfCargo
    {
        public string description { get; set; }
        public IList<Value6> value { get; set; }
    }

    public class WeighingMachineNumber
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class Special
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class CertificateNumber
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class BlankId
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class OperatorFullName
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class Time
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    public class AddressOrganization
    {
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }
    }

    [JsonObject]
    public class BlankValues : ParentBehavior<BlankValues>
    {
        [JsonProperty]
        public Date date { get; set; }
        public Reason reason { get; set; }
        public Country country { get; set; }
        public Code code { get; set; }
        public InformationAbout informationAbout { get; set; }
        public VehicleInformation vehicleInformation { get; set; }
        public EmployeeFullName employeeFullName { get; set; }
        public DistanceBetween distanceBetween { get; set; }
        public PpvkNumber ppvkNumber { get; set; }
        public GoodsCharacteristics goodsCharacteristics { get; set; }
        public ControlDate controlDate { get; set; }
        public ViolationType violationType { get; set; }
        public DriverCardNumber driverCardNumber { get; set; }
        public TypeTransportation typeTransportation { get; set; }
        public From from { get; set; }
        public TypeGoods typeGoods { get; set; }
        public FullNameOwner fullNameOwner { get; set; }
        public DriverFullName driverFullName { get; set; }
        public ControlsPlace controlsPlace { get; set; }
        public AxleLoads axleLoads { get; set; }
        public WeightOfCargo weightOfCargo { get; set; }
        public WeighingMachineNumber weighingMachineNumber { get; set; }
        public Special special { get; set; }
        public CertificateNumber certificateNumber { get; set; }
        public BlankId blankId { get; set; }
        public OperatorFullName operatorFullName { get; set; }
        public Time time { get; set; }
        public AddressOrganization addressOrganization { get; set; }

        public static void load(string json)
        {
            var linq = JObject.Parse(json);
            var results = linq.First.First.Children();
            object v1 = results["date"]["recognizedValue"];
        }
    }
}
