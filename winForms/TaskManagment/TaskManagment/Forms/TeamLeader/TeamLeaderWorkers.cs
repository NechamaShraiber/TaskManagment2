using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using TaskManagment.Models;

namespace TaskManagment.Forms
{
    public partial class TeamLeaderWorkers : Form
    {
        int numHours = 0;
        public Worker worker;
       dynamic hoursList;
        public TeamLeaderWorkers(Worker w)
        {
            InitializeComponent();
            worker = w;
            this.Text = $"{Global.CurrentWorker.Name} worker name: {worker.Name}";
            UpdateWorkerDeatails();
            getWorkerHours();
        }

        /// <summary>
        /// show worker's hours
        /// </summary>
        private void getWorkerHours()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Global.path);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"getWorkerHours/{Global.CurrentWorker.Id}/{worker.Id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                hoursList = JsonConvert.DeserializeObject(result);
                if (hoursList != null)
                {
                    dgv_workerHours.DataSource = hoursList;
                    dgv_workerHours.Columns["Id"].Visible = false;
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        /// <summary>
        /// shou worker deatails
        /// </summary>
        private void UpdateWorkerDeatails()
        {
            lbl_workerName.Text = worker.Name;
            lbl_workerUserName.Text = worker.UserName;
            lbl_workerEmail.Text = worker.EMail;
            lbl_job.Text = Global.jobs.Find(j => j.Id == worker.JobId).Name;
        }

        /// <summary>
        /// validation for txtNumHours
        /// </summary>
        private void txtNumHours_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!int.TryParse(txt_numHours.Text, out numHours))
            {
                lblMessage.Text = "hours must be number";

            }
        }

        /// <summary>
        /// change allocated Hours
        /// </summary>
       
        private void btn_change_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            int index;
            try {
                index = dgv_workerHours.SelectedRows[0].Index;
            int workerId = Convert.ToInt32(hoursList[index]["Id"].Value);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Global.path + "updateWorkerHours");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"projectWorkerId\":\"" + workerId + "\"," +
                   "\"numHours\":\"" + numHours + "\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                        hoursList[index]["AllocatedHours"].Value = numHours;
                    var result = streamReader.ReadToEnd();
                    dynamic obj = JsonConvert.DeserializeObject<Worker>(result);
                    dgv_workerHours.DataSource = hoursList;
                }
            }
            catch (WebException ex)
            {

            }
            }
            catch
            {
                lblMessage.Text = "choose project to edit allocated hours";
            }
        }

    }
}
