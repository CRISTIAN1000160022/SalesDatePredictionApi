using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using SalesDatePrediction.Api.Models.Sales;
using SalesDatePrediction.Api.Utilities;
using SalesDatePrediction.Model.DaoAccess.Master.Sales;
using SalesDatePrediction.Model.Service;
using static SalesDatePrediction.Api.Models.Sales.ResponseSales;

namespace SalesDatePrediction.Api.Controllers
{
    [Authorize]
    public class SalesController : ApiController
    {
        //private readonly ISalesService _salesService;

        //public SalesController(ISalesService salesService)
        //{
        //    _salesService = salesService;
        //}
        //[HttpGet]
        public IHttpActionResult GetSalesDatePrediction()
        {
            //Definimos el objeto que dara la respuesta
            ResponseSalesDatePrediction ObjResponse = new ResponseSalesDatePrediction();
            try
            {
                List<SalesPrediction> SalesPredictionList;
                SalesPredictionList = new Facade().GetSalesDatePrediction();

                ObjResponse.success = true;
                ObjResponse.message = "Lista de predicción de fechas de venta generada correctamente";
                ObjResponse.Data = SalesPredictionList;
                var json = JsonConvert.SerializeObject(ObjResponse);
                var jsonString = new Utils().FormatJson(json);
                return Ok(jsonString);
            }
            catch (Exception ex)
            {
                ObjResponse.success = false;
                ObjResponse.message = "Error: "+ ex.Message;
                ObjResponse.Data = null;
                var json = JsonConvert.SerializeObject(ObjResponse);
                var jsonString = new Utils().FormatJson(json);
                return Content(HttpStatusCode.BadRequest, jsonString);
            }
        }
    }
}
