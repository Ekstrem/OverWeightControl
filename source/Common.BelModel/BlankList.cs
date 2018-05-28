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
                {
                    act.ActDateTime = (date + time)
                        .ToString(CultureInfo.CurrentCulture);
                }

                try
                {
                    act.Weighter = new WeighterInfo(act.Id);
                    act.Weighter.CertificateNumber = blankValues.certificateNumber.recognizedValue;
                    act.Weighter.VerificationDate = blankValues.controlDate.recognizedValue;
                    act.Weighter.ViolationNature = blankValues.violationType.recognizedValue;
                    act.Weighter.ViolationKoap = String.Empty;
                    act.Weighter.WeigherNumber = String.Empty;
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
                    //act.Vehicle.Detail
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

                    act.Cargo.Axises = new List<AxisInfo>(
                        blankValues.distanceBetween.value
                            .Select(m => new AxisInfo
                            {
                                AxisNum = m.index.GetValueOrDefault(0).ToString(),
                                Distance2NextAxis =
                                    int.TryParse(m.recognizedValue, out int dist)
                                        ? dist
                                        : default(int)
                            }));
                    var axelLoads = blankValues.axleLoads.value[0].value
                        .Select(m => new KeyValuePair<int, string>(
                            m.index.GetValueOrDefault(0), m.recognizedValue));
                    foreach (var axelLoad in axelLoads)
                    {
                        var axel = act.Cargo.Axises.First(f => f.AxisNum == axelLoad.Key.ToString());
                        if (axel != null)
                        {
                            axel.UsedAxisAllow =
                                float.TryParse(axelLoad.Value, out float axelUsedLoad)
                                    ? axelUsedLoad
                                    : default(float);
                        }
                    }
                    
                    var ai = new AxisInfo();
                    
                    //act.Cargo.Axises
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