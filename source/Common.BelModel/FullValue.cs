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
        public int? index { get; set; }
        public int fieldId { get; set; }
        public string description { get; set; }
        public string recognizedValue { get; set; }


        public static Act Load(string json)
        {
            var linq = JObject.Parse(json)["blankValues"];
            var act = new Act();
            act.ActDateTime = (string) linq["date"]["recognizedValue"]
                              + " " + (string) linq["time"]["recognizedValue"];
            if (int.TryParse((string) linq["ppvkNumber"]["recognizedValue"], out int ppvkNum))
                act.PpvkNumber = ppvkNum;

            // act.ActNumber = (int)linq[""]["recognizedValue"];
            act.WeightPoint = (string) linq["controlsPlace"]["recognizedValue"];

            act.Weighter = new WeighterInfo();
            act.Weighter.CertificateNumber = (string) linq["certificateNumber"]["recognizedValue"];
            act.Weighter.WeigherNumber= (string)linq["weighingMachineNumber"]["recognizedValue"];


            return act;
        }
    }
}
