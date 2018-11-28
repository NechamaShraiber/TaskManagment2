using BLL;
using BOL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace UIL.Controllers
{
    public class TeamLeaderController : ApiController
    {
    
        [HttpGet]
        [Route("api/getProjectDeatails/{teamLeaderId}")]
        public HttpResponseMessage GetProjectDeatails(int teamLeaderId) => new HttpResponseMessage(HttpStatusCode.OK)
        {
          
            //curl -X GET -v http://localhost:59628/api/getProjectDeatails/5
            Content = new ObjectContent<List<Project>>(TeamLeaderLogic.GetProjectDeatails(teamLeaderId), new JsonMediaTypeFormatter())
        };
        [HttpGet]
        [Route("api/getWorkersDeatails/{teamLeaderId}")]
        public HttpResponseMessage GetWorkersDeatails(int teamLeaderId) => new HttpResponseMessage(HttpStatusCode.OK)
        {

            //curl -X GET -v http://localhost:59628/api/getWorkersDeatails/11
            Content = new ObjectContent<List<Worker>>(TeamLeaderLogic.GetWorkersDeatails(teamLeaderId), new JsonMediaTypeFormatter())
        };
        [HttpGet]
        [Route("api/getWorkersHours/{projectId}")]
        public HttpResponseMessage GetWorkersHours(int projectId) => new HttpResponseMessage(HttpStatusCode.OK)
        {

            //curl -X GET -v http://localhost:59628/api/getWorkersHours/11
            Content = new ObjectContent<List<Object>>(TeamLeaderLogic.getWorkersHours(projectId), new JsonMediaTypeFormatter())
        };
        [HttpGet]
        [Route("api/getWorkerHours/{teamLeaderId}/{workerId}")]
        public HttpResponseMessage GetWorkerHours(int teamLeaderId, int workerId) => new HttpResponseMessage(HttpStatusCode.OK)
        {

            //curl -X GET -v http://localhost:59628/api/getWorkerHours/5/6
            Content = new ObjectContent<List<Object>>(TeamLeaderLogic.getWorkerHours(teamLeaderId,workerId), new JsonMediaTypeFormatter())
        };
        [HttpGet]
        [Route("api/getHours/{projectId}")]
        public HttpResponseMessage GetHours(int projectId)
        //curl -X GET -v http://localhost:59628/api/GetHours/10/1
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<String>(TeamLeaderLogic.GetHours(projectId), new JsonMediaTypeFormatter())
            };
        }
        [HttpPut]
        [Route("api/updateWorkerHours")]
        public HttpResponseMessage UpdateWorkerHours([FromBody]JObject data)
        {
            int projectWorkerId=(int)data["projectWorkerId"];
            int numHours = (int)data["numHours"];

            //curl -v -X PUT -H "Content-type: application/json" -d "{\"projectWorkerId\":\"1\",\"numHours\":\"30\"}"  http://localhost:59628/api/updateWorkerHours
            return (TeamLeaderLogic.UpdateWorkerHours(projectWorkerId, numHours)) ?
           
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in Data Base", new JsonMediaTypeFormatter())
                    };
          

           
        }

    }
}