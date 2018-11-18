using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using TaskManagment.Models;

namespace TaskManagment.Forms
{
    public partial class TeamLeaderProjectDeatails : Form
    {
        public Project project;
        List<Unknown> workersHours=new List<Unknown>();
        public TeamLeaderProjectDeatails(Project p)
        {
            InitializeComponent();
            project = p;
            this.Text = $"{Global.CurrentWorker.Name}: {project.Name}";
            UpdateProjectDeatails();
            getWorkersHours();
            getSumHours();
        }

        private void getSumHours()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Global.path);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetHours/{project.Id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
              
                lbl_hours.Text = JsonConvert.DeserializeObject<string>(result);
            }

            else
            {

                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            }
        }

        private void getWorkersHours()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Global.path);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"getWorkersHours/{project.Id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                workersHours = JsonConvert.DeserializeObject<List<Unknown>>(result);
                if (workersHours != null) { 
                    dgv_workersHours.DataSource = workersHours;
                dgv_workersHours.Columns["Id"].Visible = false; }
            }

            else
            {

                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            }
        }
        private void UpdateProjectDeatails()
        {
            lbl_projectName.Text = project.Name;
            lbl_projectCustomer.Text = project.Customer;
            lbl_projectDeveloperHours.Text = project.DevelopHours.ToString();
            lbl_projectQAHours.Text = project.QAHours.ToString();
            lbl_projectUxUiHours.Text = project.UiUxHours.ToString();
            lbl_projectStartDate.Text = project.StartDate.ToString();
            lbl_projectEndDate.Text = project.EndDate.ToString();

        }

        private void ProjectDeatails_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> allocatedHours = new Dictionary<string, int>();
            List<float> workedHours = new List<float>();
            if (workersHours != null) { 
            foreach (var item in workersHours)
            {
                allocatedHours.Add(item.Name, Convert.ToInt32( item.AllocatedHours));
                    if (item.Hours != "")
                    {
                        var t = item.Hours.Split(':');
                        workedHours.Add(float.Parse(t[0]) + (float.Parse(t[1]) / 100));
                    }
                    else workedHours.Add(0);
               
               
            }
            chart1.Series[0].Points.DataBindXY(allocatedHours.Keys, allocatedHours.Values);
            chart1.Series[1].Points.DataBindXY(allocatedHours.Keys, workedHours);}
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
