using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SalesDatePrediction.Api.Models
{
	public class ResponseHeader
	{
        [JsonProperty(Order = 1)]
        public bool success { get; set; }
        [JsonProperty(Order = 2)]
        public string message { get; set; }
    }
}