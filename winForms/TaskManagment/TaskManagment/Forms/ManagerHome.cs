using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using TaskManagment.Models;
using NsExcel= Microsoft.Office.Interop.Excel;


namespace TaskManagment.Forms
{
    public partial class ManagerHome : Form
    {
        List<Worker> manager;
        List<Worker> workerToSelect;
        List<Worker> workerToAdd;
        public ManagerHome()
        {
            InitializeComponent();
            AddProject();
            tab_manager.Controls.Remove(tab_workerDeatrails);
            getAllWorkers();
            GetPresences();
        }
        public void getAllWorkers()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Global.path);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"getAllWorkers").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                workerList = JsonConvert.DeserializeObject<List<Worker>>(result);

            }
            else
            {

                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            }
        }
        void checkVaidationLength(int min, int max, TextBox textBox)
        {
            if (textBox.Text.Length < min || textBox.Text.Length > max)
            {
                errorProvider1.SetError(textBox, $" must be between {min}-{max}");
            }
            else
            {
                errorProvider1.Clear();
                checkValidButton();
            }
        }
        void checkVaidationNumber(int min, int max, TextBox textBox)
        {
            if (!int.TryParse(textBox.Text, out int num))
                errorProvider1.SetError(txt_QI_houers, $"must be number");
            if (textBox.Text.Length == 0 || num < min)
                errorProvider1.SetError(txt_QI_houers, $"must be greater than {min}");
            else
            {
                errorProvider1.Clear();

            }
        }
        #region addProject

        public void AddProject()
        {

            btn_addProject.Enabled = false;
            data_start.MinDate = DateTime.Now;
            data_end.MinDate = data_start.Value;
            data_start.CustomFormat = "yyyy-MM-dd";
            data_start.CustomFormat = "yyyy-MM-dd";
            manager = Global.GetManagers();
            manager.ForEach(t => { txt_team_name.Items.Add(t.Name); });
            // txt_team_name.DataSource = manager.Select(m => m.Name);
        }

        public void checkValidProjName(object sender, EventArgs e)
        {
            checkVaidationLength(2, 25, (sender as TextBox));
            checkValidButton();
        }
        public void checkValidCustomerName(object sender, EventArgs e)
        {
            checkVaidationLength(2, 15, (sender as TextBox));
            checkValidButton();
        }

        public void checkValidQAHours(object sender, EventArgs e)
        {
            checkVaidationNumber(0, 0, (sender as TextBox));
            checkValidButton();
        }
        public void checkValidDeveloperHours(object sender, EventArgs e)
        {
            checkVaidationNumber(0, 0, (sender as TextBox));
            checkValidButton();
        }
        public void checkValidUIUXHours(object sender, EventArgs e)
        {
            checkVaidationNumber(0, 0, (sender as TextBox));
            checkValidButton();
        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////
        /// </summary>
        public void checkValidButton()
        {
            if ((txt_customer_name.Text.Length > 2 && txt_customer_name.Text.Length < 15) &&
                    (txt_team_name.Text.Length > 2 && txt_team_name.Text.Length < 15) &&
                    (txt_QI_houers.Text.Length != 0 && (Convert.ToInt32(txt_QI_houers.Text) > 0)) &&
                    (txt_developer_hours.Text.Length != 0 && (Convert.ToInt32(txt_developer_hours.Text) > 0)) &&
                    (txt_UIUX_hours.Text.Length != 0 && (Convert.ToInt32(txt_UIUX_hours.Text) > 0)) &&
                    (txt_projName.Text.Length > 2 && txt_projName.Text.Length < 25))
                btn_addProject.Enabled = true;
            //else btn_add.Enabled = false;
        }

        public void addWorkersToProject(string name)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Global.path}addWorkersToProject/{name}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            dynamic credential;

            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    credential = workerToAdd.Select(w => w.Id);
                    string credentialString = Newtonsoft.Json.JsonConvert.SerializeObject(credential, Formatting.None);
                    streamWriter.Write(credentialString);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();


                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Can not add a project");
            }
        }

        private void btn_addProject_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Global.path + "addProject");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            dynamic credential;
            int id = manager.Where(m => m.Name == txt_team_name.SelectedItem.ToString()).FirstOrDefault().Id;

            Project proj = new Project()
            {
                Name = txt_projName.Text,
                Customer = txt_customer_name.Text,
                TeamLeaderId = id,
                QAHours = int.Parse(txt_QI_houers.Text),
                DevelopHours = int.Parse(txt_developer_hours.Text),
                UiUxHours = int.Parse(txt_UIUX_hours.Text),
                StartDate = data_start.Value.Date,
                EndDate = data_end.Value.Date
            };
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    credential = proj;
                    string credentialString = Newtonsoft.Json.JsonConvert.SerializeObject(credential, Formatting.None);
                    streamWriter.Write(credentialString);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();


                    MessageBox.Show($"The project {proj.Name} added successfully");
                    addWorkersToProject(proj.Name);
                    /*
                     * 
                     */

                    //{
                    //                  addWorkersToProject(workers: Worker[], name):any{
                    //                      this.ids =[];
                    //                      workers.forEach(w => {
                    //                          this.ids.push(w.Id);
                    //                      });
                    //                      return this.http.post("http://localhost:59628/api/addWorkersToProject/" + name + "/", JSON.parse(JSON.stringify(this.ids)))

                    //}

                    //}

                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Can not add a project");
            }
        }
        #endregion

        #region UserManagment

        List<Worker> workerList;

        HttpClient httpClient = new HttpClient();
        private void btn_add_worker_Click(object sender, EventArgs e)
        {
            tab_manager.Controls.Add(tab_workerDeatrails);
            tab_manager.SelectedTab = tab_workerDeatrails;
            WorkerDeatails(true, null);
            //WorkerDeatails addWorker = new WorkerDeatails(true, null);
            //addWorker.Show();
        }

        void GetAllWorker()
        {
            panelControlls.Controls.Clear();
            panelControlls.BorderStyle = BorderStyle.FixedSingle;

            ComboBox cb = new ComboBox() { Name = "cbWorkers" };
            cb.Items.AddRange(workerList.Select(w => w.UserName).ToArray());
            cb.Location = new Point(250, 50);
            panelControlls.Controls.Add(cb);
            getAllWorkers();


        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            GetAllWorker();
            btn_delete.Enabled = false;
            string s = (sender as Button).Text == "Delete worker" ? "delete" : "edit";
            Label l = new Label() { Text = $"Chooose worker to {s}:" };
            Label l2 = new Label() { Text = "X" };
            Button bt = new Button() { Text = s };
            l.Location = new Point(50, 50);
            l2.Location = new Point(30, 30);
            bt.Location = new Point(150, 90);
            panelControlls.Controls.Add(l);
            panelControlls.Controls.Add(l2);
            panelControlls.Controls.Add(bt);
            bt.Click += new EventHandler(b_Click);
            l2.Click += new EventHandler(l2_click);
        }


        void l2_click(object sender, EventArgs e)
        {
            panelControlls.Controls.Clear();
            panelControlls.BorderStyle = BorderStyle.None;
            btn_delete.Enabled = true;
            btn_edit.Enabled = true;
        }

        void b_Click(object sender, EventArgs e)
        {
            Worker w1 = new Worker();
            int id = workerList.FirstOrDefault(w => w.UserName == (panelControlls.Controls["cbWorkers"] as ComboBox).Text).Id;
            w1 = workerList.FirstOrDefault(w => w.Id == id);
            if ((sender as Button).Text == "delete")
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Global.path);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync($"deleteWorker/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                    workerList.Remove(w1);
                    (panelControlls.Controls["cbWorkers"] as ComboBox).Items.Clear();
                    (panelControlls.Controls["cbWorkers"] as ComboBox).Text = "";
                    (panelControlls.Controls["cbWorkers"] as ComboBox).Items.AddRange(workerList.Select(w => w.UserName).ToArray());



                }
            }
            else
            {
                l2_click(sender, e);
                tab_manager.Controls.Add(tab_workerDeatrails);
                tab_manager.SelectedTab = tab_workerDeatrails;
                WorkerDeatails(false, w1);
                //MessageBox.Show("edit");
                //WorkerDeatails add = new WorkerDeatails(false, w1);
                //add.Show();
            }

        }



        #endregion


        #region WorkerDeatails


        bool isAdd;
        public Worker w;
        public void WorkerDeatails(bool isAdd, Worker w)
        {


            txt_password.PasswordChar = '*';
            cmb_job.DataSource = Enum.GetValues(typeof(eJobs));
            manager = Global.GetManagers();
            cmb_manager.Items.Clear();
            cmb_manager.Items.AddRange(manager.Select(m => m.Name).ToArray());
            this.isAdd = isAdd;
            tab_workerDeatrails.Text = isAdd ? "Add worker" : "Edit worker";
            lblTitle.Text = isAdd ? "add worker" : "edit worker";
            btn_Action.Text = isAdd ? "Add" : "Edit ";
            this.w = w;
            if (!isAdd)
            {
                fillWorkerDeatails();
                btn_Action.Enabled = true;
            }
            else
            {
                btn_Action.Enabled = false;
                foreach (Control c in tab_workerDeatrails.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                }
            }

        }

        private void fillWorkerDeatails()
        {
            txt_name.Text = w.Name;
            txt_email.Text = w.EMail;
            lblPassword.Text = "";
            txt_password.BorderStyle = BorderStyle.None;
            txt_user_name.Text = w.UserName;
            cmb_job.SelectedItem = (eJobs)w.JobId;
            cmb_manager.SelectedItem = manager.FirstOrDefault(m => m.Id == w.ManagerId).Name;

        }

        public void checkValidName(object sender, EventArgs e)
        {
            checkVaidationLength(2, 15, (sender as TextBox));
            EbleButton();
        }
        void EbleButton()
        {
            if ((txt_user_name.Text.Length >= 2 && txt_user_name.Text.Length <= 10) &&
                              (txt_password.Text.Length >= 6 && txt_password.Text.Length <= 10) &&
                              ((txt_email.Text.Length >= 6 && txt_email.Text.Length <= 30)))
                btn_Action.Enabled = true;
        }
        public void checkValidUserName(object sender, EventArgs e)
        {
            checkVaidationLength(2, 10, (sender as TextBox));
            EbleButton();
        }
        public void checkValidPassword(object sender, EventArgs e)
        {
            checkVaidationLength(6, 10, (sender as TextBox));
            EbleButton();
        }
        public void checkValidEmail(object sender, EventArgs e)
        {
            checkVaidationLength(2, 30, (sender as TextBox));
            EbleButton();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            eJobs job;
            Enum.TryParse(cmb_job.SelectedValue.ToString(), out job);
            int IdJob = (int)job;
            int IdManager = manager.FirstOrDefault(m => m.Name == cmb_manager.Text).Id; //SelectedIndex

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Global.path + (isAdd ? "addWorker" : "updateWorker"));
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = isAdd ? "POST" : "PUT";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{" + (!isAdd ? "\"Id\":\"" + w.Id + "\"," : "") + "\"Name\":\"" + txt_name.Text + "\"," +
                   "\"UserName\":\"" + txt_user_name.Text + "\"," +
                   "\"Password\":\"" + (txt_password.Text != "" ? sha256(txt_password.Text) : "") + "\"," +
                    "\"JobId\":\"" + IdJob + "\"," +
                   "\"EMail\":\"" + txt_email.Text + "\"," +
                   "\"ManagerId\":\"" + IdManager +
                   "\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {


                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {

                    var result = streamReader.ReadToEnd();

                    MessageBox.Show($"The worker {txt_name.Text} {(isAdd ? "added" : "changed")} successfully");
                    tab_manager.Controls.Remove(tab_workerDeatrails);
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show($"Can not {(isAdd ? "add" : "change")} a worker");
            }
        }

        static string sha256(string password)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }

        #endregion






        #region reports
        List<dynamic> presences;
        public void GetPresences()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Global.path);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"getPresence").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                presences = JsonConvert.DeserializeObject<List<dynamic>>(result);
              //  SelectByWorkerName();
                SelectByProjectName();

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private void SelectByWorkerName()
        {

            List<dynamic> projectsByName = new List<dynamic>();
            var names = presences.Select(p => p["WorkerName"].Value).GroupBy(p => p).ToArray();

            foreach (var n in names)
            {
                List<dynamic> projectsHours = new List<dynamic>();
                var projects = presences.FindAll(p => p["WorkerName"].Value == n.Key).Select(p => p["ProjectName"].Value).GroupBy(p => p).ToArray();
                foreach (var pro in projects)
                {
                    var hours = presences.FindAll(p => p["ProjectName"].Value == pro.Key&& p["WorkerName"].Value == n.Key).Select(p => new
                    {
                        Date = p["Date"],
                        Start = p["Start"],
                        End = p["End"]
                    });
                    projectsHours.Add(new { pro.Key, hours });
                }
                projectsByName.Add(new { n.Key, projectsHours });
            }
            treeView1.BorderStyle = BorderStyle.None;
            foreach (var pbn in projectsByName)
            {

                TreeNode n = treeView1.Nodes.Add(pbn.Key);
                n.BackColor = Color.BurlyWood;
                foreach (var prh in pbn.projectsHours)
                {
                    TreeNode n1 = n.Nodes.Add(prh.Key);
                    n1.BackColor = Color.Coral;
                    foreach (var hour in prh.hours)
                    {
                        TreeNode n3 = n1.Nodes.Add($"date:{hour.Date.Value}, start:{hour.Start.Value}, end:{hour.End.Value}");
                        n3.BackColor = Color.Cyan;


                    }
                }

            }



        }
        private void SelectByProjectName()
        {

            List<dynamic> projectsByName = new List<dynamic>();
            var projects = presences.Select(p => p["ProjectName"].Value).GroupBy(p => p).ToArray();

            foreach (var n in projects)
            {
                List<dynamic> projectsHours = new List<dynamic>();
                var names = presences.FindAll(p => p["ProjectName"].Value == n.Key).Select(p => p["WorkerName"].Value).GroupBy(p => p).ToArray();
                foreach (var pro in names)
                {
                    var hours = presences.FindAll(p => p["WorkerName"].Value == pro.Key&& p["ProjectName"].Value == n.Key).Select(p => new
                    {
                        Date = p["Date"],
                        Start = p["Start"],
                        End = p["End"]
                    });
                    projectsHours.Add(new { pro.Key, hours });
                }
                projectsByName.Add(new { n.Key, projectsHours });
            }
            treeView1.BorderStyle = BorderStyle.None;
            foreach (var pbn in projectsByName)
            {

                TreeNode n = treeView1.Nodes.Add(pbn.Key);
                n.BackColor = Color.BurlyWood;
                foreach (var prh in pbn.projectsHours)
                {
                    TreeNode n1 = n.Nodes.Add(prh.Key);
                    n1.BackColor = Color.Coral;
                    foreach (var hour in prh.hours)
                    {
                        TreeNode n3 = n1.Nodes.Add($"date:{hour.Date.Value}, start:{hour.Start.Value}, end:{hour.End.Value}");
                        n3.BackColor = Color.Cyan;


                    }
                }

            }



        }

        #endregion

        private void txt_team_name_SelectedIndexChanged(object sender, EventArgs e)
        {

            getAllWorkers();
            int id = manager.Where(m => m.Name == txt_team_name.SelectedItem.ToString()).FirstOrDefault().Id;
            workerToSelect = new List<Worker>();
            workerToAdd = new List<Worker>();
            workerList.ForEach(w =>
            {
                if (w.ManagerId != null && w.JobId > 2 && w.ManagerId != id)
                    workerToSelect.Add(w);
            });
            dgvAddWorkers.DataSource = workerToSelect;
            dgvAddWorkers.Columns["Id"].Visible = false;

            //.Select(s => new { s.Id, s.Name })
        }

        private void dgvAddWorkers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvAddWorkers.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Beige)
            {
                dgvAddWorkers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;

                workerToAdd.Remove(workerToSelect[e.RowIndex]);

            }
            else
            {
                dgvAddWorkers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Beige;
                workerToAdd.Add(workerToSelect[e.RowIndex]);
            }

        }

        private void tab_workerDeatrails_Leave(object sender, EventArgs e)
        {

            tab_manager.Controls.Remove(tab_workerDeatrails);
        }

        private void tab_workerDeatrails_Click(object sender, EventArgs e)
        {

        }


        private void btnExportToExecl_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Workbooks.Add();
            Microsoft.Office.Interop.Excel._Worksheet workSheet = excel.ActiveSheet;
            try
            {
                workSheet.Cells[1, "A"] = "WorkerName";
                workSheet.Cells[1, "B"] = "ProjectName";
                workSheet.Cells[1, "C"] = "Date";
                workSheet.Cells[1, "D"] = "Start";
                workSheet.Cells[1, "E"] = "End";
                int row = 2;
                foreach (var car in presences)
                {
                    workSheet.Cells[row, "A"] = car["WorkerName"].Value;
                    workSheet.Cells[row, "B"] = car["ProjectName"].Value;
                    workSheet.Cells[row, "C"] = car["Date"].Value;
                    workSheet.Cells[row, "D"] = car["Start"].Value;
                    workSheet.Cells[row, "E"] = car["End"].Value;
                    row++;
                }
                workSheet.Range["A1"].AutoFormat(Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic1);
                string fileName = string.Format(@"{0}\Presences.xlsx", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                workSheet.SaveAs(fileName);
                MessageBox.Show(string.Format("The file '{0}' is saved successfully!", fileName));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception",
                    "There was a PROBLEM saving Excel file!\n" + exception.Message,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                excel.Quit();
                if (excel != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                if (workSheet != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                excel = null;
                workSheet = null;
                GC.Collect();
            }

        }
    }
}
