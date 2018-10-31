using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using TaskManagment.Models;


namespace TaskManagment.Forms
{
    public partial class TeamLeaderHome : Form
    {
        List<Project> projectList;
        List<Worker> workerList;


        public TeamLeaderHome()
        {
            InitializeComponent();
            this.Text = Global.CurrentWorker.Name;
            getProject();
            getWorkers();

        }

        private void getWorkers()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Global.path);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetWorkersDeatails/{Global.CurrentWorker.Id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                workerList = JsonConvert.DeserializeObject<List<Worker>>(result);

                dgv_workers.DataSource = workerList;
                dgv_workers.Columns["Id"].Visible = false;
                dgv_workers.Columns["ManagerId"].Visible = false;
                //לסדר job
                //dgvProjects.Columns["jobId",0].Value = "fds";
            }
            else
            {

                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            }

        }

        private void getProject()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Global.path);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"getProjectDeatails/{Global.CurrentWorker.Id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                projectList = JsonConvert.DeserializeObject<List<Project>>(result);
                dgv_projects.DataSource = projectList;
                dgv_projects.Columns["Id"].Visible = false;
                dgv_projects.Columns["TeamLeaderId"].Visible = false;
            }
            else
            {

                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            }

        }

        private void dgv_projects_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TeamLeaderProjectDeatails p = new TeamLeaderProjectDeatails(projectList[e.RowIndex]);
            p.Show();
        }

        private void dgv_workers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TeamLeaderWorkers w = new TeamLeaderWorkers(workerList[e.RowIndex]);
            w.Show();
        }

        private void TeamLeaderHome_Load(object sender, EventArgs e)
        {

        }
    }


}

