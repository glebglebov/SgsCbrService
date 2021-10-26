using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SgsCbrService.Core.CBR.Model;

namespace SgsCbrService.Core.CBR.Responses
{
    public class DailyCurrenciesResponse
    {
        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [JsonProperty("PreviousDate")]
        public DateTime PreviousDate { get; set; }

        [JsonProperty("PreviousURL")]
        public string PreviousUrl { get; set; }

        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("Valute")]
        public Dictionary<string, Valute> Valutes { get; set; }
    }
}
