using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SalesDatePrediction.Api.Utilities
{
	public class Utils
	{
        /// <summary>
        /// Se formatea el JSON para que se vea de una manera mas bonita 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        internal object FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return parsedJson;
        }
    }
}