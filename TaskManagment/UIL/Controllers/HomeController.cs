using BLL;
using BOL;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace UIL.Controllers
{
    public class HomeController : ApiController
    {
        [EnableCors("*", "*", "*")]
        // POST api/<controller>
        //curl -v -X POST -H "Content-type: application/json" -d "{\"UserName\":\"mm\", \"Password\":\"mmm123\"}"  http://localhost:59628/api/login
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login([FromBody]Worker worker)
        {
            Worker w = HomeLogic.Login(worker.UserName, worker.Password);
            if (w != null)
                return new HttpResponseMessage(HttpStatusCode.OK)
                {

                    Content = new ObjectContent<Worker>(w, new JsonMediaTypeFormatter())

                };
            else return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<String>("Can not log in", new JsonMediaTypeFormatter())
            };

        }
        [HttpPost]
        [Route("api/updatePassword")]
        public HttpResponseMessage UpdatePassword([FromBody]JObject data)
        {
            string userName = (string)data["userName"];
            string oldpassword = (string)data["oldpassword"];
            string newPassord = (string)data["newPassord"];
            return (HomeLogic.UpdatePassword(userName, oldpassword, newPassord) ?
                   new HttpResponseMessage(HttpStatusCode.OK) :
                   new HttpResponseMessage(HttpStatusCode.BadRequest)
                   {
                       Content = new ObjectContent<String>("The password dont currect", new JsonMediaTypeFormatter())
                   });

        }
    }
}