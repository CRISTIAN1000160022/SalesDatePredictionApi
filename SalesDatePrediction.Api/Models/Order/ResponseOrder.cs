using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SalesDatePrediction.Model.DaoAccess.Master.Order;

namespace SalesDatePrediction.Api.Models.Order
{
	public class ResponseOrder
	{
        public class ResponseOrderByClient : ResponseHeader
        {
            [JsonProperty(Order = 3)]
            public List<OrderByClient> Data { get; set; }
        }
        public class ResponseAddNewOrder : ResponseHeader
        {
            [JsonProperty(Order = 3)]
            public AddNewOrder Data { get; set; }
        }
    }
}