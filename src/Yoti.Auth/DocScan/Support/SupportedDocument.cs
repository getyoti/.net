﻿using Newtonsoft.Json;

namespace Yoti.Auth.DocScan.Support
{
    public class SupportedDocument
    {
        public SupportedDocument(string type)
        {
            Type = type;
        }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; }
    }
}