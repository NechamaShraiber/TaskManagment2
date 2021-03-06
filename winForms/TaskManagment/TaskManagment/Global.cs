﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagment.Models;

namespace TaskManagment
{
    // public enum eJobs {Manager=1,TeamLeader,QA,UxUi, Developer}      
    static class Global
    {
        static Global()
        {
            getAllJobs();
        }
        static ErrorProvider errorProvider1 = new ErrorProvider();
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
        public static string sha256(string password)
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
        #region Validatiion
        public static bool checkVaidationLength(int min, int max, TextBox textBox)
        {
            if (textBox.Text.Length < min || textBox.Text.Length > max)
            {
                errorProvider1.SetError(textBox, $" must be between {min}-{max}");
                return false;
            }
            else
            {
                errorProvider1.Clear();
                return true;
                //checkValidButton();
            }
        }

        public static bool checkVaidationNumber(int min, int max, TextBox textBox)
        {

            if (textBox.Text.Length == 0 || Convert.ToInt32(textBox.Text) < min)
                errorProvider1.SetError(textBox, $"must be greater than {min}");
            else
            {
                errorProvider1.Clear();
                return true;
            }
            return false;
        }
        public static bool checkValidEmail(TextBox textBox)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(textBox.Text))
            {
                errorProvider1.SetError(textBox, $" email must be valid address");
                return false;
            }
            return true;

        }

        public static void onlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true || e.KeyChar == (Char)Keys.Back)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;

        }
        #endregion
        public static void LogOut()
        {
            File.Delete("user.xml");
            CurrentWorker = null;
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "LogIn")
                    f.Close();
                else
                {
                    f.Controls["txt_userName"].Text = "";
                    f.Controls["txt_password"].Text = "";
                }
            }
        }
    }

}
