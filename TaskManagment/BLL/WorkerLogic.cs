
using BOL;
using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class WorkerLogic
    {
        public static bool UpdateStartHour(int idProjectWorker,DateTime hour )
        {

            //INSERT INTO task_managment.work_hours (project_work_id,date,start) VALUES (13,'2018-10-25','09:05:23')
            //UPDATE task_managment.work_hours  SET end="14:30:00"  WHERE work_hours_id=9
            string query = $"INSERT INTO task_managment.work_hours (project_work_id, date, start)"+
                $" VALUES({idProjectWorker}, '{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}', '{hour.TimeOfDay}')";
            return DBAccess.RunNonQuery(query) == 1;
        }
        public static bool UpdateEndHour(int idProjectWorker, DateTime hour)
        {

            //INSERT INTO task_managment.work_hours (project_work_id,date,start) VALUES (13,'2018-10-25','09:05:23')
            //UPDATE task_managment.work_hours  SET end="14:30:00"  WHERE work_hours_id=9
            string query = $"UPDATE task_managment.work_hours  SET end='{hour.TimeOfDay}'  WHERE project_work_id={idProjectWorker}" +
                $" AND END IS NULL";
            return DBAccess.RunNonQuery(query) == 1;
        }
       
        public static bool SendMsg(string sub, string body,int id)
        {
            string query = $"SELECT email FROM task_managment.workers where worker_id = {id}" ;
           string email=(string) DBAccess.RunScalar(query);
            return HomeLogic.sendEmail(sub, body, email);
          
        }


        public static Worker GetWorkerDetails(int id)
        {
            string query = $"SELECT * FROM task_managment.workers WHERE worker_id={id}";
            Func<MySqlDataReader, List<Worker>> func = (reader) =>
            {
                List<Worker> workers = new List<Worker>();
                while (reader.Read())
                {
                    workers.Add(new Worker
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
                return workers;
            };
            List<Worker> workers2 = DBAccess.RunReader(query, func);
            if (workers2 != null && workers2.Count > 0)
                return workers2[0];
            return null;
        }
        public static List<object> GetProject(int id)
        {
        //    /*SELECT PW.project_worker_id, p.name,  allocated_hours, SEC_TO_TIME(TIME_TO_SEC(end) - TIME_TO_SEC(start)) AS Time
        // FROM project_workers PW JOIN projects P ON P.project_id = PW.project_id LEFT JOIN
        // work_hours WH ON PW.project_worker_id = WH.project_work_id
        //WHERE PW.worker_id = 13
        //group by  name
        //     */
            string query = $"SELECT PW.project_worker_id, p.name,  allocated_hours, SEC_TO_TIME(SUM(TIME_TO_SEC(end) - TIME_TO_SEC(start))) AS Time" +
        $" FROM project_workers PW JOIN projects P ON P.project_id = PW.project_id LEFT JOIN" +
        $" work_hours WH ON PW.project_worker_id = WH.project_work_id" +
        $" WHERE PW.worker_id = {id}" +
        $"    GROUP BY PW.project_worker_id,p.name,allocated_hours   ORDER BY project_worker_id";
      
            Func<MySqlDataReader, List<Object>> func = (reader) =>
            {
                List<Object> unknowns = new List<Object>();
                while (reader.Read())
                {
                     string s=reader[2].ToString();
                    int.TryParse(s,out int  x);
                    string s2;
                    try {
                        TimeSpan t = reader.GetTimeSpan(3);
                        s2 = (t.Hours + t.Days * 24) + ":" + t.Minutes;
                    }
                    catch { s2 = 0+ ":" +0; };
                        unknowns.Add(new 
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            AllocatedHours = x,
                            Hours = s2 
                    });
                }
                return unknowns;
            };
            return DBAccess.RunReader(query, func);
        }

        public static string GetAllHours(int id)
        {
            string query = $"SELECT SEC_TO_TIME(SUM(TIME_TO_SEC(end) - TIME_TO_SEC(start))) FROM task_managment.work_hours" +
                $" WHERE work_hours_id IN(SELECT project_worker_id" +
 $" FROM task_managment.project_workers WHERE worker_id = {id})";
            return DBAccess.RunScalar(query).ToString();
          
        }
     

    }
}

