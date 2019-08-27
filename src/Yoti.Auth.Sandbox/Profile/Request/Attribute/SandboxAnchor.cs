﻿using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.Profile.Request.Attribute
{
    public class SandboxAnchor
    {
        internal SandboxAnchor(string type, string value, string subType, long timestamp)
        {
            Type = type;
            Value = value;
            SubType = subType;
            Timestamp = timestamp;
        }

        public static SandboxAnchorBuilder Builder()
        {
            return new SandboxAnchorBuilder();
        }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; }

        [JsonProperty(PropertyName = "sub_type")]
        public string SubType { get; }

        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; }
    }
}