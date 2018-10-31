using System;
using DAL;
using BOL;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BLL
{
    public class Logic
    {
       
        public static List<Job> GetJobs()
        {
            string query = $"SELECT * FROM  task_managment.jobs";

            Func<MySqlDataReader, List<Job>> func = (reader) => {
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
        
    }
}
