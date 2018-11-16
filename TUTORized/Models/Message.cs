using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TUTORized.Models
{
    public class Message
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("fromUserId")]
        public string FromUserId { get; set; }

        [JsonProperty("toUserId")]
        public string ToUserId { get; set; }

        [JsonProperty("messageBody")]
        public string MessageBody { get; set; }
    }
}
