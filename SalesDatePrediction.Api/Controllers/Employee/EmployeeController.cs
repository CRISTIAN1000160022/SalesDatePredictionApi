using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using SalesDatePrediction.Api.Models.Employee;
using SalesDatePrediction.Api.Utilities;
using SalesDatePrediction.Model.DaoAccess.Master.GetEmployee;
using SalesDatePrediction.Model.Service;
using static SalesDatePrediction.Api.Models.Employee.ResponseEmployee;

namespace SalesDatePrediction.Api.Controllers.Employee
{
    [Authorize]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            //Definimos el objeto que dara la respuesta
            ResponseGetEmployee ObjResponse = new ResponseGetEmployee();
            try
            {
                List<GetEmployee> GetEmployeeList;
                GetEmployeeList = new Facade().GetEmployee();

                ObjResponse.success = true;
                ObjResponse.message = "Lista de empleados generada correctamente";
                ObjResponse.Data = GetEmployeeList;
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
