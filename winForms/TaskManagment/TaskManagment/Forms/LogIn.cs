using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using TaskManagment.Forms;
using TaskManagment.Models;

namespace TaskManagment
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            btn_logIn.Enabled = false;
            txt_password.PasswordChar = '*';
        }

        public void checkValidate(object sender, EventArgs e)
        {
            lbl_bad_request.Text = "";
            errorProvider1.Clear();
            btn_logIn.Enabled = true;
            if (txt_userName.Text.Length < 2 || txt_userName.Text.Length > 10)
            {
                errorProvider1.SetError(txt_userName, "UserName must be between 2-10");
                btn_logIn.Enabled = false;
            }

            if (txt_password.Text.Length < 6 || txt_password.Text.Length > 10)
            {
                errorProvider1.SetError(txt_password, "Password must be between 6-10");
                btn_logIn.Enabled = false;
            }

        }

        private void btn_logIn_Click(object sender, EventArgs e)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Global.path + "login");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    // sha256(txt_password.Text)!!!!!!!!!!
                    string json = "{\"userName\":\"" + txt_userName.Text + "\"," +
                       "\"password\":\"" + sha256(txt_password.Text) + "\"}";
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }



                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                try
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        Global.CurrentWorker = JsonConvert.DeserializeObject<Worker>(result);
                        switch (Global.CurrentWorker.JobId)
                        {
                            case 1:
                                {
                                    ManagerHome managerHome = new ManagerHome();
                                    managerHome.Show();
                                    break;
                                }

                            case 2:
                                {
                                    TeamLeaderHome teamLeader = new TeamLeaderHome();
                                    teamLeader.Show();
                                    break;
                                }

                            default:
                                {
                                    WorkerHome worker = new WorkerHome();
                                    worker.Show();
                                    break;
                                }


                        }

                    }
                }
                catch (WebException ex)
                {
                    lbl_bad_request.Text = "One or more of the data is incorrect";
                }
            }
            catch(Exception exe)
            {
                lbl_bad_request.Text = "The service is not connected";
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

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}



