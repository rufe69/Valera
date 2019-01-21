using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.DAI
{
    [JsonObject]
    public class CallbackObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("from_id")]
        public string From_id { get; set; }

        [JsonProperty("peer_id")]
        public string Peer_id { get; set; }
    }
}
