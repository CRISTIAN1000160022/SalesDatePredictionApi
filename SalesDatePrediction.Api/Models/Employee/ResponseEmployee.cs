using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SalesDatePrediction.Model.DaoAccess.Master.GetEmployee;

namespace SalesDatePrediction.Api.Models.Employee
{
	public class ResponseEmployee
	{
        public class ResponseGetEmployee : ResponseHeader
        {
            [JsonProperty(Order = 3)]
            public List<GetEmployee> Data { get; set; }
        }
    }
}