using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Models;

namespace TaskManagment
{
    public enum eJobs {Manager=1,TeamLeader,QA,UxUi, Developer}      
    class Global
    {
        public static string path = "http://localhost:59628/api/";
        public static Worker worker = new Worker();
        public static Worker CurrentWorker;
        public static List<Worker> manager = new List<Worker>();
        public static List<Worker> workers = new List<Worker>();
        public static List<Worker> GetManagers()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(new Uri($"{path}getAllManagers")).Result;
            return JsonConvert.DeserializeObject<List<Worker>>(response);
        }


    }
}
