using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SalesDatePrediction.Model.DaoAccess.Master.Shipper;

namespace SalesDatePrediction.Api.Models.Shipper
{
	public class ResponseShipper
    {
		public class ResponseGetShipper : ResponseHeader
        {
            [JsonProperty(Order = 3)]
            public List<GetShipper> Data { get; set; }
        }
    }
}