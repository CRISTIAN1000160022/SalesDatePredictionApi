using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using SalesDatePrediction.Model.DaoAccess.Master.Login;
using SalesDatePrediction.Api.Models.Login;
using SalesDatePrediction.Api.Utilities;

namespace SalesDatePrediction.Api.Controllers
{
    public class LoginController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult Authenticate(RequestLogin login)
        {
            RequestLogin loginLog = new RequestLogin();
            loginLog.Username = login.Username;
            loginLog.Password = "";

            string Password = string.Empty;
            ResponseLogin ResponseLogin = new ResponseLogin();

            bool isCredentialValid = (login.Password == "123456");
            if (isCredentialValid)
            {
                string TokenCompleto = login.Username + "_" + DateTime.Now.ToString("yyyy-MM-dd");
                string token = TokenGenerator.GenerateTokenJwt(TokenCompleto);

                ResponseLogin.success = true;
                ResponseLogin.message = "Token Generado con éxito";
                ResponseLogin.Data = token;
                var json = JsonConvert.SerializeObject(ResponseLogin);
                var jsonString = new Utils().FormatJson(json);
                return Ok(jsonString);
            }
            else
            {
                ResponseLogin.success = false;
                ResponseLogin.message = "Contraseña incorrecta";
                ResponseLogin.Data = null;
                var json = JsonConvert.SerializeObject(ResponseLogin);
                var jsonString = new Utils().FormatJson(json);
                return Content(HttpStatusCode.Unauthorized, jsonString);
            }
        }
    }
}
