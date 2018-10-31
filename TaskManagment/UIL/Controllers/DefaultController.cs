using BLL;
using BOL;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace UIL.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpGet]
        [Route("api/get")]
        public HttpResponseMessage Get()
        {
           return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Job>>(Logic.GetJobs(), new JsonMediaTypeFormatter())
            };
        }

    }
}
