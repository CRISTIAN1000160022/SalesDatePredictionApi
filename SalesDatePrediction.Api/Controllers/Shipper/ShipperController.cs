using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using SalesDatePrediction.Api.Utilities;
using SalesDatePrediction.Model.DaoAccess.Master.Shipper;
using SalesDatePrediction.Model.Service;
using static SalesDatePrediction.Api.Models.Shipper.ResponseShipper;

namespace SalesDatePrediction.Api.Controllers.Shipper
{
    [Authorize]
    public class ShipperController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetShippers()
        {
            //Definimos el objeto que dara la respuesta
            ResponseGetShipper ObjResponse = new ResponseGetShipper();
            try
            {
                List<GetShipper> GetShipperList;
                GetShipperList = new Facade().GetShipper();
                ObjResponse.success = true;
                ObjResponse.message = "Lista de transportistas generada correctamente";
                ObjResponse.Data = GetShipperList;
                var json = JsonConvert.SerializeObject(ObjResponse);
                var jsonString = new Utils().FormatJson(json);
                return Ok(jsonString);
            }
            catch (Exception ex)
            {
                ObjResponse.success = false;
                ObjResponse.message = "Error: " + ex.Message;
                ObjResponse.Data = null;
                var json = JsonConvert.SerializeObject(ObjResponse);
                var jsonString = new Utils().FormatJson(json);
                return Content(HttpStatusCode.BadRequest, jsonString);
            }
        }
    }
}
