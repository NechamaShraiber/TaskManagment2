using BOL;
using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        Password = reader.GetString(3),
                        EMail = reader.GetString(4),
                        JobId = reader.GetInt32(5),
                        ManagerId = reader[6] as int?
                    });
                }
                return worker;
            };
            List<Worker> workers= DBAccess.RunReader(query, func);
            if (workers != null && workers.Count > 0)
                return workers[0];
            return null;
        }



    }
}
