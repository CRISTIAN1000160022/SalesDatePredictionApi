using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using SalesDatePrediction.Api.Utilities;
using SalesDatePrediction.Model.DaoAccess.Master.Order;
using SalesDatePrediction.Model.Service;
using static SalesDatePrediction.Api.Models.Order.ResponseOrder;

namespace SalesDatePrediction.Api.Controllers.Order
{
    [Authorize]
    public class OrderController : ApiController
    {
        //private readonly IOrderService _orderService;

        //public OrderController(IOrderService orderService)
        //{
        //    _orderService = orderService;
        //}

        [HttpGet]
        public IHttpActionResult GetOrderByClient(int CustomerId)
        {
            //Definimos el objeto que dara la respuesta
            ResponseOrderByClient ObjResponse = new ResponseOrderByClient();
            try
            {
                List<OrderByClient> OrderByClientList;
                OrderByClientList = new Facade().GetOrderByClient(CustomerId);

                ObjResponse.success = true;
                ObjResponse.message = "Lista de ordenes por cliente generada correctamente";
                ObjResponse.Data = OrderByClientList;
                return Ok(ObjResponse);
            }
            catch (Exception ex)
            {
                ObjResponse.success = false;
                ObjResponse.message = "Error: " + ex.Message;
                ObjResponse.Data = null;
                return Content(HttpStatusCode.BadRequest, ObjResponse);
            }
        }

        [HttpPost]
        public IHttpActionResult AddNewOrder(AddNewOrder AddNewOrderRequest)
        {
            //Definimos el objeto que dara la respuesta
            ResponseAddNewOrder ObjResponse = new ResponseAddNewOrder();
            try
            {
                // Validaciones de longitud
                if (AddNewOrderRequest.Shipname.Length > 40)
                {
                    throw new Exception("El campo 'Shipname' supera la longitud permitida de 40 caracteres.");
                }
                if (AddNewOrderRequest.Shipaddress.Length > 60)
                {
                    throw new Exception("El campo 'Shipaddress' supera la longitud permitida de 60 caracteres.");
                }
                if (AddNewOrderRequest.Shipcity.Length > 15)
                {
                    throw new Exception("El campo 'Shipcity' supera la longitud permitida de 15 caracteres.");
                }
                if (AddNewOrderRequest.Shipcountry.Length > 15)
                {
                    throw new Exception("El campo 'Shipcountry' supera la longitud permitida de 15 caracteres.");
                }

                AddNewOrder AddNewOrder;
                AddNewOrder = new Facade().AddNewOrder(AddNewOrderRequest);
                ObjResponse.success = true;
                ObjResponse.message = "Orden generada correctamente";
                ObjResponse.Data = AddNewOrder;
                return Ok(ObjResponse);
            }
            catch (Exception ex)
            {
                ObjResponse.success = false;
                ObjResponse.message = "Error: " + ex.Message;
                ObjResponse.Data = null;
                return Content(HttpStatusCode.BadRequest, ObjResponse);
            }
        }
    }
}