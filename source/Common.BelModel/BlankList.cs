using System;
using System.Globalization;
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
        public Act ToModelFormat()
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
                }

                try
                {
                    act.Vehicle = new VehicleInfo(act.Id);
                }
                catch (Exception e)
                {
                }

                try
                {
                    act.Cargo = new CargoInfo(act.Id);
                }
                catch (Exception e)
                {
                }



                return act;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static BlankList GetList(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<BlankList>(json);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}