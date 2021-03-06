﻿using BOL;
using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public static class TeamLeaderLogic
    {

        public static List<Project> GetProjectDeatails(int teamLeaderId)
        {
            string query = $"SELECT * FROM task_managment.projects WHERE team_leader={teamLeaderId}";

            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> projects = new List<Project>();
                while (reader.Read())
                {

                    projects.Add(new Project
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Customer = reader.GetString(2),
                        TeamLeaderId = reader.GetInt32(3),
                        DevelopHours = reader.GetInt32(4),
                        QAHours = reader.GetInt32(5),
                        UiUxHours = reader.GetInt32(6),
                        StartDate = Convert.ToDateTime(reader.GetString(7)),
                        EndDate = Convert.ToDateTime(reader.GetString(8))


                    });
                }
                return projects;
            };

            return DBAccess.RunReader(query, func);

        }

        public static List<Worker> GetWorkersDeatails(int teamLeaderId)
        {
            string query = $"SELECT * FROM task_managment.workers WHERE manager={teamLeaderId}";

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
            return DBAccess.RunReader(query, func);

        }
      
        public static List<Object> getWorkersHours(int projectId)
        {
            string query = $"SELECT  name,SEC_TO_TIME(SUM(TIME_TO_SEC(end) - TIME_TO_SEC(start))) AS Time, allocated_hours" +
        $" FROM workers W JOIN project_workers PW ON W.worker_id=PW.worker_id LEFT JOIN work_hours WH ON PW.project_worker_id= WH.project_work_id" +
       $" WHERE PW.project_id= {projectId}" +
        $" GROUP BY name, allocated_hours ORDER BY name";
           

            Func<MySqlDataReader, List<Object>> func = (reader) =>
            {
                List<Object> unknowns = new List<Object>();
                while (reader.Read())
                {

                 
                    /////////////////
                    string s = reader[2].ToString();
                    float.TryParse(s, out float x);
                       string s2;
                    try
                    {
                        TimeSpan t = reader.GetTimeSpan(1);
                        s2 = (t.Hours + t.Days * 24) + ":" + t.Minutes;
                    }
                    catch { s2 = 0 + ":" + 0; };
               //  DateTime.TryParse( reader[1].ToString(), out DateTime d);
                    unknowns.Add(new 
                    {

                        Name = reader.GetString(0),
                        //Date = d,
                       Hours = s2,
                       AllocatedHours = x
                    });

                }
                return unknowns;

            };
            return DBAccess.RunReader(query, func);

        }
        public static List<Object> getWorkerHours(int teamLeaderId, int workerId)
        {
            string query = $"SELECT pw.project_worker_id, p.name , allocated_hours , SEC_TO_TIME(SUM(TIME_TO_SEC(end) - TIME_TO_SEC(start)))" +
            $" FROM project_workers PW join projects p on p.project_id=pw.project_id"+
            $" LEFT join work_hours wh on wh.project_work_id= pw.project_worker_id" +
            $" where p.team_leader={teamLeaderId} and pw.worker_id= {workerId}"+
            $" group by pw.project_worker_id, p.name  ,  allocated_hours";

            Func<MySqlDataReader, List<Object>> func = (reader) =>
            {
                List<Object> unknowns = new List<Object>();
                while (reader.Read())
                {

                    string s = reader[2].ToString();
                    float.TryParse(s, out float x);
                    string s2 = reader[3].ToString();
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

        public static string GetRemainingHours(int projectId, int jobId)
        {
            
          string jobName= ManagerLogic.GetAllJobs().FirstOrDefault(j=>j.Id==jobId).Name;

            switch (jobName)
            {
                case "developer":
                    {
                        jobName = "develop_houres";
                        break;
                    }
                case "QA":
                    {
                        jobName = "qa_houres";
                        break;
                    }
                case "UxUi":
                    {
                        jobName = "ui_ux_houres";
                        break;
                    }
            }
 
            string query = $" SELECT {jobName} - SUM(allocated_hours)" +
$" FROM projects P JOIN  project_workers PW ON P.project_id = PW.project_id JOIN workers W ON W.worker_id = PW.worker_id" +
$" WHERE PW.project_worker_id = {projectId} AND W.job = {jobId}";
            return DBAccess.RunScalar(query).ToString();
        }

        public static bool UpdateWorkerHours(int projectWorkerId, int numHours)
        {
            string query = $"UPDATE task_managment.project_workers SET allocated_hours={numHours} WHERE project_worker_id={projectWorkerId}";
            return DBAccess.RunNonQuery(query) == 1;
        }

        public static string GetHours(int projectId)
        {

            string query = $"SELECT SEC_TO_TIME(SUM(TIME_TO_SEC(end) - TIME_TO_SEC(start))) FROM task_managment.work_hours WHERE project_work_id IN" +
                $"(SELECT project_worker_id FROM task_managment.project_workers" +
                $" WHERE project_id={projectId}) ";
            return DBAccess.RunScalar(query).ToString();
        }

        //        
    }
}
