﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using TaskManagment.Forms.Work;
using TaskManagment.Models;

namespace TaskManagment.Forms
{
    public partial class WorkerHome : Form
    {
        bool isBegin = true;
        DateTime startdate;
        List<Unknown> projectList;
        int projectId;
        public WorkerHome()
        {
            InitializeComponent();
             this.Text = Global.CurrentWorker.Name;
            GetProjects();

        }

        private void GetProjects()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Global.path);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"getProject/{Global.CurrentWorker.Id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                projectList = JsonConvert.DeserializeObject<List<Unknown>>(result);
                if (projectList != null)
                {
                    dgv_task.DataSource = projectList;
                    dgv_task.Columns["Id"].Visible = false;
                    dgv_task.Columns["Date"].Visible = false;
                }

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private void UpdateTime()
        {
            lbl_message.Text = "";
            DateTime time = DateTime.Now;
            if (isBegin)
            {
                startdate = DateTime.Now;
                lbl_beginningTime.Text = startdate.ToString("hh:mm:ss tt");
                try {    projectId = (int)dgv_task.SelectedRows[0].Cells[0].Value;}
                catch {
                    lbl_message.Text = "choose project to start";
                    return; }
                btn_task.Text = "end Task";
            }
            else
            {
                btn_task.Text = "Start Task";
                lbl_beginningTime.Text = "";
            }
            timer.Enabled = !timer.Enabled;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Global.path}updateStartHour");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"hour\":\"" + time + "\"," +
                "\"idProjectWorker\":\"" + projectId + "\"," +
                "\"isFirst\":\"" + isBegin + "\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if(!isBegin)
                    {
                        GetProjects();
                        if (projectList != null)
                            UpdateChart();
                    }

                    isBegin = !isBegin;
                }
            }
            catch { }

        }

       void UpdateChart()
        {

            Dictionary<string, int> allocatedHours = new Dictionary<string, int>();
            List<float> workedHours = new List<float>();
          
                foreach (var item in projectList)
                {
                    allocatedHours.Add(item.Name, Convert.ToInt32(item.allocatedHours));
                    if (item.Hours != "")
                        workedHours.Add(float.Parse(item.Hours.Substring(0, 2) + "." + item.Hours.Substring(3, 2)));
                    else workedHours.Add(0);
                }

                chart1.Series[0].Points.DataBindXY(allocatedHours.Keys, allocatedHours.Values);
                chart1.Series[1].Points.DataBindXY(allocatedHours.Keys, workedHours);
            
        }
        private void WorkerHome_Load(object sender, EventArgs e)
        {
        if (projectList != null)
            UpdateChart();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btn_task_Click(object sender, EventArgs e)
        {
  UpdateTime();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            var d = (DateTime.Now - startdate);
            lbl_timer.Text = d.ToString(@"hh\:mm\:ss");
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            WorkEmail w = new WorkEmail();
            w.Show();
        }
        private void WorkerHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isBegin)
            {
                UpdateTime();
            }
        }

        private void dgv_task_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
