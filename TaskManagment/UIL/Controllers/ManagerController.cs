using BOL;
using BLL;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Formatting;
using System.Collections.Generic;

namespace UIL.Controllers
{
    public class ManagerController : ApiController
    {
        

        /// <summary>
        /// add new project
        /// </summary>
        /// <param name="Project">Project deatails</param>
        /// 
        [HttpPost]
        [Route("api/addProject")]
        public HttpResponseMessage AddProject([FromBody]Project value)
        {
            //curl -v -X POST -H "Content-type: application/json" -d "{\"Name\":\"tryProject\", \"Customer\":\"nnn\",\"TeamLeaderId\":\"11\" , \"DevelopHours\":\"300\",\"QAHours\":\"250\", \"UiUxHours\":\"100\",\"StartDate\":\"2018-02-02\",\"EndDate\":\"2018-07-07\"}"  http://localhost:59628/api/addProject
           // value.EndDate.tos
            if (ModelState.IsValid)
            {
             
                return (ManagerLogic.AddProject(value)) ?
                   new HttpResponseMessage(HttpStatusCode.Created) :
                   new HttpResponseMessage(HttpStatusCode.BadRequest)
                   {
                       Content = new ObjectContent<String>("Can not add to DB", new JsonMediaTypeFormatter())
                   };
            }
            return Global.ErrorList(ModelState);
         
        }
        [HttpPost]
        [Route("api/addWorkersToProject/{name}")]
        public HttpResponseMessage addWorkersToProject([FromBody]int[] ids, [FromUri]string name)
        {
            //curl -v -X POST -H "Content-type: application/json" -d "{\"Name\":\"tryProject\", \"Customer\":\"nnn\",\"TeamLeaderId\":\"11\" , \"DevelopHours\":\"300\",\"QAHours\":\"250\", \"UiUxHours\":\"100\",\"StartDate\":\"2018-02-02\",\"EndDate\":\"2018-07-07\"}"  http://localhost:59628/api/addProject
            // value.EndDate.tos
            return (ManagerLogic.addWorkersToProject(ids, name)) ?

                     new HttpResponseMessage(HttpStatusCode.OK) :
                     new HttpResponseMessage(HttpStatusCode.BadRequest)
                     {
                         Content = new ObjectContent<String>("Can not update in Data Base", new JsonMediaTypeFormatter())
                     };


        }

        /// <summary>
        /// add new worker
        /// </summary>
        /// <param name="Project">Project deatails</param>
        /// 
        [HttpPost]
        [Route("api/addWorker")]
        public HttpResponseMessage AddWorker([FromBody]Worker value)
        {
            //curl -v -X POST -H "Content-type: application/json" -d "{\"Name\":\"Gila\",\"UserName\":\"gggg\",\"Password\":\"gggggg\",\"JobId\":\"4\",\"EMail\":\"safdsa@fdsaf\",\"ManagerId\":\"11\"}"  http://localhost:59628/api/addWorker
            //
            if (ModelState.IsValid)
            {
                return (ManagerLogic.AddWorker(value)) ?
                   new HttpResponseMessage(HttpStatusCode.Created) :
                   new HttpResponseMessage(HttpStatusCode.BadRequest)
                   {
                       Content = new ObjectContent<String>("Can not add to DB", new JsonMediaTypeFormatter())
                   };
            }
            return Global.ErrorList(ModelState);

        }


        /*
        ●	ניהול דוחות - מנוע הפקת דוחות לפי חודש/עובד/ראש צוות/פרויקט.
o	חובה שיהיה ייצוא לאקסל.
Get - get all the details that the manager need to the report
        
         [HttpGet]
        [Route("api/addDeatails/{projectId}/{teamLeaderId}/{month}/{workerId}")]
        public HttpResponseMessage GetDeatails(int? projectId, int? teamLeaderId, string month, int? workerId)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<String>(ManagerLogic.GetDeatails(projectId,teamLeaderId,month,workerId), new JsonMediaTypeFormatter())
            };
        }


 */


        
       
        /// <summary>
        /// edit worker's details
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/updateWorker")]
        public HttpResponseMessage UpdateWorker([FromBody]Worker value)
        {
            //curl -v -X PUT -H "Content-type: application/json" -d "{\"Id\":\"7\",\"Name\":\"Malki\", \"UserName\":\"ggggg\",\"Password\":\"mmmggg\" , \"JobId\":\"3\",\"EMail\":\"sjafjkl@dfaf\", \"ManagerId\":\"5\"}"  http://localhost:59628/api/UpdateWorker
             if (ModelState.IsValid)
            {
                return (ManagerLogic.UpdateWorker(value)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                    };
            };

           return Global.ErrorList(ModelState);
        }
        /// <summary>
        /// get all workers
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/getAllWorkers")]
        public HttpResponseMessage GetAllWorkers()
        {

            //curl -X GET -v http://localhost:59628/api/getAllWorkers
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Worker>>(ManagerLogic.GetAllWorkers(), new JsonMediaTypeFormatter())
            };
        }

 [HttpGet]

        [Route("api/getPresence")]
        public HttpResponseMessage GetPresence()

        {

            //curl -X GET -v http://localhost:59628/api/GetPresence
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Object>>(ManagerLogic.GetPresence(), new JsonMediaTypeFormatter())
            };
        }
        [HttpGet]
        [Route("api/getAllJobs")]
        public HttpResponseMessage GetAllJobs()
        {

            //curl -X GET -v http://localhost:59628/api/getAllWorkers
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Job>>(ManagerLogic.GetAllJobs(), new JsonMediaTypeFormatter())
            };
        }

        /// <summary>
        /// get all managers
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/getAllManagers")]
        public HttpResponseMessage GetAllManagers()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Worker>>(ManagerLogic.GetAllManagers(), new JsonMediaTypeFormatter())
            };
        }
        /// <summary>
        /// delete worker
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpDelete]
        [Route("api/deleteWorker/{id}")]
        public HttpResponseMessage DeleteWorker(int id)
        //curl -X DELETE -v http://localhost:59628/api/deleteWorker/id=8
        {
            return (ManagerLogic.RemoveWorker(id)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not remove from DB", new JsonMediaTypeFormatter())
                    };
        }
    }
}
