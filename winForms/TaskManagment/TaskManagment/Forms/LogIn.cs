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
            txtNewPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
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
                btnChange.Enabled = false;
            }

            if (txt_password.Text.Length < 6 || txt_password.Text.Length > 10)
            {
                errorProvider1.SetError(txt_password, "Password must be between 6-10");
                btn_logIn.Enabled = false;
                btnChange.Enabled = false;

            }

        }
        public void checkValidateNewPassword(object sender, EventArgs e)
        {
            checkValidate(sender, e);

            btnChange.Enabled = true;
            if (txtNewPassword.Text.Length < 6 || txtNewPassword.Text.Length > 10)
            {
                errorProvider1.SetError(txtNewPassword, "Password must be between 6-10");
                btnChange.Enabled = false;
            }
            if (txtConfirmPassword.Text!=txtNewPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "confirm password must be same new password");
                btnChange.Enabled = false;
            }
            if (txtConfirmPassword.Text.Length < 6 || txtConfirmPassword.Text.Length > 10)
            {
                errorProvider1.SetError(txtConfirmPassword, "Password must be between 6-10");
                btnChange.Enabled = false;
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

        private void label3_Click(object sender, EventArgs e)
        {
            changeControler(true);

        }
       void changeControler(bool b)
        {
            lblPassword.Text = b?"oldPassword":"password";
            lblConfirmPassword.Visible =b;
            lblNewPassword.Visible = b;
            txtNewPassword.Visible = b;
            txtConfirmPassword.Visible = b;
            btn_logIn.Visible = !b;
            btnChange.Visible = b;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnChange_Validated(object sender, EventArgs e)
        {

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Global.path +"updatePassword");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method =  "POST";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"userName\":\"" + txt_userName.Text + "\"," +
                       "\"oldpassword\":\"" + sha256(txt_password.Text) +  "\"," +
                       "\"newPassord\":\"" + sha256(txtNewPassword.Text) + "\"}";
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

                    MessageBox.Show($"change");
                    txt_password.Text = txtNewPassword.Text;
                    changeControler(false);

                }
            }
            catch (WebException ex)
            {
                lbl_bad_request.Text = "One or more of the data is incorrect";

            }
        }
    }
   
}



