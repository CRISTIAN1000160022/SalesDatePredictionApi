using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using SalesDatePrediction.Api.Controllers;

namespace SalesDatePrediction.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración de rutas y servicios de API
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            #region Login
            config.Routes.MapHttpRoute(
            name: "AuthenticateLogin",
            routeTemplate: "Login/AuthenticateToken",
            defaults: new { controller = "Login", action = "Authenticate" }
            );
            #endregion
            #region Sales
            config.Routes.MapHttpRoute(
            name: "SalesDatePrediction",
            routeTemplate: "Sales/SalesDatePrediction",
            defaults: new { controller = "Sales", action = "GetSalesDatePrediction" }
            );
            #endregion
            #region Order
            config.Routes.MapHttpRoute(
            name: "GetOrderByClient",
            routeTemplate: "Order/GetOrderByClient/{CustomerId}",
            defaults: new { controller = "Order", action = "GetOrderByClient" }
            );
            config.Routes.MapHttpRoute(
            name: "AddNewOrder",
            routeTemplate: "Order/CreateNewOrder",
            defaults: new { controller = "Order", action = "AddNewOrder" }
            );
            #endregion
            #region Employee
            config.Routes.MapHttpRoute(
            name: "GetEmployee",
            routeTemplate: "Employee/GetAllEmployees",
            defaults: new { controller = "Employee", action = "GetEmployees" }
            );
            #endregion
            #region Shipper
            config.Routes.MapHttpRoute(
            name: "GetShipper",
            routeTemplate: "Shipper/GetAllShippers",
            defaults: new { controller = "Shipper", action = "GetShippers" }
            );
            #endregion
            #region Product
            config.Routes.MapHttpRoute(
            name: "GetProduct",
            routeTemplate: "Product/GetAllProducts",
            defaults: new { controller = "Product", action = "GetProducts" }
            );
            #endregion
        }
    }
}
