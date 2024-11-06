using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFilter
{
    public class OrderFilterParams
    {
        [JsonProperty("_cityDistrict")]
        public string district {  get; set; } = string.Empty;

        [JsonProperty("_firstDeliveryDateTime")]
        public string firstDeliveryDateTimeStr { get; set; } = string.Empty;

        [JsonProperty("_deliveryLog")]
        public string logFilePath {  get; set; } = string.Empty;

        [JsonProperty("_deliveryOrder")]
        public string resultFilePath {  get; set; } = string.Empty;
    }
}
