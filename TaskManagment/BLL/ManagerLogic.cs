using BOL;
using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Web;

namespace BLL
{
    public class ManagerLogic
    {

        public static bool AddProject(Project project)
        {

            string query = $"INSERT INTO task_managment.projects  " +
                $"(name,customer,team_leader,develop_houres,qa_houres,ui_ux_houres,start_date,end_date)" +
                $" VALUES ('{project.Name}','{project.Customer}'," +
                $"'{project.TeamLeaderId}',{project.DevelopHours},{project.QAHours},{project.UiUxHours}," +
                $"'{project.StartDate.Year}-{project.StartDate.Month}-{project.StartDate.Day}','{project.EndDate.Year}-{project.EndDate.Month}-{project.EndDate.Day}')";
            if (DBAccess.RunNonQuery(query) == 1)
            {
                return AddWorkersToProject(project);

            }

            return false;

        }

        private static bool AddWorkersToProject(Project project)
        {
            var query = $"SELECT project_id FROM projects WHERE name = '{project.Name}'";
            int idProject = (int)DBAccess.RunScalar(query);

            query = $"SELECT worker_id FROM workers" +
                    $" WHERE manager ={project.TeamLeaderId}";
            List<int> workersId = new List<int>();
            Func<MySqlDataReader, List<int>> func = (reader) =>
            {
                List<int> workers = new List<int>();

                while (reader.Read())
                {
                    //Add all the teamLeadr's worker to the project
                    workers.Add(reader.GetInt32(0));
                }
                return workers;
            };

            workersId = DBAccess.RunReader(query, func);

            workersId.ForEach(idWorker =>
            {
                var q = $"INSERT INTO project_workers (worker_id,project_id) VALUES({idWorker},{idProject})";
                DBAccess.RunNonQuery(q);
            });
            return true;
        }

        public static bool addWorkersToProject(int[] ids, string name)
        {
            string q = $"SELECT project_id FROM projects WHERE name = '{name}'";
            int idProject = (int)DBAccess.RunScalar(q);
            foreach (var item in ids)
            {
                string query = $"INSERT INTO task_managment.project_workers ({item},{idProject}) VALUES(4,3)";
                if (DBAccess.RunNonQuery(query) == 0)
                    return false;
            }
            return true;
        }

        public static bool AddWorker(Worker worker)
        {

            string query = $"INSERT INTO task_managment.workers  " +
                $"(name,user_name,password,email,job,manager)" +
                $" VALUES ('{worker.Name}','{worker.UserName}'," +
                $"'{worker.Password}','{worker.EMail}',{worker.JobId},{worker.ManagerId})";
            return DBAccess.RunNonQuery(query) == 1;

        }

        public static bool UpdateWorker(Worker worker)
        {
            string query;
            if (worker.Password != null)
            {
                query = $"UPDATE task_managment.workers SET name='{worker.Name}', user_name='{worker.UserName}'" +
                                $", password='{worker.Password}' , email='{worker.EMail}', job={worker.JobId}, manager={worker.ManagerId} WHERE worker_id={worker.Id}";
            }
            else
            {
                query = $"UPDATE task_managment.workers SET name='{worker.Name}', user_name='{worker.UserName}'" +
                $", email='{worker.EMail}', job={worker.JobId}, manager={worker.ManagerId} WHERE worker_id={worker.Id}";
            }
            return DBAccess.RunNonQuery(query) == 1;
        }

