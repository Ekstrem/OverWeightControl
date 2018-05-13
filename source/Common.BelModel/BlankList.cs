using System;
using Newtonsoft.Json;

namespace OverWeightControl.Common.BelModel
{
    public class BlankList
    {

        [JsonProperty("blankValues")]
        public BlankValues blankValues { get; set; }

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