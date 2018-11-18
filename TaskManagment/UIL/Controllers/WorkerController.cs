using System;

using BOL;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using BLL;
using Newtonsoft.Json.Linq;

namespace UIL.Controllers
{
    public class WorkerController : ApiController
    {
        /// <summary>
        /// update hours
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/updateStartHour")]
        public HttpResponseMessage UpdateStartHour([FromBody]JObject data)
        {
            //curl -v -X PUT -H "Content-type: application/json" -d "{\"Id\":\"7\",\"hour\":\"8\"}"  http://localhost:59628/api/updateHours
            if (ModelState.IsValid)
            {
                bool isFirst = (bool)data["isFirst"];
                string s = (string)data["hour"];
                return ((isFirst? WorkerLogic.UpdateStartHour((int)data["idProjectWorker"],Convert.ToDateTime(s))
                    :WorkerLogic.UpdateEndHour((int)data["idProjectWorker"], Convert.ToDateTime(s))) ?
                new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                    });
            };

            return Global.ErrorList(ModelState);
        }

        [HttpPost]
        [Route("api/SendMsg")]
        public HttpResponseMessage SendMsg([FromBody] JObject data)

        {
            //curl -v -X POST -H "Content-type: application/json" -d "{\"email\":\"malky8895@gmail.com\"}"  http://localhost:59628/api/sendreq

            if (ModelState.IsValid)
            {
                return (WorkerLogic.SendMsg((string)data["sub"], (string)data["body"],(int)data["id"])) ?
                   new HttpResponseMessage(HttpStatusCode.OK) :
                   new HttpResponseMessage(HttpStatusCode.BadRequest)
                   {
                       Content = new ObjectContent<String>("Can not send Email", new JsonMediaTypeFormatter())
                   };
            }
            return Global.ErrorList(ModelState);

        }

        [HttpGet]
        [Route("api/getWorkerDetails/{id}")]
        public HttpResponseMessage GetWorkerDetails(int id)
        {
            //curl -X GET -v http://localhost:59628/api/getWorkerDetails/6
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Worker>>(WorkerLogic.GetWorkerDetails(id), new JsonMediaTypeFormatter())
            };
        }
        [HttpGet]
        [Route("api/getProject/{id}")]
        public HttpResponseMessage GetProject(int id)
        {
            //curl -X GET -v http://localhost:59628/api/getProject/6
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Unknown>>(WorkerLogic.GetProject(id), new JsonMediaTypeFormatter())
            };
        }
        [HttpGet]
        [Route("api/getAllHours/{id}")]
        public HttpResponseMessage GetAllHours(int id)
        {
            //curl -X GET -v http://localhost:59628/api/getAllHours/6
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<string>(WorkerLogic.GetAllHours(id), new JsonMediaTypeFormatter())
            };
        }
    }
}