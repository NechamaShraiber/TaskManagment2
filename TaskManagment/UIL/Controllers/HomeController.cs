using BLL;
using BOL;
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
        //curl -v -X POST -H "Content-type: application/json" -d "{\"UserName\":\"DDD\", \"Password\":\"444444\"}"  http://localhost:59628/api/login
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


    }
}