        public static List<Worker> GetAllWorkers()
        {

            string query = $"SELECT * FROM task_managment.workers";

            Func<MySqlDataReader, List<Worker>> func = (reader) =>
            {
                List<Worker> workers = new List<Worker>();
                // var v = reader.GetInt32(0);
                // var t = reader.GetString(1);
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

            return DBAccess.RunReader(query, func);

        }
        public static List<Worker> GetAllManagers()
        {
            string query = $"SELECT * FROM task_managment.workers WHERE job<=2";
            Func<MySqlDataReader, List<Worker>> func = (reader) =>
            {
                List<Worker> managers = new List<Worker>();
                while (reader.Read())
                {
                    managers.Add(new Worker
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
                return managers;
            };
            return DBAccess.RunReader(query, func);

        }
        public static List<Job> GetAllJobs()
        {
            string query = $"SELECT * FROM task_managment.jobs";
            Func<MySqlDataReader, List<Job>> func = (reader) =>
            {
                List<Job> jobs = new List<Job>();
                while (reader.Read())
                {
                    jobs.Add(new Job
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                    });
                }
                return jobs;
            };
            return DBAccess.RunReader(query, func);

        }
        public static bool RemoveWorker(int id)
        {
            //To delete an employee, it is necessary to delete it from all the tables in which it is located.
            var q = $"SELECT project_worker_id  FROM task_managment.project_workers  WHERE   worker_id={id}";
            List<int> projectsworkerId = new List<int>();
            Func<MySqlDataReader, List<int>> func = (reader) =>
            {
                List<int> projects = new List<int>();

                while (reader.Read())
                {
                    //Add all the teamLeadr's worker to the project
                    projects.Add(reader.GetInt32(0));
                }
                return projects;
            };

            projectsworkerId = DBAccess.RunReader(q, func);
            projectsworkerId.ForEach(idProject =>
            {
                var q2 = $"DELETE FROM task_managment.work_hours WHERE project_work_id={idProject}";
                DBAccess.RunNonQuery(q2);
            });
            q = $"DELETE FROM task_managment.project_workers WHERE worker_id={id}";
            DBAccess.RunNonQuery(q);
            q = $"DELETE FROM task_managment.workers WHERE worker_id={id}";
            return DBAccess.RunNonQuery(q) == 1;

        }

        // GetDeatails()

        //    public static List<User> GetDeatails(int? projectId, int? teamLeaderId, string month, int? workerId)
        //{
        //    string query = $"SELECT * FROM [dbo].[Users]";

        //    Func<SqlDataReader, List<User>> func = (reader) => {
        //        List<User> users = new List<User>();
        //        while (reader.Read())
        //        {
        //            users.Add(new User
        //            {
        //                Id = reader.GetInt32(0),
        //                UserName = reader.GetString(1),
        //                IsMale = reader.GetBoolean(3),
        //                Age = reader.GetInt32(2)
        //            });
        //        }
        //        return users;
        //    };

        //    return DBAccess.RunReader(query, func);
        //}


        public static List<Object> GetPresence()
        {

            string query = $"SELECT w.name, p.name, wh.date , wh.start , wh.end" +
$" FROM workers W JOIN project_workers pw ON w.worker_id = pw.worker_id" +
$" JOIN projects P ON pw.project_id = p.project_id JOIN work_hours wh" +
$" ON wh.project_work_id = pw.project_worker_id" +
$" ORDER BY w.name, p.name, wh.date , wh.start";


            Func<MySqlDataReader, List<Object>> func = (reader) =>
            {
                List<Object> Presence = new List<Object>();
                // var v = reader.GetInt32(0);
                // var t = reader.GetString(1);
                while (reader.Read())
                {

                    Presence.Add(new 
                    {
                       
                        WorkerName = reader.GetString(0),
                        ProjectName=reader.GetString(1),
                        Date = reader.GetDateTime(2),
                       Start=reader.GetString(3),
                       End = reader.GetString(4),


                    });
                }
                return Presence;
            };

            return DBAccess.RunReader(query, func);

        }

        /*
         * 
        */

       public static void ExportExcel()
        {
            //DataTable table = Connect.DB.Student();
            List<dynamic> students;
            //    DataTable table = ToDataTable(students);


                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"" >");
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");

                HttpContext.Current.Response.Charset = "utf-8";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("Windows-1255");
                //sets font
                HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
                HttpContext.Current.Response.Write("<BR><BR><BR>");
                //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
                HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
                  "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
                  "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
                //am getting my grid's column headers
                //int columnscount = table.Columns.Count;

                //for (int j = 0; j < columnscount; j++)
                //{      //write in new column
                //    HttpContext.Current.Response.Write("<Td>");
                //    //Get column headers  and make it as bold in excel columns
                //    HttpContext.Current.Response.Write("<B>");
                //    HttpContext.Current.Response.Write(table.Columns[j].ToString());
                //    HttpContext.Current.Response.Write("</B>");
                //    HttpContext.Current.Response.Write("</Td>");
                //}
                HttpContext.Current.Response.Write("</TR>");
                //foreach (DataRow row in table.Rows)
                //{//write in new row
                //    HttpContext.Current.Response.Write("<TR>");
                //    for (int i = 0; i < table.Columns.Count; i++)
                //    {
                //        HttpContext.Current.Response.Write("<Td>");
                //        HttpContext.Current.Response.Write(row[i].ToString());
                //        HttpContext.Current.Response.Write("</Td>");
                //    }

                //    HttpContext.Current.Response.Write("</TR>");
                //}
                HttpContext.Current.Response.Write("</Table>");
                HttpContext.Current.Response.Write("</font>");
                HttpContext.Current.Response.Flush();

                HttpContext.Current.Response.End();
            }

            public static DataTable ToDataTable(List<dynamic> items)
            {
            DataTable dataTable = new DataTable();
                // Get all the properties
                //PropertyInfo[] Props = typeof().GetProperties((BindingFlags.Public | BindingFlags.Instance));
                //foreach (PropertyInfo prop in Props)
                //{
                //    // Setting column names as Property names
                //    dataTable.Columns.Add(prop.Name);
                //}

                //foreach (Entities.Students item in items)
                //{
                //    List<object> values = new List<object>();

                //    for (int i = 0; (i <= (Props.Length - 1)); i++)

                //    {
                //        // inserting property values to datatable rows
                //        values.Add(Props[i].GetValue(item, null));
                //    }

                //    dataTable.Rows.Add(values.ToArray());
                //}

                // put a breakpoint here and check datatable
                return dataTable;

            }
    }
}
