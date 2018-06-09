using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using OverWeightControl.Common.Model;
using OverWeightControl.Common.RawData;

namespace OverWeightControl.Common.BelModel
{
    public class BlankList
    {
        [JsonProperty("blankValues")]
        public BlankValues blankValues { get; set; }

        /// <summary>
        /// Маппит эту модель в стандартную.
        /// </summary>
        /// <returns>Стандартная модель домена.</returns>
        public Act ToModelFormat(Action<Exception> exceptionAction = null)
        {
            try
            {
                var act = new Act();
                act.ActNumber = blankValues.blankId.AsInt();
                act.PpvkNumber = blankValues.ppvkNumber.AsInt();
                act.WeightPoint = blankValues.controlsPlace.recognizedValue;
                if (DateTime.TryParse(blankValues.date.recognizedValue, out var date)
                    && TimeSpan.TryParse(blankValues.time.recognizedValue, out var time))
                    act.ActDateTime = date + time;

                try
                {
                    act.Weighter = new WeighterInfo(act.Id);
                    act.Weighter.CertificateNumber = blankValues.certificateNumber.recognizedValue;
                    act.Weighter.VerificationDate = blankValues.controlDate.recognizedValue;
                    act.Weighter.ViolationNature = blankValues.violationType.recognizedValue;
                    act.Weighter.ViolationKoap = String.Empty;
                    act.Weighter.WeigherNumber = blankValues.weighingMachineNumber.recognizedValue;
                }
                catch (Exception e)
                {
                    exceptionAction?.Invoke(e);
                }

                try
                {
                    act.Driver = new DriverInfo(act.Id);
                    act.Driver.DriversLicenseNumber = blankValues.driverCardNumber.recognizedValue;
                    act.Driver.FnMnSname = blankValues.driverFullName.recognizedValue;
                    act.Driver.GetingMark = String.Empty;
                    act.Driver.GibddName = blankValues.employeeFullName.recognizedValue;
                    act.Driver.OperatorName = blankValues.operatorFullName.recognizedValue;
                }
                catch (Exception e)
                {
                    exceptionAction?.Invoke(e);
                }

                try
                {
                    act.Vehicle = new VehicleInfo(act.Id);
                    act.Vehicle.CarriageType = blankValues.typeGoods.recognizedValue;
                    act.Vehicle.FederalHighwaysDistance = String.Empty;
                    act.Vehicle.VehicleCompanyAddress = blankValues.addressOrganization.recognizedValue;
                    act.Vehicle.VehicleCountry = blankValues.country.recognizedValue;
                    act.Vehicle.VehicleOwner = blankValues.fullNameOwner.recognizedValue;
                    act.Vehicle.VehicleRoute = String.Empty;
                    act.Vehicle.VehicleShipper = blankValues?.from?.recognizedValue;
                    act.Vehicle.VehicleSubjectCode = 
                        int.TryParse(blankValues.code.recognizedValue, out int code)
                            ? code : default(int);
                    
                    try
                    {
                        act.Vehicle.Detail = new List<VehicleDetail>();
                        var bvi = blankValues.vehicleInformation.value
                            .SelectMany(m => m.value)
                            .ToList();
                        var vd1 = new VehicleDetail
                        {
                            Id = Guid.NewGuid(),
                            StateNumber = bvi.SingleOrDefault(f => f.fieldId == 2070906)?.recognizedValue,
                            VehicleBrand = bvi.SingleOrDefault(f => f.fieldId == 2070902)?.recognizedValue,
                            VehicleModel = bvi.SingleOrDefault(f => f.fieldId == 2070904)?.recognizedValue,
                            VehicleType = bvi.SingleOrDefault(f=>f.fieldId == 2070900)?.recognizedValue
                        };
                        act.Vehicle.Detail.Add(vd1);
                        var vd2 = new VehicleDetail
                        {
                            Id = Guid.NewGuid(),
                            StateNumber = bvi.SingleOrDefault(f => f.fieldId == 2070907)?.recognizedValue,
                            VehicleBrand = bvi.SingleOrDefault(f => f.fieldId == 2070903)?.recognizedValue,
                            VehicleModel = bvi.SingleOrDefault(f => f.fieldId == 2070905)?.recognizedValue,
                            VehicleType = bvi.SingleOrDefault(f => f.fieldId == 2070901)?.recognizedValue
                        };
                        act.Vehicle.Detail.Add(vd2);
                    }
                    catch (Exception e)
                    {
                        exceptionAction?.Invoke(e);
                    }
                }
                catch (Exception e)
                {
                    exceptionAction?.Invoke(e);
                }

                try
                {
                    act.Cargo = new CargoInfo(act.Id);
                    act.Cargo.CargoCharacter = blankValues.goodsCharacteristics.recognizedValue;
                    act.Cargo.CargoType = blankValues.typeGoods.recognizedValue;
                    act.Cargo.DriverExplanation = blankValues.reason.recognizedValue;
                    act.Cargo.Pass = String.Empty;
                    act.Cargo.OtherViolation = String.Empty;
                    act.Cargo.LegLength = default(float);
                    act.Cargo.Tariffs = default(int);
                    act.Cargo.RoadSection = String.Empty;
                    act.Cargo.FactWeight =
                        float.TryParse(blankValues.weightOfCargo.value[0].value[0].recognizedValue,
                            out float factweight)
                            ? factweight
                            : default(float);
                    act.Cargo.LegalWeight =
                        float.TryParse(blankValues.weightOfCargo.value[3].value[0].recognizedValue,
                            out float legalWeight)
                            ? legalWeight
                            : default(float);
                    act.Cargo.PercentWeightOverflow =
                        float.TryParse(blankValues.weightOfCargo.value[1].value[0].recognizedValue,
                            out float pOwerWeight)
                            ? pOwerWeight
                            : default(float);
                    act.Cargo.ValetWeight =
                        float.TryParse(blankValues.weightOfCargo.value[2].value[0].recognizedValue,
                            out float valetWeight)
                            ? valetWeight
                            : default(float);
                    act.Cargo.CargoSpecialAllow =
                        float.TryParse(blankValues.weightOfCargo.value[2].value[0].recognizedValue,
                            out float specialAllowWeight)
                            ? specialAllowWeight
                            : default(float);

                    var al = blankValues.axleLoads.value
                        .SelectMany(m => m.value);
                    var d = new Dictionary<int, string>();
                    foreach (var value in al)
                    {
                        if (!d.ContainsKey(value.fieldId))
                            d.Add(value.fieldId, value.recognizedValue.Replace('.', ','));
                    }
                    
                    var axisLoadsArr = Enumerable.Range(0, 11).Select(m => new AxisInfo()).ToArray();
                    for (int i = 0; i < axisLoadsArr.Length; i++)
                    {
                        try
                        {
                            axisLoadsArr[i].AxisNum = (i+1).ToString();
                            axisLoadsArr[i].Distance2NextAxis = int.TryParse(d[2070977 + i], out var d2na) ? d2na : 0;
                            axisLoadsArr[i].LegalAxisWeight = float.TryParse(d[2070977 + i], out var law) ? law : 0;
                            axisLoadsArr[i].MeasuredAsisWeight = float.TryParse(d[2070944 + i], out var maw) ? maw : 0;
                            axisLoadsArr[i].PercentRecordedExcess = float.TryParse(d[2070999+i], out var pre) ? pre : 0;
                            axisLoadsArr[i].UsedAxisAllow = float.TryParse(d[2070955 + i], out var uaa) ? uaa : 0;
                            axisLoadsArr[i].AxisStinginess = int.TryParse(d[2070933 + i], out var axs) ? axs : 0;
                            axisLoadsArr[i].Overweight = d[2071010 + i];
                            //axisLoadsArr[i].SpecialAllow
                            //axisLoadsArr[i].SuspentionType

                        }
                        catch (Exception e)
                        {
                            exceptionAction?.Invoke(e);
                        }
                    }

                    act.Cargo.Axises = axisLoadsArr.Where(f => f.AxisStinginess != 0).ToList();
                }
                catch (Exception e)
                {
                    exceptionAction?.Invoke(e);
                }
                
                return act;
            }
            catch (Exception e)
            {
                exceptionAction?.Invoke(e);
                return null;
            }
        }

        public static BlankList GetList(string json, Action<Exception> exceptionAction = null)
        {
            try
            {
                return JsonConvert.DeserializeObject<BlankList>(json);
            }
            catch (Exception e)
            {
                exceptionAction?.Invoke(e);
                return null;
            }
        }
    }
}