using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Valera_bot.Models
{
    [JsonObject]
    public class CallbackEvent
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("object")]
        public CallbackObject Object { get; set; }

        [JsonProperty("group_id")]
        public int Group_id { get; set; }
    }
}
