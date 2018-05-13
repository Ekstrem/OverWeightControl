using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OverWeightControl.Common.BelModel
{
    public class BlankValues
    {
        [JsonProperty("date")]
        public FullValue date { get; set; }

        [JsonProperty("reason")]
        public FullValue reason { get; set; }

        [JsonProperty("country")]
        public FullValue country { get; set; }

        [JsonProperty("code")]
        public FullValue code { get; set; }

        [JsonProperty("informationAbout")]
        public FullValue informationAbout { get; set; }

        [JsonProperty("vehicleInformation")]
        public FullValue vehicleInformation { get; set; }

        [JsonProperty("employeeFullName")]
        public FullValue employeeFullName { get; set; }

        [JsonProperty("distanceBetween")]
        public FullValue distanceBetween { get; set; }

        [JsonProperty("ppvkNumber")]
        public FullValue ppvkNumber { get; set; }

        [JsonProperty("goodsCharacteristics")]
        public FullValue goodsCharacteristics { get; set; }

        [JsonProperty("controlDate")]
        public FullValue controlDate { get; set; }

        [JsonProperty("violationType")]
        public FullValue violationType { get; set; }

        [JsonProperty("driverCardNumber")]
        public FullValue driverCardNumber { get; set; }

        [JsonProperty("typeTransportation")]
        public FullValue typeTransportation { get; set; }

        [JsonProperty("from")]
        public FullValue from { get; set; }

        [JsonProperty("typeGoods")]
        public FullValue typeGoods { get; set; }

        [JsonProperty("fullNameOwner")]
        public FullValue fullNameOwner { get; set; }

        [JsonProperty("driverFullName")]
        public FullValue driverFullName { get; set; }

        [JsonProperty("controlsPlace")]
        public FullValue controlsPlace { get; set; }

        [JsonProperty("axleLoads")]
        public FullValue axleLoads { get; set; }

        [JsonProperty("weightOfCargo")]
        public FullValue weightOfCargo { get; set; }

        [JsonProperty("weighingMachineNumber")]
        public FullValue weighingMachineNumber { get; set; }

        [JsonProperty("special")]
        public FullValue special { get; set; }

        [JsonProperty("certificateNumber")]
        public FullValue certificateNumber { get; set; }

        [JsonProperty("blankId")]
        public FullValue blankId { get; set; }

        [JsonProperty("operatorFullName")]
        public FullValue operatorFullName { get; set; }

        [JsonProperty("time")]
        public FullValue time { get; set; }

        [JsonProperty("addressOrganization")]
        public FullValue addressOrganization { get; set; }
    }
}
