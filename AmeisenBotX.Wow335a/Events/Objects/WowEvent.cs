﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AmeisenBotX.Wow335a.Events.Objects
{
    public class WowEvent
    {
        [JsonPropertyName("args")]
        public List<string> Arguments { get; set; }

        [JsonPropertyName("event")]
        public string Name { get; set; }

        [JsonPropertyName("time")]
        public long Timestamp { get; set; }
    }
}