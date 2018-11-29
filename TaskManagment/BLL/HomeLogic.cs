using BOL;
using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Timers;

namespace BLL
{
    public static class HomeLogic
    {
      
        //public static string CheckLogin(string userName, string password)
        //{
        //string query = $"SELECT * FROM task_managment.workers WHERE user_name='{userName}' and password='{password}' ";
        //return DBAccess.RunScalar(query).ToString();
        //    }

        public static Worker Login(string userName, string password)
        {
            string query = $"SELECT * FROM task_managment.workers WHERE user_name='{userName}' and password='{password}' ";
            Func<MySqlDataReader, List<Worker>> func = (reader) => {
                List<Worker> worker = new List<Worker>();
                while (reader.Read())
                {
                    worker.Add(new Worker
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        UserName = reader.GetString(2),
                        Password = "",
                        EMail = reader.GetString(4),
                        JobId = reader.GetInt32(5),
                        ManagerId = reader[6] as int?
                    });
                }
                return worker;
            };
       //     Notifications();
            List<Worker> workers= DBAccess.RunReader(query, func);
            if (workers != null && workers.Count > 0)
                return workers[0];
            return null;
        }

        public static bool UpdatePassword(string userName, string oldpassword, string newPassord)
        {

            string query =$" UPDATE workers SET password = '{newPassord}' WHERE user_name = '{userName}' AND password = '{oldpassword}'";
            return DBAccess.RunNonQuery(query) == 1;
        }

        public static bool sendEmail(string sub, string body, string email)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("shtilimrishum2018@gmail.com");
            msg.To.Add(new MailAddress(email));
            msg.Subject = sub;
            msg.Body = body;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("shtilimrishum2018@gmail.com", "0504190762");
            client.Timeout = 20000;
            try
            {
                client.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                msg.Dispose();
            }
        }
   
        public static void OnStart(object sender, ElapsedEventArgs args)
        {

            string query = $"SELECT DISTINCT w.email, p.name ,p.end_date" +
          $"  FROM workers w JOIN project_workers pw ON W.worker_id = pw.worker_id JOIN projects p" +
          $"  ON p.project_id = pw.project_id JOIN work_hours wh ON pw.project_worker_id = wh.project_work_id" +
          $"  WHERE p.end_date <= NOW() + INTERVAL 1 DAY" +
          $"  GROUP BY w.email, p.name ,p.end_date, pw.allocated_hours" +
          $"  HAVING pw.allocated_hours > HOUR(SEC_TO_TIME(SUM(TIME_TO_SEC(wh.end) - TIME_TO_SEC(wh.start)))) + (MINUTE(SEC_TO_TIME(SUM(TIME_TO_SEC(wh.end) - TIME_TO_SEC(wh.start))))) / 100" +
          $"  UNION SELECT w.email, p.name ,p.end_date" +
          $"  FROM workers w JOIN projects p ON p.team_leader = W.worker_id" +
          $"   WHERE p.end_date <= NOW() + INTERVAL 1 DAY AND p.name IN(" +
          $"   SELECT p1.name" +
          $"  FROM workers w1 JOIN project_workers pw1 ON W1.worker_id = pw1.worker_id JOIN projects p1" +
          $"  ON p1.project_id = pw1.project_id JOIN work_hours wh1 ON pw1.project_worker_id= wh1.project_work_id" +
          $"  WHERE p1.end_date <= NOW() + INTERVAL 1 DAY" +
          $"  GROUP BY w1.email, p1.name ,p1.end_date,pw1.allocated_hours" +
          $" HAVING pw1.allocated_hours > HOUR(SEC_TO_TIME(SUM(TIME_TO_SEC(wh1.end) - TIME_TO_SEC(wh1.start)))) + (MINUTE(SEC_TO_TIME(SUM(TIME_TO_SEC(wh1.end) - TIME_TO_SEC(wh1.start))))) / 100)";

            Func<MySqlDataReader, List<object>> func = (reader) => {
                List<object> objects = new List<object>();
                while (reader.Read())
                {

                    var o = new
                    {
                        email = reader.GetString(0),
                        name = reader.GetString(1),
                        end_date = Convert.ToDateTime(reader.GetString(2)),




                    };
                    sendEmail("Notification do not end task", $"the project {o.name} end in {o.end_date}!!", o.email);
                }
                return objects;
            };
            List<object> objects2 = DBAccess.RunReader(query, func);

        }
        public static  void Notifications()
        {
            OnStart(null, null);
            Timer timer = new Timer();
            timer.Interval = 60000*60*24; // once a day
            timer.Elapsed += new ElapsedEventHandler(OnStart);
            timer.Start();
           

        }

    }
}



//public static void NoticeEmail()

//{
//    // Set up a timer that triggers every minute.
   
//}

//public static void OnStart(object sender, ElapsedEventArgs args)
//{
//    // TODO: Insert monitoring activities here.
//    Email email = new Email() { Subject = "first testing", Body = "windows service is working!!" };
//    email.ToAddress.Add("efratz0879@gmail.com");
//    BaseService.SendEmail(email);
//    List<Project> projects = ProjectService.GetAllProjects(DateTime.Today);
//    projects.ForEach(project =>
//    {
//        List<User> workers = UserService.GetAllUsers(project.TeamLeaderId);
//        UserService.GetAllUsersWithProjectPermission(project.ProjectId);
//    });
//}
