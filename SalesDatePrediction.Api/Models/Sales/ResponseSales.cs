using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SalesDatePrediction.Model.DaoAccess.Master.Sales;

namespace SalesDatePrediction.Api.Models.Sales
{
	public class ResponseSales 
    {
        public class ResponseSalesDatePrediction : ResponseHeader
        {
            [JsonProperty(Order = 3)]
            public List<SalesPrediction> Data { get; set; }
        }
    }
}