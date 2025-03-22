using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using SalesDatePrediction.Api.Utilities;
using SalesDatePrediction.Model.DaoAccess.Master.Product;
using SalesDatePrediction.Model.Service;
using static SalesDatePrediction.Api.Models.Product.ResponseProduct;

namespace SalesDatePrediction.Api.Controllers.Product
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            //Definimos el objeto que dara la respuesta
            ResponseGetProduct ObjResponse = new ResponseGetProduct();
            try
            {
                List<GetProduct> GetProductList;
                GetProductList = new Facade().GetProduct();

                ObjResponse.success = true;
                ObjResponse.message = "Lista de productos generada correctamente";
                ObjResponse.Data = GetProductList;
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
