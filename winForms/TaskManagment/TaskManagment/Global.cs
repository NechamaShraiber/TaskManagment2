using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Models;

namespace TaskManagment
{
  // public enum eJobs {Manager=1,TeamLeader,QA,UxUi, Developer}      
   static class Global
    {
        static  Global()
        {
            getAllJobs();
        }
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
        public static List<Job> jobs;
        public static void getAllJobs()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Global.path);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"getAllJobs").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                jobs = JsonConvert.DeserializeObject<List<Job>>(result);

            }
            else
            {

                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            }
        }

    }
}
