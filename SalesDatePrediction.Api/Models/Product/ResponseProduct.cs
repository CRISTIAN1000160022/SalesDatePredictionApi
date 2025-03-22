using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SalesDatePrediction.Model.DaoAccess.Master.Product;

namespace SalesDatePrediction.Api.Models.Product
{
	public class ResponseProduct
	{
        public class ResponseGetProduct : ResponseHeader
        {
            [JsonProperty(Order = 3)]
            public List<GetProduct> Data { get; set; }
        }
    }
}